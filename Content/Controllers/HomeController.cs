using DevExpress.DashboardWeb;
using System.Configuration;
using System.Web.Mvc;

namespace DashboardMvcDemo.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            if (Request.Browser.IsMobileDevice) {
                return View("MobileDashboard");
            }
            string workingModeString = this.Request.QueryString["mode"];
            var workingMode = !string.IsNullOrEmpty(workingModeString) && workingModeString == "designer" ? WorkingMode.Designer : WorkingMode.Viewer;
            
            return View(workingMode);
        }
        [Route("MobileDashboard")]
        public ActionResult MobileDashboard() {
            return View();
        }
        [Route("Emulator")]
        public ActionResult Emulator() {      
            return View("Emulator", null, ConfigurationManager.AppSettings["MobileUrl"]);            
        }
    }
}
