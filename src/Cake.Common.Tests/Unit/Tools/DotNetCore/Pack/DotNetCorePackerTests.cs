using Cake.Common.Tests.Fixtures.Tools.DotNetCore.Pack;
using Cake.Common.Tools.DotNetCore.Pack;
using Cake.Testing;
using Xunit;

namespace Cake.Common.Tests.Unit.Tools.DotNetCore.Pack
{
    public sealed class DotNetCorePackerTests
    {
        public sealed class ThePackMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                var fixture = new DotNetCorePublishFixture();
                fixture.Path = "./src/*";
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
                var fixture = new DotNetCorePublishFixture();
                fixture.Settings = new DotNetCorePackSettings();
                fixture.GivenDefaultToolDoNotExist();

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsArgumentNullException(result, "path");
            }

            [Fact]
            public void Should_Throw_If_DotNet_Executable_Was_Not_Found()
            {
                // Given
                var fixture = new DotNetCorePublishFixture();
                fixture.Path = "./src/*";
                fixture.GivenDefaultToolDoNotExist();

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsCakeException(result, "DotNetCore: Could not locate executable.");
            }

            [Fact]
            public void Should_Throw_If_Process_Was_Not_Started()
            {
                // Given
                var fixture = new DotNetCorePublishFixture();
                fixture.Path = "./src/*";
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
                var fixture = new DotNetCorePublishFixture();
                fixture.Path = "./src/*";
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
                var fixture = new DotNetCorePublishFixture();
                fixture.Path = "./src/*";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("pack \"./src/*\"", result.Args);
            }
        }
    }
}
