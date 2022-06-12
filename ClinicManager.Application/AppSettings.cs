namespace ClinicManager.Application
{
    public class AppSettings
    {
        public string Version { get; set; }
        public string Build { get; set; }
        public string Secret { get; set; }

        public string DisplayBuildVersion => $"Version: {Version} | Build: {Build}";
    }
}
