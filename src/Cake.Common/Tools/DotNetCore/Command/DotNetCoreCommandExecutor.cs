using System;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Common.Tools.DotNetCore.Command
{
    /// <summary>
    /// .NET Core CLI command executor.
    /// </summary>
    public class DotNetCoreCommandExecutor : DotNetCoreTool<DotNetCoreSettings>
    {
        internal void GivenDefaultToolDoNotExist()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DotNetCoreCommandExecutor" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="globber">The globber.</param>
        public DotNetCoreCommandExecutor(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IGlobber globber)
            : base(fileSystem, environment, processRunner, globber)
        {
        }

        /// <summary>
        /// Execute a command using the specified path, arguments and settings.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="command">The command.</param>
        /// <param name="arguments">The arguments.</param>
        /// <param name="settings">The settings.</param>
        public void Execute(string path, string command, string arguments, DotNetCoreSettings settings)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }
            
            Run(settings, GetArguments(path, command, arguments, settings));
        }

        private ProcessArgumentBuilder GetArguments(string path, string command, string arguments, DotNetCoreSettings settings)
        {
            var builder = CreateArgumentBuilder(settings);

            builder.Append(command);

            if (!string.IsNullOrEmpty(path))
            {
                builder.Append(path);
            }

            if (!string.IsNullOrEmpty(arguments))
            {
                builder.Append(arguments);
            }

            return builder;
        }
    }
}
