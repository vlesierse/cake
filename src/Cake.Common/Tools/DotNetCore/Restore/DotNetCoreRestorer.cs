using System;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Common.Tools.DotNetCore.Restore
{
    /// <summary>
    /// .NET Core project restorer.
    /// </summary>
    public class DotNetCoreRestorer : DotNetCoreTool<DotNetCoreRestoreSettings>
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="DotNetCoreRestorer" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="globber">The globber.</param>
        public DotNetCoreRestorer(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IGlobber globber)
            : base(fileSystem, environment, processRunner, globber)
        {
            _environment = environment;
        }

        /// <summary>
        /// Restore the project using the specified path and settings.
        /// </summary>
        /// <param name="path">The target file path.</param>
        /// <param name="settings">The settings.</param>
        public void Restore(string path, DotNetCoreRestoreSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            Run(settings, GetArguments(path, settings));
        }

        private ProcessArgumentBuilder GetArguments(string path, DotNetCoreRestoreSettings settings)
        {
            var builder = CreateArgumentBuilder(settings);

            builder.Append("restore");

            // Specific path?
            if (path != null)
            {
                builder.Append(path);
            }

            // Output directory
            if (settings.PackagesDirectory != null)
            {
                builder.Append("--packages");
                builder.AppendQuoted(settings.PackagesDirectory.MakeAbsolute(_environment).FullPath);
            }

            // Source
            if (!string.IsNullOrEmpty(settings.Source))
            {
                builder.Append("--source");
                builder.Append(settings.Source);
            }

            // List of fallback package sources
            if (settings.FallbackSources != null && settings.FallbackSources.Count > 0)
            {
                builder.Append("--fallbacksource");
                builder.AppendQuoted(string.Join(";", settings.FallbackSources));
            }

            // List of runtime identifiers
            if (settings.Runtimes != null && settings.Runtimes.Count > 0)
            {
                builder.Append("--runtime");
                builder.AppendQuoted(string.Join(";", settings.Runtimes));
            }

            // Quiet
            if (settings.Quiet)
            {
                builder.Append("--quiet");
            }

            // Disable parallel
            if (settings.DisableParallel)
            {
                builder.Append("--disable-parallel");
            }

            // Verbosity
            if (settings.Verbosity.HasValue)
            {
                builder.Append("--verbosity");
                builder.Append(settings.Verbosity.ToString());
            }

            return builder;
        }
    }
}
