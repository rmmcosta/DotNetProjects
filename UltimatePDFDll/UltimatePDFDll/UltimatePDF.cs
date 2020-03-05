using OutSystems.NssUltimatePDF.Browser;
using OutSystems.NssUltimatePDF.Session;
using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace UltimatePDF
{
    public class UltimatePDF
    {
        private static readonly object browserSetupLock = new object();

        public void MssSetupLocalBrowser(int ssBrowserRevision)
        {
            RevisionInfo revision = BrowserUtils.RevisionInfo(ssBrowserRevision);

            /*
             * Avoid two concurrent requests setting up the browser at the same time,
             * which could cause clashes in the filesystem and file corruption.
             */
            lock (browserSetupLock)
            {
                RunAsync(() => BrowserUtils.DownloadRevision(revision));
            }
        }

        public void MssSetupLocalBrowserFromZip(int ssBrowserRevision, byte[] ssZip)
        {
            RevisionInfo revision = BrowserUtils.RevisionInfo(ssBrowserRevision);

            /*
             * Avoid two concurrent requests setting up the browser at the same time,
             * which could cause clashes in the filesystem and file corruption.
             */
            lock (browserSetupLock)
            {
                BrowserUtils.ExtractRevision(revision, ssZip);
            }
        }

        public void MssGetDefaultBrowserRevision(out int ssBrowserRevision)
        {
            ssBrowserRevision = BrowserFetcher.DefaultRevision;
        }


        public void MssKillLocalBrowsers(DateTime ssThresholdDateTime)
        {
            // If by any chance a chrome process if left alive, this makes sure we can still kill it
            var localBrowsers = Process.GetProcessesByName("chrome");
            foreach (var browser in localBrowsers)
            {
                try
                {
                    if (browser.StartTime < ssThresholdDateTime)
                    {
                        ProcessUtils.KillProcessTree(browser);
                    }
                }
                catch
                {
                    /*
                     * Could happen if a different user has a chrome browser open,
                     * we wouldn't have privileges to read the start time nor to kill it.
                     */
                }
            }
        }


        public void MssPrintPDF(string ssURL, int ssBrowserRevision, bool ssReuseSession, out byte[] ssPDF)
        {
            using (var puppeteer = new BrowserUtils())
            {
                RevisionInfo revision = BrowserUtils.RevisionInfo(ssBrowserRevision);
                ViewPortOptions viewport = new ViewPortOptions()
                {
                    Width = 1366,
                    Height = 768
                };
                PdfOptions options = new PdfOptions()
                {
                    PrintBackground = true,
                    PreferCSSPageSize = true
                };

                bool ssUseCustomPaper = false;
                decimal ssWidth = 0;
                decimal ssHeight = 0;
                bool ssUseCustomMargins = false;
                decimal ssMarginTop = 0;
                decimal ssMarginRight = 0;
                decimal ssMarginBottom = 0;
                decimal ssMarginLeft = 0;

                if (ssUseCustomPaper && ssWidth > 0 && ssHeight > 0)
                {
                    options.Width = $"{ssWidth}cm";
                    options.Height = $"{ssHeight}cm";
                    options.PreferCSSPageSize = false;
                }

                if (ssUseCustomMargins && ssMarginTop >= 0 && ssMarginRight >= 0 && ssMarginBottom >= 0 && ssMarginLeft >= 0)
                {
                    options.MarginOptions.Top = $"{ssMarginTop}cm";
                    options.MarginOptions.Right = $"{ssMarginRight}cm";
                    options.MarginOptions.Bottom = $"{ssMarginBottom}cm";
                    options.MarginOptions.Left = $"{ssMarginLeft}cm";
                }

                List<CookieParam> cookies = new List<CookieParam>();
                if (ssReuseSession)
                {
                    var sessionUtils = new SessionUtils();

                    foreach (var sessionReactiveCookie in sessionUtils.SessionCookies)
                    {
                        cookies.AddRange(sessionReactiveCookie.Select(cookie => new CookieParam()
                        {
                            Name = cookie.Name,
                            Value = cookie.Value,
                            Path = cookie.Path,
                            Domain = new Uri(ssURL).Host,
                            HttpOnly = cookie.HttpOnly
                        }));
                    }

                }
                //GenericExtendedActions.LogMessage(AppInfo.GetAppInfo().OsContext, "Log successful", "PrintPDF");
                ssPDF = RunAsync(() => puppeteer.PrintPDF(ssURL, cookies, viewport, options, revision));
            }
        }


        /* Runs async code with default scheduler and waits for the result */
        private void RunAsync(Func<Task> @async)
        {
            TaskFactory tf = new TaskFactory(CancellationToken.None, TaskCreationOptions.None, TaskContinuationOptions.None, TaskScheduler.Default);
            Task<Task> task = tf.StartNew(@async);
            task.Unwrap().GetAwaiter().GetResult();
        }

        /* Runs async code with default scheduler and waits for the result */
        private T RunAsync<T>(Func<Task<T>> @async)
        {
            TaskFactory tf = new TaskFactory(CancellationToken.None, TaskCreationOptions.None, TaskContinuationOptions.None, TaskScheduler.Default);
            Task<Task<T>> task = tf.StartNew(@async);
            return task.Unwrap().GetAwaiter().GetResult();
        }
    }
}
