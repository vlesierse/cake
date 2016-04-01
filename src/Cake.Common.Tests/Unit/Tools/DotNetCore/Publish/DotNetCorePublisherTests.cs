﻿using Cake.Common.Tests.Fixtures.Tools.DotNetCore.Publish;
using Cake.Common.Tools.DotNetCore.Publish;
using Cake.Testing;
using Xunit;

namespace Cake.Common.Tests.Unit.Tools.DotNetCore.Publish
{
    public sealed class DotNetCorePublisherTests
    {
        public sealed class ThePublishMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                var fixture = new DotNetCorePublisherFixture();
                fixture.Settings = null;
                fixture.GivenDefaultToolDoNotExist();

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsArgumentNullException(result, "settings");
            }

            [Fact]
            public void Should_Throw_If_Process_Was_Not_Started()
            {
                // Given
                var fixture = new DotNetCorePublisherFixture();
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
                var fixture = new DotNetCorePublisherFixture();
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
                var fixture = new DotNetCorePublisherFixture();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("publish", result.Args);
            }

            [Fact]
            public void Should_Add_Path()
            {
                // Given
                var fixture = new DotNetCorePublisherFixture();
                fixture.Project = "./src/*";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("publish \"./src/*\"", result.Args);
            }

            [Fact]
            public void Should_Add_Settings()
            {
                // Given
                var fixture = new DotNetCorePublisherFixture();
                fixture.Settings.Framework = "dnxcore50";
                fixture.Settings.Configuration = "Release";
                fixture.Settings.Runtime = "runtime1";
                fixture.Settings.BuildBasePath = "./temp/";
                fixture.Settings.OutputDirectory = "./artifacts/";
                fixture.Settings.VersionSuffix = "rc1";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("publish --output \"/Working/artifacts\" --build-base-path \"/Working/temp\" --runtime runtime1 --framework dnxcore50 --configuration Release --version-suffix rc1", result.Args);
            }
        }
    }
}
