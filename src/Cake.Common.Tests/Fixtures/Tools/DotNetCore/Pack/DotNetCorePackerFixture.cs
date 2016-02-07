using Cake.Common.Tools.DotNetCore.Pack;

namespace Cake.Common.Tests.Fixtures.Tools.DotNetCore.Pack
{
    internal sealed class DotNetCorePublishFixture : DotNetCoreFixture<DotNetCorePackSettings>
    {
        public string Path { get; set; }

        protected override void RunTool()
        {
            var tool = new DotNetCorePacker(FileSystem, Environment, ProcessRunner, Globber);
            tool.Pack(Path, Settings);
        }
    }
}
