using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data.Entity;
using AtomicSeller.Models;
using AtomicSeller.ViewModels;
using AtomicSeller.Controllers;
using AtomicSeller.Helpers;
using Newtonsoft.Json;
using System.Globalization;
using System.Threading;
using System.Text.RegularExpressions;
//using ProductAPI.Models;
using AtomicCommonAPI.Models;
using AtomicSeller.Models.ASTCD001;
using Microsoft.EntityFrameworkCore;
//using AtomicSeller.MarketPlaces;

namespace AtomicSeller
{
    public class DA_MT
    {


        public List<LabelsDashboardViewModel> GetLabelsDashboard()
        {

            using (var db = new ASTCD001Context())
            {
                //DateTime _Deadline = DateTime.Today.AddDays(-28);

                var _Dataset = from row in
                                (from CP in db.CarrierProducts.DefaultIfEmpty()
                                 join S in db.Deliveries.DefaultIfEmpty() on CP.ProductId equals S.ShippingService
                                 //where 
                                 //(S.CreateDate > _Deadline)
                                 select new { CP, S, Dt = (S.CreateDate).Date }).AsEnumerable() //C,
                               group row by new { row.Dt, row.CP.ProductId } into g
                               select new LabelsDashboardViewModel
                               {
                                   CreateDate = (DateTime)((g.FirstOrDefault(r => (r.S.CreateDate != null)).S.CreateDate).Date),
                                   Product_ID = g.FirstOrDefault(r => (r.CP.ProductId != null)).CP.ProductId,
                                   Carrier_ID = (int)g.FirstOrDefault(r => (r.CP.CarrierId!= null)).CP.CarrierId,
                                   ProductName = g.FirstOrDefault(r => (r.CP.ProductName != null)).CP.ProductName,
                                   T = g.Count(r => (r.S.ShipmentStatus == "T" && r.S.ErrorStatus != "E")),
                                   E = g.Count(r => (r.S.ShipmentStatus == "T" && r.S.ErrorStatus == "E")),
                                   P = g.Count(r => (r.S.ShipmentStatus == "P")),
                                   S = g.Count(r => (r.S.ShipmentStatus == "S")),
                                   C = g.Count(r => (r.S.ShipmentStatus == "C")),
                                   W = g.Count(r => (r.S.ShipmentStatus == "W")),
                                   CountShipmentID = g.Count(r => r.S.DeliveryId != 0)
                               };

                try
                {
                    List<LabelsDashboardViewModel> toto = _Dataset.OrderByDescending(x => x.CreateDate).ToList();
                    return toto;
                }
                catch (Exception ex)
                {
                    return new List<LabelsDashboardViewModel>();
                }
            }
        }
        public List<SalesDashboardViewModel> GetSalesDashboard()
        {

            using (var db = new ASTCD001Context())
            {
                //DateTime _Deadline = DateTime.Today.AddDays(-8);

                var _Dataset = from row in
                                (from CP in db.Stores.DefaultIfEmpty()
                                 join S in db.Orders.DefaultIfEmpty() on CP.StoreKey equals S.OrderKey
                                 //where (S.CreateDate > _Deadline)
                                 select new { CP, S, Dt = (S.CreateDate.Value).Date }).AsEnumerable()
                               group row by new { row.Dt, row.CP.StoreId } into g
                               select new SalesDashboardViewModel
                               {
                                   CreateDate = (DateTime)((g.FirstOrDefault(r => (r.S.CreateDate != null)).S.CreateDate.Value).Date),
                                   Store_ID = (int)g.FirstOrDefault(r => (r.CP.StoreId != null)).CP.StoreId,
                                   StoreName = g.FirstOrDefault(r => (r.CP.StoreName != null)).CP.StoreName,
                                   P = g.Count(r => (r.S.OrderStatus == "Processing")),
                                   S = g.Count(r => (r.S.OrderStatus == "Sent")),
                                   D = g.Count(r => (r.S.OrderStatus == "Delivered")),
                                   C = g.Count(r => (r.S.OrderStatus == "Canceled")),
                                   W = g.Count(r => (r.S.OrderStatus == "Waiting")),
                                   CountOrderID = g.Count(r => r.S.OrderId != 0)
                               }
;

                try
                {
                    List <SalesDashboardViewModel> toto = _Dataset.OrderByDescending(x => x.CreateDate).ToList();
                    return toto;
                }
                catch (Exception ex)
                {
                    return new List<SalesDashboardViewModel>();
                }
            }
        }

