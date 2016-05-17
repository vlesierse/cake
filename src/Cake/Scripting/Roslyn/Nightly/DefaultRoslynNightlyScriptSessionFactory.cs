﻿using Cake.Core;
using Cake.Core.Configuration;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Scripting;

namespace Cake.Scripting.Roslyn.Nightly
{
    internal sealed class DefaultRoslynNightlyScriptSessionFactory : RoslynNightlyScriptSessionFactory
    {
        public DefaultRoslynNightlyScriptSessionFactory(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            ICakeConfiguration configuration,
            IGlobber globber,
            ICakeLog log) : base(fileSystem, environment, configuration, globber, log)
        {
        }

        protected override IScriptSession CreateSession(IScriptHost host, ICakeLog log)
        {
            // Create the session.
            return new DefaultRoslynNightlyScriptSession(host, log);
        }
    }
}