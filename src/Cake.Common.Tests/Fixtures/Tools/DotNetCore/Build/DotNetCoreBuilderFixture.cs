﻿using Cake.Common.Tools.DotNetCore.Build;

namespace Cake.Common.Tests.Fixtures.Tools.DotNetCore.Build
{
    internal sealed class DotNetCoreBuilderFixture : DotNetCoreFixture<DotNetCoreBuildSettings>
    {
        public string Path { get; set; }

        protected override void RunTool()
        {
            var tool = new DotNetCoreBuilder(FileSystem, Environment, ProcessRunner, Globber);
            tool.Build(Path, Settings);
        }
    }
}
