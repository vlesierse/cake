using System;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Common.Tools.DotNetCore.Run
{
    /// <summary>
    /// .NET Core project runner.
    /// </summary>
    public class DotNetCoreRunner : DotNetCoreTool<DotNetCoreRunSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DotNetCoreRunner" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="globber">The globber.</param>
        public DotNetCoreRunner(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IGlobber globber)
            : base(fileSystem, environment, processRunner, globber)
        {
        }

        /// <summary>
        /// Runs the project using the specified path and settings.
        /// </summary>
        /// <param name="path">The target file path.</param>
        /// <param name="settings">The settings.</param>
        public void Run(string path, DotNetCoreRunSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            Run(settings, GetArguments(path, settings));
        }

        private ProcessArgumentBuilder GetArguments(string path, DotNetCoreRunSettings settings)
        {
            var builder = CreateArgumentBuilder(settings);

            builder.Append("run");

            // Specific path?
            if (path != null)
            {
                builder.Append("--project");
                builder.AppendQuoted(path);
            }

            // Framework
            if (!string.IsNullOrEmpty(settings.Framework))
            {
                builder.Append("--framework");
                builder.Append(settings.Framework);
            }

            // Configuration
            if (!string.IsNullOrEmpty(settings.Configuration))
            {
                builder.Append("--configuration");
                builder.Append(settings.Configuration);
            }

            if (settings.PreserveTemporary)
            {
                builder.Append("--preserve-temporary");
            }

            return builder;
        }
    }
}
