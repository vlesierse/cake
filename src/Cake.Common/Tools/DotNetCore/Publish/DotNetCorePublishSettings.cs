using Cake.Core.IO;

namespace Cake.Common.Tools.DotNetCore.Publish
{
    public class DotNetCorePublishSettings : DotNetCoreSettings
    {
        /// <summary>
        /// Gets or sets the output directory.
        /// </summary>
        public DirectoryPath OutputDirectory { get; set; }

        public string Runtime { get; set; }

        public string Framework { get; set; }

        public string Configuration { get; set; }

        public bool NativeSubDirectory { get; set; }
    }
}
