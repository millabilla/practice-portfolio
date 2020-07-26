using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        [HttpGet]
        public ActionResult RGB() {
            ViewBag.Message = "Your application description page.";
            ViewBag.red = Request.QueryString["redValue"];
            ViewBag.green = Request.QueryString["greenValue"];
            ViewBag.blue = Request.QueryString["blueValue"];


            int red = Convert.ToInt32(ViewBag.red);
            int green = Convert.ToInt32(ViewBag.green);
            int blue = Convert.ToInt32(ViewBag.blue);

            string hexValue = red.ToString("X2") + green.ToString("X2") + blue.ToString("X2");

            ViewBag.hexString = hexValue;

            return View();
        }

    }
}