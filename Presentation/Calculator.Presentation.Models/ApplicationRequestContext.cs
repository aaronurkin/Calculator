namespace Calculator.Presentation.Models
{
    public class ApplicationRequestContext
    {
        public string Platrofm { get; set; }

        public string PlatformVersion { get; set; }

        public string PlatformApplicationVersion { get; set; }

        // TODO: Possible must be moved to separate service
        public string ServiceName
        {
            get
            {
                var platformVersion = string.IsNullOrEmpty(this.PlatformVersion)
                    ? string.Empty :
                    $"_{this.PlatformVersion}";

                return $"{this.Platrofm}{platformVersion}_{this.PlatformApplicationVersion}".ToUpperInvariant();
            }
        }
    }
}
