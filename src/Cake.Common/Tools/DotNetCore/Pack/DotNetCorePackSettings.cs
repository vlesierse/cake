using Cake.Core.IO;

namespace Cake.Common.Tools.DotNetCore.Pack
{
    public class DotNetCorePackSettings : DotNetCoreSettings
    {
        public DirectoryPath BasePath { get; set; }

        public DirectoryPath OutputDirectory { get; set; }

        public DirectoryPath TemporaryOutputDirectory { get; set; }

        public string Configuration { get; set; }

        public string VersionSuffix { get; set; }
    }
}
