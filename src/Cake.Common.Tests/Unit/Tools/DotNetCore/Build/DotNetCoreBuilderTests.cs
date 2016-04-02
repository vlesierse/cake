﻿using Cake.Common.Tests.Fixtures.Tools.DotNetCore.Build;
using Cake.Common.Tools.DotNetCore.Build;
using Cake.Testing;
using Xunit;

namespace Cake.Common.Tests.Unit.Tools.DotNetCore.Build
{
    public sealed class DotNetCoreBuilderTests
    {
        public sealed class TheBuildMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                var fixture = new DotNetCoreBuilderFixture();
                fixture.Project = "./src/*";
                fixture.Settings = null;
                fixture.GivenDefaultToolDoNotExist();

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsArgumentNullException(result, "settings");
            }

            [Fact]
            public void Should_Throw_If_Path_Is_Null()
            {
                // Given
                var fixture = new DotNetCoreBuilderFixture();
                fixture.Settings = new DotNetCoreBuildSettings();
                fixture.GivenDefaultToolDoNotExist();

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsArgumentNullException(result, "path");
            }

            [Fact]
            public void Should_Throw_If_Process_Was_Not_Started()
            {
                // Given
                var fixture = new DotNetCoreBuilderFixture();
                fixture.Project = "./src/*";
                fixture.GivenProcessCannotStart();

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsCakeException(result, "DotNetCore: Process was not started.");
            }

            [Fact]
            public void Should_Throw_If_Process_Has_A_Non_Zero_Exit_Code()
            {
                // Given
                var fixture = new DotNetCoreBuilderFixture();
                fixture.Project = "./src/*";
                fixture.GivenProcessExitsWithCode(1);

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsCakeException(result, "DotNetCore: Process returned an error (exit code 1).");
            }

            [Fact]
            public void Should_Add_Mandatory_Arguments()
            {
                // Given
                var fixture = new DotNetCoreBuilderFixture();
                fixture.Project = "./src/*";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("build ./src/*", result.Args);
            }

            [Fact]
            public void Should_Add_Additional_Arguments()
            {
                // Given
                var fixture = new DotNetCoreBuilderFixture();
                fixture.Settings.Frameworks = new[] { "net451", "dnxcore50" };
                fixture.Settings.Runtime = "runtime1";
                fixture.Settings.Configuration = "Release";
                fixture.Settings.Architecture = DotNetCoreArchitecture.x64;
                fixture.Settings.VersionSuffix = "rc1";
                fixture.Project = "./src/*";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("build ./src/* --runtime runtime1 --framework \"net451;dnxcore50\" --configuration Release --arch x64 --version-suffix rc1", result.Args);
            }

            [Fact]
            public void Should_Add_Compiler_Arguments()
            {
                // Given
                var fixture = new DotNetCoreBuilderFixture();
                fixture.Settings.ILCompilerPath = "./compiler/csc.exe";
                fixture.Settings.ILCompilerArguments = "--args";
                fixture.Settings.ILCompilerSDKPath = "./compiler/";
                fixture.Settings.ApplicationDependencySDKPath = "./sdk/";
                fixture.Project = "./src/*";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("build ./src/*" +
                             " --ilcpath \"/Working/compiler/csc.exe\"" +
                             " --ilcargs \"--args\"" +
                             " --ilcsdkpath \"/Working/compiler\"" +
                             " --appdepsdkpath \"/Working/sdk\"", result.Args);
            }

            [Fact]
            public void Should_Add_Native_Arguments()
            {
                // Given
                var fixture = new DotNetCoreBuilderFixture();
                fixture.Settings.Native = true;
                fixture.Settings.Cpp = true;
                fixture.Settings.CppCompilerFlags = "FLAG=1";
                fixture.Project = "./src/*";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("build ./src/* --native --cpp --cppcompilerflags FLAG=1", result.Args);
            }

            [Fact]
            public void Should_Add_OutputPath_Arguments()
            {
                // Given
                var fixture = new DotNetCoreBuilderFixture();
                fixture.Settings.OutputDirectory = "./artifacts/";
                fixture.Project = "./src/*";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("build ./src/* --output \"/Working/artifacts\"", result.Args);
            }

            [Fact]
            public void Should_Add_Build_Arguments()
            {
                // Given
                var fixture = new DotNetCoreBuilderFixture();
                fixture.Settings.BuildBasePath = "./temp/";
                fixture.Settings.BuildProfile = true;
                fixture.Settings.NoIncremental = true;
                fixture.Settings.NoDependencies = true;
                fixture.Project = "./src/*";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("build ./src/* --build-base-path \"/Working/temp\" --build-profile --no-incremental --no-dependencies", result.Args);
            }
        }
    }
}
