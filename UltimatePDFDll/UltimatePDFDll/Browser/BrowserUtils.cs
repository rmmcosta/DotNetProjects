using PuppeteerSharp;
using PuppeteerSharp.Media;
using OutSystems.NssUltimatePDF.PDF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.IO.Compression;

namespace OutSystems.NssUltimatePDF.Browser
{
    public class BrowserUtils : IDisposable {

        private const string USER_AGENT_SUFFIX = "UltimatePDF/1.0";

        private PuppeteerSharp.Browser browser = null;

        private static BrowserFetcher BrowserFetcher {
            get {
                return new BrowserFetcher(new BrowserFetcherOptions() {
                    Path = Path.Combine(Path.GetTempPath(), ".local-chromium")
                });
            }
        }

        private static string[] BrowserArgs {
            get {
                // Flags required for software rendering, since hardware acceleration is not available in session 0
                return new string[] { "--disable-gpu", "--no-sandbox" };
            }
        }

        public static RevisionInfo RevisionInfo(int revision) {
            return BrowserFetcher.RevisionInfo(revision != 0 ? revision : BrowserFetcher.DefaultRevision);
        }

        public static bool IsValidRevision(RevisionInfo revision) {
            return File.Exists(revision.ExecutablePath);
        }

        public static IEnumerable<int> ValidLocalRevisions() {
            return BrowserFetcher.LocalRevisions().Where(r => IsValidRevision(RevisionInfo(r)));
        }

        public static async Task DownloadRevision(RevisionInfo revision) {
            if (Directory.Exists(revision.FolderPath) && !IsValidRevision(revision)) {
                Directory.Delete(revision.FolderPath, true);
            }

            await BrowserFetcher.DownloadAsync(revision.Revision);
        }

        public static void ExtractRevision(RevisionInfo revision, byte[] zip) {
            if (Directory.Exists(revision.FolderPath) && !IsValidRevision(revision)) {
                Directory.Delete(revision.FolderPath, true);
            }

            using (MemoryStream stream = new MemoryStream(zip)) {
                using (ZipArchive archive = new ZipArchive(stream, ZipArchiveMode.Read)) {
                    foreach (var entry in archive.Entries) {
                        if (string.IsNullOrEmpty(entry.Name)) {
                            Directory.CreateDirectory(Path.Combine(revision.FolderPath, entry.FullName));
                        } else {
                            using (FileStream fileStream = File.Create(Path.Combine(revision.FolderPath, entry.FullName))) {
                                using (Stream entryStream = entry.Open()) {
                                    entryStream.CopyTo(fileStream);
                                }
                            }
                        }
                    }
                }
            }

            if (Directory.Exists(revision.FolderPath) && !IsValidRevision(revision)) {
                throw new InvalidDataException("Could not find browser in " + revision.ExecutablePath);
            }
        }

        public async Task<byte[]> PrintPDF(string url, IEnumerable<CookieParam> cookies, ViewPortOptions viewport, PdfOptions options, RevisionInfo revision) {
            LaunchOptions launchOptions = new LaunchOptions() {
                ExecutablePath = "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe",
                Args = BrowserArgs,
                Headless = true,
                DefaultViewport = viewport,
                Timeout = 0
            };

            browser = await Puppeteer.LaunchAsync(launchOptions);
            try {
                var page = await browser.NewPageAsync();
                try {
                    WaitUntilNavigation[] waitUntilNavigations = { WaitUntilNavigation.Networkidle0 };
                    NavigationOptions navigationOptions = new NavigationOptions() {
                        Timeout = 0,
                        WaitUntil = waitUntilNavigations
                    };

                    string originalUserAgent = await browser.GetUserAgentAsync();
                    await page.SetUserAgentAsync($"{originalUserAgent} {USER_AGENT_SUFFIX}");

                    if (cookies.Any()) {
                        await page.SetCookieAsync(cookies.ToArray());
                    }

                    await page.GoToAsync(url, navigationOptions);
                    await InjectCustomStylesAsync(page, ref options);
                    
                    bool hasPageNumbers = await page.EvaluateFunctionAsync<bool>("(window.UltimatePDF? window.UltimatePDF.hasPageNumbers : function() { return false; })");
                    if (hasPageNumbers) {
                        /*
                         * When the layout has page numbers, we first retrieve a
                         * first blank pdf to calculate the number of pages.
                         * Then, knowing how many pages, we can layout the headers and footers,
                         * and retrieve the final pdf.
                         */
                        byte[] blankContents = await page.PdfDataAsync(options);
                        using (var blankPdf = new PDFUtils(blankContents)) {
                            await page.EvaluateFunctionAsync("window.UltimatePDF.layoutPages", blankPdf.Pages);
                            return await page.PdfDataAsync(options);
                        }
                    } else {
                        return await page.PdfDataAsync(options);
                    }
                } finally {
                    await Cleanup(page);
                }
            } finally {
                Cleanup(browser);
            }
        }


