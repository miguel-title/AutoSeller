using AtomicParcelAPI.Models;
using AtomicSeller.Helpers;
using AtomicSeller.Models;
using AtomicSeller.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Web;
using AtomicCommonAPI.Models;
using Microsoft.AspNetCore.Mvc;
//using AtomicSeller.AccessRights;

namespace AtomicSeller.Controllers
{
    public class SalesController : BaseController
    {
        [HttpGet]
        public ActionResult SalesDashBoard()
        {
            var model = new SalesViewModel();

            new DA_MT().PurgeStatus();

            model.Dashboard = new DA_MT().GetSalesDashboard();
            return View(model);
        }
    }
}
