﻿using Cake.Common.Tools.DotNetCore.Publish;

namespace Cake.Common.Tests.Fixtures.Tools.DotNetCore.Publish
{
    internal sealed class DotNetCorePublisherFixture : DotNetCoreFixture<DotNetCorePublishSettings>
    {
        public string Path { get; set; }

        protected override void RunTool()
        {
            var tool = new DotNetCorePublisher(FileSystem, Environment, ProcessRunner, Globber);
            tool.Publish(Path, Settings);
        }
    }
}
