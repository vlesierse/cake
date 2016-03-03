using Cake.Core.IO;

namespace Cake.Common.Tools.DotNetCore.Test
{
    /// <summary>
    /// Contains settings used by <see cref="DotNetCoreTester" />.
    /// </summary>
    public class DotNetCoreTestSettings : DotNetCoreSettings
    {
        /// <summary>
        /// Gets or sets the configuration under which to build.
        /// </summary>
        public string Configuration { get; set; }

        /// <summary>
        /// Gets or sets the output directory.
        /// </summary>
        public DirectoryPath OutputDirectory { get; set; }
    }
}