        public string GetSetting(string Key)
        {
            try
            {
                using (var db = new ASTCD001Context())
                {
                    var setting = db.AtomicSettings.FirstOrDefault(s => s.KeyColumn == Key);
                    if (setting != null)
                        return setting.Value;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        public bool SetSetting(string Key, string Value)
        {
            using (var db = new ASTCD001Context())
            {
                var _AtomicSetting = db.AtomicSettings.FirstOrDefault(s => s.KeyColumn == Key);

                if (_AtomicSetting != null)
                {
                    //Update
                    _AtomicSetting.Value = Value;
                    db.SaveChanges();
                }
                else
                {
                    // Insert
                    AtomicSetting SettingElement = new AtomicSetting();

                    SettingElement.KeyColumn = Key;
                    SettingElement.Value = Value;

                    db.AtomicSettings.Add(SettingElement);
                    db.SaveChanges();

                }
            }
            return true;

        }
        public void PurgeStatus()
        {
            return;
            // New feature will overlap this

            string LastOrdersPurgeTime = new DA_MT().GetSetting("LastOrdersPurgeTime");
            string OrdersPurgeInterval = new DA_MT().GetSetting("OrdersPurgeInterval");

            if (string.IsNullOrEmpty(OrdersPurgeInterval))
            {
                OrdersPurgeInterval = "";
                new DA_MT().SetSetting("OrdersPurgeInterval", "24:00:00");
            }
            DateTime DT_LastOrdersRefreshTime = new Tools().ConvertStringToDate(LastOrdersPurgeTime);
            TimeSpan DT_OrdersPurgeInterval;

            if (!TimeSpan.TryParse(OrdersPurgeInterval, out DT_OrdersPurgeInterval))
                DT_OrdersPurgeInterval = new TimeSpan(24, 00, 00);

            if (DT_LastOrdersRefreshTime.Add(DT_OrdersPurgeInterval) < DateTime.Now)

                using (var db = new ASTCD001Context())
                {
                    // where UpdateDate < '2020-02-01'
                    int PurgeDaysT = 30;
                    string SPurgeDaysT = GetSetting("PurgeDaysT");
                    if (!string.IsNullOrEmpty(SPurgeDaysT))
                        PurgeDaysT = (int)new Tools().ConvertStringToDecimal(SPurgeDaysT);
                    string _TDate = DateTime.Today.AddDays(-PurgeDaysT).ToString("yyyy-MM-dd");
                    db.Deliveries.FromSqlRaw("UPDATE [Delivery] SET [ShipmentStatus] = 'W' WHERE [ShipmentStatus] = 'T' AND [UpdateDate] < {0}", _TDate);

                    int PurgeDaysP = 30;
                    string SPurgeDaysP = GetSetting("PurgeDaysP");
                    if (!string.IsNullOrEmpty(SPurgeDaysP))
                        PurgeDaysP = (int)new Tools().ConvertStringToDecimal(SPurgeDaysP);
                    string _PDate = DateTime.Today.AddDays(-PurgeDaysP).ToString("yyyy-MM-dd");
                    db.Deliveries.FromSqlRaw("UPDATE [Delivery] SET [ShipmentStatus] = 'S' WHERE [ShipmentStatus] = 'P' AND [UpdateDate] < {0}", _PDate);
                }
        }
    }
}