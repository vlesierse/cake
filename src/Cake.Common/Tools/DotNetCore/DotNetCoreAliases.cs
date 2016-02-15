using System;
using Cake.Common.Tools.DotNetCore.Build;
using Cake.Common.Tools.DotNetCore.Command;
using Cake.Common.Tools.DotNetCore.Pack;
using Cake.Common.Tools.DotNetCore.Publish;
using Cake.Common.Tools.DotNetCore.Restore;
using Cake.Common.Tools.DotNetCore.Run;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Common.Tools.DotNetCore
{
    /// <summary>
    /// Contains functionality for working with the .NET Core CLI.
    /// </summary>
    [CakeAliasCategory("DotNetCore")]
    public static class DotNetCoreAliases
    {
        /// <summary>
        /// Execute a command.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="command">The command.</param>
        /// <example>
        /// <code>
        ///     DotNetCore("test");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Command")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Command")]
        public static void DotNetCore(this ICakeContext context, string command)
        {
            context.DotNetCore(null, command, null, null);
        }

        /// <summary>
        /// Execute a command with arguments.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="command">The command.</param>
        /// <param name="arguments">The arguments.</param>
        /// <example>
        /// <code>
        ///     DotNetCore("test", "--args");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Command")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Command")]
        public static void DotNetCore(this ICakeContext context, string command, string arguments)
        {
            context.DotNetCore(null, command, arguments, null);
        }

        /// <summary>
        /// Execute a command with arguments in the specific path.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The projects path.</param>
        /// <param name="command">The command.</param>
        /// <param name="arguments">The arguments.</param>
        /// <example>
        /// <code>
        ///     DotNetCore("./test/*", "test", "--arg");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Command")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Command")]
        public static void DotNetCore(this ICakeContext context, string path, string command, string arguments)
        {
            context.DotNetCore(path, command, arguments, null);
        }

        /// <summary>
        /// Execute a command with arguments in the specific path with settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The projects path.</param>
        /// <param name="command">The command.</param>
        /// <param name="arguments">The arguments.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        ///     var settings = new DotNetCoreSettings
        ///     {
        ///         Verbose = true
        ///     };
        ///
        ///     DotNetCore("./src/*", "test", "--arg", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Command")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Command")]
        public static void DotNetCore(this ICakeContext context, string path, string command, string arguments, DotNetCoreSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (settings == null)
            {
                settings = new DotNetCoreSettings();
            }

            var restorer = new DotNetCoreCommandExecutor(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            restorer.Execute(path, command, arguments, settings);
        }

        /// <summary>
        /// Restore all NuGet Packages.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <example>
        /// <code>
        ///     DotNetCoreRestore();
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Restore")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Restore")]
        public static void DotNetCoreRestore(this ICakeContext context)
        {
            context.DotNetCoreRestore(null, null);
        }

        /// <summary>
        /// Restore all NuGet Packages in the specified path.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The project path restore.</param>
        /// <example>
        /// <code>
        ///     DotNetCoreRestore("./src/*");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Restore")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Restore")]
        public static void DotNetCoreRestore(this ICakeContext context, string path)
        {
            context.DotNetCoreRestore(path, null);
        }

        /// <summary>
        /// Restore all NuGet Packages with the settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        ///     var settings = new DotNetCoreRestoreSettings
        ///     {
        ///         Sources = new[] {"https://www.example.com/nugetfeed", "https://www.example.com/nugetfeed2"},
        ///         FallbackSources = new[] {"https://www.example.com/fallbacknugetfeed"},
        ///         Packages = "./packages",
        ///         Verbosity = Information,
        ///         DisableParallel = true,
        ///         Runtimes = new[] {"runtime1", "runtime2"}
        ///     };
        ///
        ///     DotNetCoreRestore(settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Restore")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Restore")]
        public static void DotNetCoreRestore(this ICakeContext context, DotNetCoreRestoreSettings settings)
        {
            context.DotNetCoreRestore(null, settings);
        }

        /// <summary>
        /// Restore all NuGet Packages in the specified path with settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The project path to restore.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        ///     var settings = new DotNetCoreRestoreSettings
        ///     {
        ///         Sources = new[] {"https://www.example.com/nugetfeed", "https://www.example.com/nugetfeed2"},
        ///         FallbackSources = new[] {"https://www.example.com/fallbacknugetfeed"},
        ///         Packages = "./packages",
        ///         Verbosity = Information,
        ///         DisableParallel = true,
        ///         Runtimes = new[] {"runtime1", "runtime2"}
        ///     };
        ///
        ///     DotNetCoreRestore("./src/*", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Restore")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Restore")]
        public static void DotNetCoreRestore(this ICakeContext context, string path, DotNetCoreRestoreSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (settings == null)
            {
                settings = new DotNetCoreRestoreSettings();
            }

            var restorer = new DotNetCoreRestorer(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            restorer.Restore(path, settings);
        }

        /// <summary>
        /// Build all projects.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The projects path.</param>
        /// <example>
        /// <code>
        ///     DotNetCoreBuild("./src/*");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Build")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Build")]
        public static void DotNetCoreBuild(this ICakeContext context, string path)
        {
            context.DotNetCoreBuild(path, null);
        }

        /// <summary>
        /// Build all projects.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The projects path.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        ///     var settings = new DotNetCoreBuildSettings
        ///     {
        ///         Frameworks = new[] { "net451", "dnxcore50" },
        ///         Configuration = "Debug",
        ///         OutputDirectory = "./artifacts/"
        ///     };
        ///
        ///     DotNetCoreBuild("./src/*", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Build")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Build")]
        public static void DotNetCoreBuild(this ICakeContext context, string path, DotNetCoreBuildSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (settings == null)
            {
                settings = new DotNetCoreBuildSettings();
            }

            var restorer = new DotNetCoreBuilder(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            restorer.Build(path, settings);
        }

        /// <summary>
        /// Package all projects.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The projects path.</param>
        /// <example>
        /// <code>
        ///     DotNetCorePack("./src/*");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Pack")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Pack")]
        public static void DotNetCorePack(this ICakeContext context, string path)
        {
            context.DotNetCorePack(path, null);
        }

        /// <summary>
        /// Package all projects.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The projects path.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        ///     var settings = new DotNetCorePackSettings
        ///     {
        ///         Frameworks = new[] { "dnx451", "dnxcore50" },
        ///         Configurations = new[] { "Debug", "Release" },
        ///         OutputDirectory = "./artifacts/"
        ///     };
        ///
        ///     DotNetCorePack("./src/*", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Pack")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Pack")]
        public static void DotNetCorePack(this ICakeContext context, string path, DotNetCorePackSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (settings == null)
            {
                settings = new DotNetCorePackSettings();
            }

            var restorer = new DotNetCorePacker(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            restorer.Pack(path, settings);
        }

        /// <summary>
        /// Run all projects.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <example>
        /// <code>
        ///     DotNetCoreRun();
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Run")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Run")]
        public static void DotNetCoreRun(this ICakeContext context)
        {
            context.DotNetCoreRun(null, null, null);
        }

        /// <summary>
        /// Run project.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The project path.</param>
        /// <example>
        /// <code>
        ///     DotNetCoreRun("./src/Project");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Run")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Run")]
        public static void DotNetCoreRun(this ICakeContext context, string path)
        {
            context.DotNetCoreRun(path, null, null);
        }

        /// <summary>
        /// Run project with path and arguments.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The project path.</param>
        /// <param name="arguments">The arguments.</param>
        /// <example>
        /// <code>
        ///     DotNetCoreRun("./src/Project", "--args");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Run")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Run")]
        public static void DotNetCoreRun(this ICakeContext context, string path, string arguments)
        {
            context.DotNetCoreRun(path, arguments, null);
        }

        /// <summary>
        /// Run project with settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The project path.</param>
        /// <param name="arguments">The arguments.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        ///     var settings = new DotNetCoreRunSettings
        ///     {
        ///         Framework = "dnxcore50",
        ///         Configuration = "Release"
        ///     };
        ///
        ///     DotNetCoreRun("./src/Project", "--args", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Run")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Run")]
        public static void DotNetCoreRun(this ICakeContext context, string path, string arguments, DotNetCoreRunSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (settings == null)
            {
                settings = new DotNetCoreRunSettings();
            }

            var restorer = new DotNetCoreRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            restorer.Run(path, arguments, settings);
        }

        /// <summary>
        /// Publish all projects.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The projects path.</param>
        /// <example>
        /// <code>
        ///     DotNetCorePublish("./src/*");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Publish")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Publish")]
        public static void DotNetCorePublish(this ICakeContext context, string path)
        {
            context.DotNetCorePublish(path, null);
        }

        /// <summary>
        /// Publish all projects.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The projects path.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        ///     var settings = new DotNetCorePublishSettings
        ///     {
        ///         Framework = "dnxcore50",
        ///         Configuration = "Release",
        ///         OutputDirectory = "./artifacts/"
        ///     };
        ///
        ///     DotNetCorePublish("./src/*", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Publish")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Publish")]
        public static void DotNetCorePublish(this ICakeContext context, string path, DotNetCorePublishSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (settings == null)
            {
                settings = new DotNetCorePublishSettings();
            }

            var restorer = new DotNetCorePublisher(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            restorer.Publish(path, settings);
        }
    }
}
