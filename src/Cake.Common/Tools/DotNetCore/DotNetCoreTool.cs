using System;
using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Common.Tools.DotNetCore
{
    /// <summary>
    /// Base class for all .NET Core related tools
    /// </summary>
    /// <typeparam name="TSettings">The settings type</typeparam>
    public abstract class DotNetCoreTool<TSettings> : Tool<TSettings>
        where TSettings : DotNetCoreSettings
    {
        private readonly ICakeEnvironment _environment;
        private readonly IFileSystem _fileSystem;

        /// <summary>
        /// Initializes a new instance of the <see cref="DotNetCoreTool{TSettings}" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="globber">The globber.</param>
        protected DotNetCoreTool(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IGlobber globber)
            : base(fileSystem, environment, processRunner, globber)
        {
            _fileSystem = fileSystem;
            _environment = environment;
        }

        /// <summary>
        /// Gets the name of the tool.
        /// </summary>
        /// <returns>The name of the tool.</returns>
        protected override string GetToolName()
        {
            return "DotNetCore";
        }

        /// <summary>
        /// Gets the possible names of the tool executable.
        /// </summary>
        /// <returns>The tool executable name.</returns>
        protected override IEnumerable<string> GetToolExecutableNames()
        {
            return new[] { "dotnet", "dotnet.exe" };
        }

        /// <summary>
        /// Creates a <see cref="ProcessArgumentBuilder"/> and adds common commandline arguments.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>Instance of <see cref="ProcessArgumentBuilder"/>.</returns>
        protected ProcessArgumentBuilder CreateArgumentBuilder(TSettings settings)
        {
            var builder = new ProcessArgumentBuilder();

            if (settings.Verbose)
            {
                builder.Append("--verbose");
            }

            return builder;
        }

        /// <summary>
        /// Gets alternative file paths which the tool may exist in
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The default tool path.</returns>
        protected override IEnumerable<FilePath> GetAlternativeToolPaths(TSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            var path = DotNetCoreResolver.GetDotNetCorePath(_fileSystem, _environment);

            if (path != null)
            {
                return new[] { path };
            }

            return Enumerable.Empty<FilePath>();
        }
    }
}
