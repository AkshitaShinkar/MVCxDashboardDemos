using System;
using System.Web.Routing;
using System.Xml.Linq;
using DevExpress.Security.Resources;

namespace DevExpress.Web.Demos {
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication {
        

        protected void Application_Start() {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DashboardConfig.RegisterService(RouteTable.Routes);
            AccessSettings.StaticResources.TrySetRules(DirectoryAccessRule.Allow(Server.MapPath(@"~/Content")), UrlAccessRule.Allow());
            DevExpress.Web.ASPxWebControl.CallbackError += new EventHandler(CallbackError);
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls12;
        }


        protected void Session_Start() {
            RegisterDefaultDashboard("SalesOverview");
            RegisterDefaultDashboard("CustomerSupport");
            RegisterDefaultDashboard("SalesPerformance");
            RegisterDefaultDashboard("SalesDetails");
            RegisterDefaultDashboard("Financial");
            RegisterDefaultDashboard("EnergyStatistics");
            RegisterDefaultDashboard("HumanResources");
            RegisterDefaultDashboard("ChampionsLeagueStatistics");
            RegisterDefaultDashboard("RevenueAnalysis");
            RegisterDefaultDashboard("RevenueByIndustry");
            RegisterDefaultDashboard("EnergyConsumption");
            RegisterDefaultDashboard("WebsiteStatistics");
            RegisterDefaultDashboard("EUTradeOverview");
            RegisterDefaultDashboard("YTDPerformance");
            RegisterDefaultDashboard("DateFilter");
            RegisterDefaultDashboard("DataFederation");
            RegisterDefaultDashboard("ProductDetails");
            RegisterDefaultDashboard("CustomItemExtensions");
        }
        void RegisterDefaultDashboard(string dashboardId) {
            string dashboardLocalPath = Server.MapPath(string.Format(@"~/App_Data/Dashboards/{0}.xml", dashboardId));
            SessionDashboardStorage.Instance.RegisterDashboard(dashboardId, XDocument.Load(dashboardLocalPath));
        }

        void CallbackError(object sender, EventArgs e) {
            // Logging exceptions occur on callback events of DevExpress ASP.NET MVC controls. 
            // To learn more, see http://www.devexpress.com/Support/Center/Example/Details/E4588
        }
    }
}
