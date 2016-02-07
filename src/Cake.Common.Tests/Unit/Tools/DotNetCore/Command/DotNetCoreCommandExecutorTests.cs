using Cake.Common.Tests.Fixtures.Tools.DotNetCore.Command;
using Cake.Common.Tools.DotNetCore;
using Cake.Common.Tools.DotNetCore.Command;
using Cake.Testing;
using Xunit;

namespace Cake.Common.Tests.Unit.Tools.DotNetCore.Build
{
    public sealed class DotNetCoreCommandExecutorTests
    {
        public sealed class TheBuildMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                var fixture = new DotNetCoreCommandExecutorFixture();
                fixture.Path = "./src/*";
                fixture.Command = "command";
                fixture.Arguments = "--args";
                fixture.Settings = null;
                fixture.GivenDefaultToolDoNotExist();

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsArgumentNullException(result, "settings");
            }

            [Fact]
            public void Should_Throw_If_DotNet_Executable_Was_Not_Found()
            {
                // Given
                var fixture = new DotNetCoreCommandExecutorFixture();
                fixture.Path = "./src/*";
                fixture.Command = "command";
                fixture.Arguments = "--args";
                fixture.Settings = new DotNetCoreSettings();
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
                var fixture = new DotNetCoreCommandExecutorFixture();
                fixture.Path = "./src/*";
                fixture.Command = "command";
                fixture.Arguments = "--args";
                fixture.Settings = new DotNetCoreSettings();
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
                var fixture = new DotNetCoreCommandExecutorFixture();
                fixture.Path = "./src/*";
                fixture.Command = "command";
                fixture.Arguments = "--args";
                fixture.Settings = new DotNetCoreSettings();
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
                var fixture = new DotNetCoreCommandExecutorFixture();
                fixture.Command = "command";
                fixture.Settings = new DotNetCoreSettings();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("command", result.Args);
            }
        }
    }
}
