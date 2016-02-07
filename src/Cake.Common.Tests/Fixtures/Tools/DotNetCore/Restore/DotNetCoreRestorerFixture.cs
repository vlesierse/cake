using Cake.Common.Tools.DotNetCore.Restore;

namespace Cake.Common.Tests.Fixtures.Tools.DotNetCore.Restore
{
    internal sealed class DotNetCoreRestorerFixture : DotNetCoreFixture<DotNetCoreRestoreSettings>
    {
        public string Path { get; set; }

        protected override void RunTool()
        {
            var tool = new DotNetCoreRestorer(FileSystem, Environment, ProcessRunner, Globber);
            tool.Restore(Path, Settings);
        }
    }
}
