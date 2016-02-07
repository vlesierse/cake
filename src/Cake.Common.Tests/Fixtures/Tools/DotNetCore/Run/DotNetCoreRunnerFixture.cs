﻿using Cake.Common.Tools.DotNetCore.Run;

namespace Cake.Common.Tests.Fixtures.Tools.DotNetCore.Run
{
    internal sealed class DotNetCoreRunnerFixture : DotNetCoreFixture<DotNetCoreRunSettings>
    {
        public string Path { get; set; }

        protected override void RunTool()
        {
            var tool = new DotNetCoreRunner(FileSystem, Environment, ProcessRunner, Globber);
            tool.Run(Path, Settings);
        }
    }
}