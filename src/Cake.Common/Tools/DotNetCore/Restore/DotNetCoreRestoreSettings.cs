using Cake.Core.IO;
using Cake.Core.Tooling;
using System.Collections.Generic;

namespace Cake.Common.Tools.DotNetCore.Restore
{
    /// <summary>
    /// Contains settings used by <see cref="DotNetCoreRestoreSettings" />.
    /// </summary>
    public class DotNetCoreRestoreSettings : DotNetCoreSettings
    {
        public string Source { get; set; }

        public DirectoryPath Packages { get; set; }

        public ICollection<string> Runtimes { get; set; }

        public ICollection<string> FallbackSources { get; set; }

        public bool DisableParallel { get; set; }

        public DotNetCoreRestoreVerbosity? Verbosity { get; set; }
    }
}
