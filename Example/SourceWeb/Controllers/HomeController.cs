using SimpleSso;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SourceWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Navigate()
        {
            var sso = new SsoManager(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            var token = sso.CreateToken("John", "SourceWeb");
            return Redirect($"https://localhost:44366/Home/Login/?{SsoManager.QueryStringToken}={token}");
        }
    }
}