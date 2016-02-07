namespace Cake.Common.Tools.DotNetCore.Build
{
    /// <summary>
    /// Contains the architecture for which to compile. Used by <see cref="DotNetCoreBuildSettings"/>.
    /// </summary>
    public enum DotNetCoreArchitecture
    {
        /// <summary>
        /// X64 Architecture.
        /// </summary>
        x64,
        /// <summary>
        /// X86 Arhictecture.
        /// </summary>
        /// <remarks>
        /// Currently not supported.
        /// </remarks>
        x86
    }
}
