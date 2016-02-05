using Cake.Core;
using Cake.Core.IO;
using System;

namespace Cake.Common.Tools.DotNetCore.Build
{
    /// <summary>
    /// .NET Core project builder.
    /// </summary>
    public class DotNetCoreBuilder : DotNetCoreTool<DotNetCoreBuildSettings>
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="DotNetCoreBuilder" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="globber">The globber.</param>
        public DotNetCoreBuilder(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IGlobber globber)
            : base(fileSystem, environment, processRunner, globber)
        {
            _environment = environment;
        }

        /// <summary>
        /// Build the project using the specified path and settings.
        /// </summary>
        /// <param name="path">The target file path.</param>
        /// <param name="settings">The settings.</param>
        public void Build(string path, DotNetCoreBuildSettings settings)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }

            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            Run(settings, GetArguments(path, settings));
        }

        private ProcessArgumentBuilder GetArguments(string path, DotNetCoreBuildSettings settings)
        {
            var builder = CreateArgumentBuilder(settings);

            builder.Append("build");

            // Specific path?
            if (path != null)
            {
                builder.AppendQuoted(path);
            }

            // Output directory
            if (settings.OutputDirectory != null)
            {
                builder.Append("--output");
                builder.AppendQuoted(settings.OutputDirectory.MakeAbsolute(_environment).FullPath);
            }

            // Temporary output directory
            if (settings.TemporaryOutputDirectory != null)
            {
                builder.Append("--temp-output");
                builder.AppendQuoted(settings.TemporaryOutputDirectory.MakeAbsolute(_environment).FullPath);
            }

            // Runtime
            if (!string.IsNullOrEmpty(settings.Runtime))
            {
                builder.Append("--runtime");
                builder.Append(settings.Runtime);
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

            // Architecture
            if (settings.Architecture.HasValue)
            {
                builder.Append("--arch");
                builder.Append(settings.Architecture.Value.ToString());
            }

            // Native
            if (settings.Native)
            {
                builder.Append("--native");
            }

            return builder;
        }
    }
}
