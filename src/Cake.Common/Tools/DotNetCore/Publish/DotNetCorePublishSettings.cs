using Cake.Core.IO;

namespace Cake.Common.Tools.DotNetCore.Publish
{
    /// <summary>
    /// Contains settings used by <see cref="DotNetCorePublisher" />.
    /// </summary>
    public class DotNetCorePublishSettings : DotNetCoreSettings
    {
        /// <summary>
        /// Gets or sets the output directory.
        /// </summary>
        public DirectoryPath OutputDirectory { get; set; }

        /// <summary>
        /// Gets or sets the target runtime.
        /// </summary>
        public string Runtime { get; set; }

        /// <summary>
        /// Gets or sets a specific framework to compile.
        /// </summary>
        public string Framework { get; set; }

        /// <summary>
        /// Gets or sets the configuration under which to build.
        /// </summary>
        public string Configuration { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to enable a temporary mechanism to include subdirectories
        /// from native assets of dependency packages in output.
        /// </summary>
        public bool NativeSubDirectory { get; set; }
    }
}
