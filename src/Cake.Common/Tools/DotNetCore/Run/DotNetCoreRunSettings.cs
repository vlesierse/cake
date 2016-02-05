namespace Cake.Common.Tools.DotNetCore.Run
{
    public class DotNetCoreRunSettings : DotNetCoreSettings
    {
        public string Framework { get; set; }

        public string Configuration { get; set; }

        public bool PreserveTemporary { get; set; }
    }
}
