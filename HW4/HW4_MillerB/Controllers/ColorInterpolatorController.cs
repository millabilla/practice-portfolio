using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ColorInterpolatorController : Controller
    {
        /*needs to be HttpPost but that keeps breaking it for some reason*/
        
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(string start, string end, int num) {
            ViewBag.first = Request.QueryString["startColor"];
            ViewBag.second = Request.QueryString["endColor"];
            ViewBag.numberTransitions = Request.QueryString["interpolate"];

            return View();
        }
    }
}