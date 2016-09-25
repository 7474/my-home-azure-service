using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Owin;
using Owin;
using System.Web.Configuration;

[assembly: OwinStartupAttribute(typeof(MyHomeWeb.Startup))]
namespace MyHomeWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            var instrumentationKey = WebConfigurationManager.AppSettings["ApplicationInsightsInstrumentationKey"];
            if (!string.IsNullOrEmpty(instrumentationKey))
            {
                TelemetryConfiguration.Active.InstrumentationKey = instrumentationKey;
            }
        }
    }
}
