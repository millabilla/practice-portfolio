using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HW6.Models.ViewModels {
    public class StockItemViewModel {

        public StockItemViewModel() {
            //empty constructor to stop the errors
        }
        public StockItemViewModel(StockItem stockItem) {
            //Main info for feature 1
            StockKey = stockItem.StockItemID;
            StockName = stockItem.StockItemName;
            StockSize = stockItem.Size;
            StockRetailPrice = stockItem.RecommendedRetailPrice;
            StockUnitWeight = stockItem.TypicalWeightPerUnit;
            StockLeadTime = stockItem.LeadTimeDays;
            StockValidSince = stockItem.ValidFrom;
            StockOrigin = stockItem.CustomFields.Split('"')[3];
            StockTags = stockItem.Tags.Trim(new Char[] { '[', ']' });
            StockPhotoData = stockItem.Photo;

            //Info for Supplier
            SupplierName = stockItem.Supplier.SupplierName;
            SupplierPhone = stockItem.Supplier.PhoneNumber;
            SupplierFax = stockItem.Supplier.FaxNumber;
            SupplierSite = stockItem.Supplier.WebsiteURL;
            SupplierPerson = stockItem.Supplier.Person2.FullName;

            //Sales History
            OrderNumbers = stockItem.InvoiceLines.Count;
            Profit = stockItem.InvoiceLines.Select(s => s.LineProfit).Sum();
            GrossSales = stockItem.InvoiceLines.Select(s => s.ExtendedPrice).Sum();


    }
/***************************************
 * Main Stock Information
 * *************************************/
        //Stock item key
        
        [Key]
        public int StockKey { get; private set; }
        public string StockName { get; private set; }
        public string StockSize { get; private set; }
        public decimal? StockRetailPrice{ get; private set; }
        public decimal? StockUnitWeight { get; private set; }
        public int StockLeadTime { get; private set; }
        public DateTime StockValidSince { get; private set; }
        public string StockOrigin { get; private set; }
        public string StockTags { get; private set; }
        public byte[] StockPhotoData { get; private set; }

        /*******************************
         * Supplier information
         * *****************************/
        public string SupplierName { get; private set; }
        public string SupplierPhone { get; private set; }
        public string SupplierFax { get; private set; }
        public string SupplierSite { get; private set; }
        public string SupplierPerson { get; private set; }

        /*****************************
         * Sales History Information
         * ***************************/

        public int OrderNumbers { get; private set; }
        public decimal GrossSales { get; private set; }
        public decimal Profit { get; private set; }

        /***********************************
         * Top Sellers
         * ********************************/

    }
}