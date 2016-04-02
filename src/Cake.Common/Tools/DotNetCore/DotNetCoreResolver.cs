using System.Diagnostics;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Common.Tools.DotNetCore
{
    internal static class DotNetCoreResolver
    {
        private static ICakeEnvironment _environment;

        public static FilePath GetDotNetCorePath(ICakeEnvironment environment)
        {
            _environment = environment;

            if (_environment.IsUnix())
            {
                return GetWhichDotNet();
            }
            else
            {
                return GetWhereDotNet();
            }
        }

        private static FilePath GetWhichDotNet()
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "/usr/bin/which",
                Arguments = "dotnet",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            string which;
            using (var process = new Process { StartInfo = startInfo })
            {
                process.Start();
                which = process.StandardOutput.ReadToEnd();
            }

            return string.IsNullOrEmpty(which) ? null : new FilePath(which.Trim());
        }

        private static FilePath GetWhereDotNet()
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "where",
                Arguments = "dotnet",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            string path;
            using (var process = new Process { StartInfo = startInfo })
            {
                process.Start();
                path = process.StandardOutput.ReadToEnd();
            }

            return string.IsNullOrEmpty(path) ? null : new FilePath(path.Trim());
        }
    }
}