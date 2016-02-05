using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Common.Tools.DotNetCore.Build
{
    /// <summary>
    /// Contains settings used by <see cref="DotNetCoreBuilder" />.
    /// </summary>
    public class DotNetCoreBuildSettings : DotNetCoreSettings
    {
        /// <summary>
        /// Gets or sets the output directory.
        /// </summary>
        public DirectoryPath OutputDirectory { get; set; }

        /// <summary>
        /// Gets or sets the temporary output directory.
        /// </summary>
        public DirectoryPath TemporaryOutputDirectory { get; set; }

        public string Runtime { get; set; }

        public string Framework { get; set; }

        public string Configuration { get; set; }

        public DotNetCoreArchitecture? Architecture { get; set; }

        public bool Native { get; set; }
    }
}
