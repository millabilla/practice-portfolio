using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HW6.DAL;
using HW6.Models;
using HW6.Models.ViewModels;

namespace HW6.Controllers
{
    public class StockItemViewModelsController : Controller
    {
        private WorldWideImportersContext db = new WorldWideImportersContext();

        //why doesn't this work? 
        //IQueryable<StockItem> stockItems = db.StockItems;
        public ActionResult Index() {
            return View();
        }

           
        [HttpPost]
        public ActionResult Index(string search) {

            IQueryable<StockItem> stockItems = db.StockItems;
            stockItems = stockItems.Where(s => s.StockItemName.Contains(search));
            return View(stockItems.ToList());

        }

      
        // GET: StockItemViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockItem stockItem = db.StockItems.Find(id);
            if (stockItem == null) {
                return HttpNotFound();
            }

            StockItemViewModel stockItemViewModel = new StockItemViewModel(stockItem);
       
            return View(stockItemViewModel);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
