using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateFw.Shared.Configuration
{
    public class WebSettings
    {
        public string ModulesInternalApiUrl { get; set; }
        public string AccountsInternalApiUrl { get; set; }
        public string ExternalApiUrl { get; set; } 
        public string LookupApiUrl { get; set; }
        public string CDN { get; set; }
        public string CDNUrl { get; set; }
        public string IconPath { get; set; }
        public string DefaultImagePath { get; set; }
        public string CurrentLocalDomain { get; set; }
        public string DesignResourcesWebUrl { get; set; }
        public string IndividualGateURL { get; set; }
        public string GovernmentGateURL { get; set; }
        public string BusinessGateURL { get; set; }
        public string ServiceGateURL { get; set; }
        public string SecurityGateURL { get; set; }
        public string LandingURL { get; set; }
    }
}
