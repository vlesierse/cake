using Cake.Core.IO;

namespace Cake.Common.Tools.DotNetCore.Pack
{
    /// <summary>
    /// Contains settings used by <see cref="DotNetCorePacker" />.
    /// </summary>
    public class DotNetCorePackSettings : DotNetCoreSettings
    {
        /// <summary>
        /// Gets or sets the base path.
        /// </summary>
        public DirectoryPath BasePath { get; set; }

        /// <summary>
        /// Gets or sets the output directory.
        /// </summary>
        public DirectoryPath OutputDirectory { get; set; }

        /// <summary>
        /// Gets or sets the temporary output directory.
        /// </summary>
        public DirectoryPath TemporaryOutputDirectory { get; set; }

        /// <summary>
        /// Gets or sets the configuration under which to build.
        /// </summary>
        public string Configuration { get; set; }

        /// <summary>
        /// Gets or sets the value that defines what `*` should be replaced with in version field in project.json.
        /// </summary>
        public string VersionSuffix { get; set; }
    }
}