        private Task InjectCustomStylesAsync(Page page, ref PdfOptions options) {
            /*
             * It seems that Puppeteer is not overriding the page styles from the print stylesheet.
             * As a workaround, we inject a <style> tag with the @page overrides at the end of <head>.
             * This issue might be eventually resolved in Puppeteer, and seems to be tracked by https://github.com/GoogleChrome/puppeteer/issues/393
             */
            string overrides = string.Empty;
            if (!options.PreferCSSPageSize && options.Width != null && options.Height != null) {
                overrides += $"size: {options.Width} {options.Height}; ";
            }
            if (options.MarginOptions.Top != null) {
                overrides += $"margin-top: {options.MarginOptions.Top}; ";
            }
            if (options.MarginOptions.Right != null) {
                overrides += $"margin-right: {options.MarginOptions.Right}; ";
            }
            if (options.MarginOptions.Bottom != null) {
                overrides += $"margin-bottom: {options.MarginOptions.Bottom}; ";
            }
            if (options.MarginOptions.Left != null) {
                overrides += $"margin-left: {options.MarginOptions.Left}; ";
            }

            if (!string.IsNullOrEmpty(overrides)) {
                /* Change the options so that Puppeteer respects our overrides */
                options.PreferCSSPageSize = true;
                options.Width = options.Height = null;
                options.MarginOptions = new MarginOptions();

                /* We must add the <style> tag at the end of <body> to make sure it is not overriden */
                string pageOverrides = "@page { " + overrides + "}";
                return page.EvaluateExpressionAsync($"const style = document.createElement('style'); style.innerHTML = '{pageOverrides}'; document.head.appendChild(style);");
            } else {
                return Task.CompletedTask;
            }
        }

        public async Task<byte[]> ScreenshotPNG(string url, IEnumerable<CookieParam> cookies, ViewPortOptions viewport, ScreenshotOptions options, RevisionInfo revision) {
            LaunchOptions launchOptions = new LaunchOptions() {
                ExecutablePath = revision.ExecutablePath,
                Args = BrowserArgs,
                Headless = true,
                DefaultViewport = viewport,
                Timeout = 0
            };

            browser = await Puppeteer.LaunchAsync(launchOptions);
            try {
                var page = await browser.NewPageAsync();
                try {
                    NavigationOptions navigationOptions = new NavigationOptions() {
                        Timeout = 0
                    };

                    string originalUserAgent = await browser.GetUserAgentAsync();
                    await page.SetUserAgentAsync($"{originalUserAgent} {USER_AGENT_SUFFIX}");

                    if (cookies.Any()) {
                        await page.SetCookieAsync(cookies.ToArray());
                    }

                    await page.GoToAsync(url, navigationOptions);
                    return await page.ScreenshotDataAsync(options);
                } finally {
                    await Cleanup(page);
                }
            } finally {
                Cleanup(browser);
            }
        }

        public bool UserAgentMatches(string userAgent) {
            return userAgent.EndsWith($" {USER_AGENT_SUFFIX}");
        }

        private async Task Cleanup(Page page) {
            await page.CloseAsync();
        }

        private void Cleanup(PuppeteerSharp.Browser browser) {
            browser.Disconnect();
            Dispose();
        }

        public void Dispose() {
            if (browser != null) {
                ProcessUtils.KillProcessTree(browser.Process);
            }
        }


    }
}