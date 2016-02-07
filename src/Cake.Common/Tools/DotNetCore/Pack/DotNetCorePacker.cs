﻿using Cake.Core;
using Cake.Core.IO;
using System;

namespace Cake.Common.Tools.DotNetCore.Pack
{
    /// <summary>
    /// .NET Core project packer.
    /// </summary>
    public class DotNetCorePacker : DotNetCoreTool<DotNetCorePackSettings>
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="DotNetCorePacker" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="globber">The globber.</param>
        public DotNetCorePacker(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IGlobber globber)
            : base(fileSystem, environment, processRunner, globber)
        {
            _environment = environment;
        }

        /// <summary>
        /// Pack the project using the specified path and settings.
        /// </summary>
        /// <param name="path">The target file path.</param>
        /// <param name="settings">The settings.</param>
        public void Pack(string path, DotNetCorePackSettings settings)
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

        private ProcessArgumentBuilder GetArguments(string path, DotNetCorePackSettings settings)
        {
            var builder = CreateArgumentBuilder(settings);

            builder.Append("pack");

            // Specific path?
            if (path != null)
            {
                builder.AppendQuoted(path);
            }

            // Output directory
            if (settings.BasePath != null)
            {
                builder.Append("--basepath");
                builder.AppendQuoted(settings.BasePath.MakeAbsolute(_environment).FullPath);
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

            // Configuration
            if (!string.IsNullOrEmpty(settings.Configuration))
            {
                builder.Append("--configuration");
                builder.Append(settings.Configuration);
            }

            // Version suffix
            if (!string.IsNullOrEmpty(settings.VersionSuffix))
            {
                builder.Append("--version-suffix");
                builder.Append(settings.VersionSuffix);
            }

            return builder;
        }
    }
}
