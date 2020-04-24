using System.Linq;

namespace edusent_service.Helpers
{
    public class DatabaseConfig
    {
        public string Connection { get; set; }
    }

    public class CorsConfig
    {
        public string FrontendDomain { get; set; }
        public string SecondDomain { get; set; }
        public string[] AllowedDomains { get; set; } = new string[0];

        public string[] AllDomains => AllowedDomains.Append(FrontendDomain).Append(SecondDomain).ToArray();
    }

}