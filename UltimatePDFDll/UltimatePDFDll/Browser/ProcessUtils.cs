using System;
using System.Diagnostics;
using System.Management;

namespace OutSystems.NssUltimatePDF.Browser
{

    public static class ProcessUtils {

        public static void KillProcessTree(Process root) {
            using (var mo = new ManagementObjectSearcher($"SELECT Handle FROM win32_process WHERE ParentProcessId={root.Id}")) {
                var enumerator = mo.Get().GetEnumerator();
                while (enumerator.MoveNext()) {
                    var pid = Convert.ToInt32(enumerator.Current.GetPropertyValue("Handle"));
                    try {
                        var p = Process.GetProcessById(pid);

                        KillProcessTree(p);
                    } catch {
                        // Could happen if the process has already died
                    }
                }
            }

            try {
                root.Kill();
            } catch {
                // Could happen if the process has already died
            }
        }

    }
}
