﻿using System.Collections.Generic;
using Cake.Core.Configuration;
using Cake.Testing;

namespace Cake.Core.Tests.Fixtures
{
    internal sealed class CakeConfigurationProviderFixture
    {
        public FakeFileSystem FileSystem { get; set; }
        public FakeEnvironment Environment { get; set; }
        public IDictionary<string, string> Arguments { get; set; }

        public CakeConfigurationProviderFixture()
        {
            Environment = FakeEnvironment.CreateUnixEnvironment();
            FileSystem = new FakeFileSystem(Environment);
            Arguments = new Dictionary<string, string>();
        }

        public ICakeConfiguration Create()
        {
            var provider = new CakeConfigurationProvider(FileSystem, Environment);
            return provider.CreateConfiguration(Arguments);
        }
    }
}
