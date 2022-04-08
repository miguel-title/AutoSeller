using AtomicParcelAPI.Models;
using AtomicSeller.Helpers;
using AtomicSeller.Models;
using AtomicSeller.ViewModels;
using Newtonsoft.Json;
//using PdfSharp.Pdf;
//using PdfSharp.Pdf.IO;
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
    public class LabelsController : BaseController
    {
        [HttpGet]
        public ActionResult ShippingDashBoard()
        {
            var model = new LabelsViewModel();

            new DA_MT().PurgeStatus();

            model.Dashboard = new DA_MT().GetLabelsDashboard();
            return View(model);
        }


        //[HttpGet]
        //public ActionResult GenerateLabels(string ShippingServiceID, DateTime CreateDate)
        //{
        //    #region Check Access rights
        //    string _Component = "GENERATELABELS";
        //    ViewModels.CheckComponentsReturn _CheckComponentsReturn = new ViewModels.CheckComponentsReturn();

        //    try
        //    {
        //        _CheckComponentsReturn = new Licencing().CheckComponentAccess(SessionBag.Instance.UserId, _Component);

        //        if (_CheckComponentsReturn.ComponentRightsStatus != Licencing.ComponentRightsStatus.Ok)
        //            return RedirectToAction(_CheckComponentsReturn.View, "Licencing", new
        //            {
        //                ComponentRightsStatus = _CheckComponentsReturn.ComponentRightsStatus,
        //                UserId = SessionBag.Instance.UserId,
        //                ComponentKey = _Component
        //            });
        //    }
        //    catch (Exception ex)
        //    {
        //        Tools.ErrorHandler("CheckComponentAccess Error : " + _Component, ex);
        //        return RedirectToAction(_CheckComponentsReturn.View, "Licencing");
        //    }
        //    #endregion Check Access rights

        //    int _ShippingServiceID = (int)new Tools().ConvertStringToDecimal(ShippingServiceID);

        //    PutParcelResponse _PutParcelResponse = new PutParcelResponse();

        //    _PutParcelResponse = new Shipping().GenerateDashBoardRowLabels(_ShippingServiceID, CreateDate);

        //    string _ReturnMessage = "";
        //    try { _ReturnMessage = _PutParcelResponse.Header.ReturnMessage; } catch { }

        //    Flash(new FlashMessage(_ReturnMessage));

        //    try
        //    {
        //        string ServerName = new DA_REF().GetGlobalInstanceSetting("ServerInstance");
        //        string Title = "GenerateLabels Return=" + _ReturnMessage;

        //        string NL = "<br />";
        //        string Body = "Message:" + NL + NL + _ReturnMessage + NL + NL + DateTime.Now.ToString();
        //        Body += NL + ServerName;

        //        string Recipient = "support@atomicseller.fr";

        //        new Email().SendMail(Title, Body, Recipient);
        //    }
        //    catch { }

        //    return RedirectToAction("ShippingDashBoard");
        //}


        //[HttpGet]
        //public ActionResult DisplayDownloadLabels(int ShippingServiceID, DateTime CreateDate)
        //{

        //    DEALsViewModel OrdersShipmentsList = new DA_MT().GetDealsVMFromCriteria(ShippingServiceID, "P", "", null, 300, CreateDate);

        //    List<DEALVM> _DEALList = OrdersShipmentsList.DEALs;

        //    string _Path = ""; string TrackingNumber = "";

        //    bool MoreThan1 = false;

        //    foreach (DEALVM _DealVM in _DEALList)
        //    {
        //        foreach (DeliveryVM _DeliveryVM in _DealVM.DeliveryVMs)
        //        {
        //            if (_Path == _DeliveryVM.Delivery.LabelPath) continue;
        //            if (string.IsNullOrEmpty(_Path))
        //            {
        //                _Path = _DeliveryVM.Delivery.LabelPath;
        //                TrackingNumber = _DeliveryVM.Delivery.TrackingNumber;
        //            }
        //            else { MoreThan1 = true; break; }
        //        }
        //    }

        //    if (MoreThan1==false)
        //        {
        //        try
        //        {
        //            switch (_Path.Substring(0, 4))
        //            {
        //                case "http":
        //                    return Redirect(_Path);
        //                default:
        //                    string _Ext = Path.GetExtension(_Path);
        //                    switch (_Ext)
        //                    {
        //                        case ".xls":
        //                            return File(_Path, "application/excel", "Label_" + TrackingNumber + ".xls");
        //                        case ".xlsx":
        //                            return File(_Path, "application/excel", "Label_" + TrackingNumber + ".xlsx");
        //                        case ".csv":
        //                            return File(_Path, "application/excel", "Label_" + TrackingNumber + ".csv");
        //                        case ".txt":
        //                            return File(_Path, "application/notepad", "Label_" + TrackingNumber + ".txt");
        //                        case ".pdf":
        //                            try
        //                            {
        //                                if (!System.IO.File.Exists(_Path))
        //                                {
        //                                    // Search subdirectories
        //                                    string _PathDir = Path.GetDirectoryName(_Path);
        //                                    var _SubDirs = Directory.GetDirectories(_PathDir);
        //                                    string _File = Path.GetFileName(_Path);
        //                                    foreach (string _SubDir in _SubDirs)
        //                                    {
        //                                        string _SubPath = Path.Combine(_PathDir, _SubDir, _File);
        //                                        if (System.IO.File.Exists(_SubPath))
        //                                        {
        //                                            return File(_SubPath, "application/pdf", "Label_" + TrackingNumber + ".pdf");
        //                                        }
        //                                    }
        //                                    Flash(new FlashMessage(new Local().TranslatedMessage("LABELFILENOTFOUND"), FlashMessageType.Error));

        //                                    return RedirectToAction("ShippingDashBoard");
        //                                }
        //                                return File(_Path, "application/pdf", "Label_" + TrackingNumber + ".pdf");
        //                            }
        //                            catch
        //                            {
        //                                Flash(new FlashMessage("Label file not found.", FlashMessageType.Error));

        //                                return RedirectToAction("ShippingDashBoard");
        //                            }
        //                        default:
        //                            return RedirectToAction("ShippingDashBoard");
        //                    }
        //            }
        //        }
        //        catch(Exception ex)
        //        {
                                        
        //        Flash(new FlashMessage(" " + ex.Message, FlashMessageType.Error));

        //        }

        //    }
        //    else
        //    {
        //        string _LabelsPath = new Shipping().BuildLabelPath(".Zip", 0, "Labels_");
        //        string _ZipSourceDir = Path.GetDirectoryName(_LabelsPath);

        //        string _ZipTargetDir = Directory.GetParent(_ZipSourceDir).FullName;

        //        string _ZipFileName = "Labels_" + new Tools().ConvertDateToString(DateTime.Today, "yyyyMMdd") + ".zip";

        //        string _ZipTargetPath = Path.Combine(_ZipTargetDir, _ZipFileName);

        //        if (System.IO.File.Exists(_ZipTargetPath))
        //        {
        //            System.IO.File.Delete(_ZipTargetPath);
        //        }

        //        ZipFile.CreateFromDirectory(_ZipSourceDir, _ZipTargetPath, CompressionLevel.Optimal, false);

        //        if (string.IsNullOrEmpty(_LabelsPath) == false)
        //            return File(_ZipTargetPath, "application/zip", _ZipFileName);
        //        else
        //            return RedirectToAction("ShippingDashBoard");
        //    }

        //    return RedirectToAction("ShippingDashBoard");
        //}

        //[HttpGet]
        //public ActionResult LabelsShippedConfirm(int? ShippingServiceID, DateTime? CreateDate)
        //{
        //    if (ShippingServiceID == null)
        //        return RedirectToAction("ShippingDashboard", "Labels");

        //    MarkShippedConfirmVM Model = new ViewModels.MarkShippedConfirmVM();

        //    Model.CreateDate = (DateTime)CreateDate;
        //    Model.ShippingServiceID = (int)ShippingServiceID;

        //    DEALsViewModel OrdersShipmentsList = new DA_MT().GetDealsVMFromCriteria((int)ShippingServiceID, "P", "", null, 300, CreateDate);

        //    Model.DEALs = OrdersShipmentsList.DEALs;

        //    return View(Model);

        //}

        //[HttpGet]
        //public ActionResult LabelsShipped(int ShippingServiceID, DateTime CreateDate)
        //{

        //    DEALsViewModel OrdersShipmentsList = new DA_MT().GetDealsVMFromCriteria(ShippingServiceID, "P", "", null, 300, CreateDate);

        //    List<DEALVM> _DEALList = OrdersShipmentsList.DEALs;

        //    foreach (DEALVM _DealVM in _DEALList)
        //    {
        //        foreach(DeliveryVM _DeliveryVM in _DealVM.DeliveryVMs)
        //        {
        //            Delivery _Delivery = _DeliveryVM.Delivery;
        //            if (_Delivery.ShipmentStatus == "P" && string.IsNullOrEmpty (_Delivery.TrackingNumber)==false )
        //            {
        //                //new DA_MT().UpdateDeliveryStatus(_Delivery.DeliveryID, "S");
        //                List<Order> OrdersList = new DA_MT().GetOrderListFromDeliveryID(_Delivery.DeliveryID);
        //                Order _Order = OrdersList.First();
        //                CarrierProduct _CarrierProduct = new DA_MT().GetShippingService((int)_Delivery.ShippingService);

        //                if (string.IsNullOrEmpty(_Order.StoreKey)==false && new TrackingCommon().EligibleUpdateTracking(_Order.StoreKey) ==true)
        //                {
        //                   ResponseHeader _ResponseHeader = new TrackingCommon().PutDeliveryInfoFromAPIToSalesChannel(
        //                    "S",
        //                    _Delivery.TrackingNumber,
        //                    _Delivery.DeliveryID.ToString(),
        //                    _Order.OrderKey,
        //                    _Order.OrderID.ToString(),
        //                    _Order.OrderID_Ext,
        //                    _Order.StoreKey,
        //                    _Delivery.Shipping_method_title,
        //                    _CarrierProduct.ProductName,
        //                    "",
        //                    _Delivery.RecipEmail,
        //                    _Delivery.RecipFirstName,
        //                    _Delivery.RecipLastName,
        //                    _Delivery.RecipZip
        //                    );

        //                    if (_ResponseHeader.RequestStatus == "Ok")
        //                        new DA_MT().UpdateDeliveryStatus(_Delivery.DeliveryID, "S");
        //                        else
        //                        {
        //                        Flash(new FlashMessage(_ResponseHeader.ReturnMessage, FlashMessageType.Error));

        //                    }
        //                }
        //                else
        //                {
        //                    new DA_MT().UpdateDeliveryStatus(_Delivery.DeliveryID, "S");
        //                }
        //            }
        //        }
        //    }

        //    return RedirectToAction("ShippingDashBoard","Labels");
        //}

        //public ActionResult DownloadLabelsOfTheDay()
        //{

        //    string _LabelsPath = new Shipping().BuildLabelPath(".Zip", 0, "Labels_");
        //    string _ZipSourceDir = Path.GetDirectoryName(_LabelsPath);

        //    string _ZipTargetDir = Directory.GetParent(_ZipSourceDir).FullName;

        //    string _ZipFileName = "Labels_" + new Tools().ConvertDateToString(DateTime.Today, "yyyyMMdd") + ".zip";

        //    string _ZipTargetPath = Path.Combine(_ZipTargetDir, _ZipFileName);

        //    if (System.IO.File.Exists(_ZipTargetPath))
        //    {
        //        System.IO.File.Delete(_ZipTargetPath);
        //    }


        //    ZipFile.CreateFromDirectory(_ZipSourceDir, _ZipTargetPath, CompressionLevel.Optimal, false);

        //    if (string.IsNullOrEmpty(_LabelsPath) == false)
        //        return File(_ZipTargetPath, "application/zip", _ZipFileName);
        //    else
        //        return RedirectToAction("ShippingDashBoard");

        //}

        //[HttpGet]
        //public ActionResult BatchShippingRates(string ShippingServiceID, DateTime? CreateDate)
        //{
        //    if (string.IsNullOrEmpty(ShippingServiceID)) RedirectToAction("ShippingDashBoard", "Labels");
        //    if (CreateDate==null) RedirectToAction("ShippingDashBoard", "Labels");

        //    #region Check Access rights
        //    /*
        //        string _Component = "SHIPPINGPRICES";
        //        ViewModels.CheckComponentsReturn _CheckComponentsReturn = new ViewModels.CheckComponentsReturn();

        //        try
        //        {
        //            _CheckComponentsReturn = new Licencing().CheckComponentAccess(SessionBag.Instance.UserId, _Component);

        //            if (_CheckComponentsReturn.ComponentRightsStatus != Licencing.ComponentRightsStatus.Ok)
        //                return RedirectToAction(_CheckComponentsReturn.View, "Licencing", new
        //                {
        //                    ComponentRightsStatus = _CheckComponentsReturn.ComponentRightsStatus,
        //                    UserId = SessionBag.Instance.UserId,
        //                    ComponentKey = _Component
        //                });
        //        }
        //        catch (Exception ex)
        //        {
        //            Tools.ErrorHandler("CheckComponentAccess Error : " + _Component, ex);
        //            return RedirectToAction(_CheckComponentsReturn.View, "Licencing");
        //        }
        //        */
        //    #endregion Check Access rights

        //    int _ShippingServiceID = (int)new Tools().ConvertStringToDecimal(ShippingServiceID);

        //    ShippingRatesListResponse _GetShippingRatesResponse = new ShippingRates().GetBatchShippingRates(_ShippingServiceID, (DateTime)CreateDate);

        //    return View(_GetShippingRatesResponse);
        //}

        //[HttpGet]
        //public ActionResult BulkTools(DEALsViewModel model = null)
        //{
        //    if (model == null)
        //    {
        //        model = new DEALsViewModel();
        //    }

        //    model.DEALFilter.SelectedDEALFilterType = DEALFilterType.OrdersCriteria;

        //    model.DEALFilter.ShipmentStatus = model.DEALFilter.SelectedStatusCriteria;

        //    model.DEALFilter.DeliveryStartDateStr = "01/01/1900";

        //    int Page = 1;
        //    int Limit = 130;
        //    model = new DA_MT().GetDEALVMsByDEALFilter(model.DEALFilter, Limit, Page);

        //    return View(model);
        //}

        /*
        [HttpGet]
        public ActionResult PrintLabels(string ids)
        {
            byte[] array = null;
            var idsSelected = ids.Split('-');
            using (var db = new AtomicTenantEntities(SessionBag.Instance.ConnectionString))
            {
                var selected = db.LabelsDashboardView.Where(d => idsSelected.Contains(d.Product_ID.ToString())).ToList();

                array = ProcessLabels(LabelProcess.Print, selected);
            }
            if (array != null)
            {
                Response.AddHeader("Content-Disposition", "inline; filename=labels.pdf");
                return File(array, "application/pdf");
            }
            return null;
        }
        */
        //[HttpGet]
        //public ActionResult MarkAsShipped(string ids)
        //{

        //    new DA_MT().MarkShipmentsList(ids, "S");

        //    return RedirectToAction("BulkTools");
        //}

        //[HttpGet]
        //public ActionResult MarkAsCanceled(string ids)
        //{
        //    new DA_MT().MarkShipmentsList(ids, "C");

        //    return RedirectToAction("BulkTools");
        //}

        //[HttpGet]
        //public ActionResult MarkToBePrinted(string ids)
        //{
        //    new DA_MT().MarkShipmentsList(ids, "P");

        //    return RedirectToAction("BulkTools");
        //}

        //[HttpGet]
        //public ActionResult MarkToBeProcessed(string ids)
        //{
        //    new DA_MT().MarkShipmentsList(ids, "T");

        //    return RedirectToAction("BulkTools");
        //}

        //[HttpGet]
        //public ActionResult GenerateLabel(int DeliveryID)
        //{

        //    #region Check Access rights
        //    string _Component = "GENERATELABELS";
        //    ViewModels.CheckComponentsReturn _CheckComponentsReturn = new ViewModels.CheckComponentsReturn();

        //    try
        //    {
        //        _CheckComponentsReturn = new Licencing().CheckComponentAccess(SessionBag.Instance.UserId, _Component);

        //        if (_CheckComponentsReturn.ComponentRightsStatus != Licencing.ComponentRightsStatus.Ok)
        //            return RedirectToAction(_CheckComponentsReturn.View, "Licencing", new
        //            {
        //                ComponentRightsStatus = _CheckComponentsReturn.ComponentRightsStatus,
        //                UserId = SessionBag.Instance.UserId,
        //                ComponentKey = _Component
        //            });
        //    }
        //    catch (Exception ex)
        //    {
        //        Tools.ErrorHandler("CheckComponentAccess Error : " + _Component, ex);
        //        return RedirectToAction(_CheckComponentsReturn.View, "Licencing");
        //    }
        //    #endregion Check Access rights

        //    Models.Delivery _Delivery = new DA_MT().GetDeliveryByID(DeliveryID);
        //    List<Models.Order> _Orders = new DA_MT().GetOrdersByDeliveryID(DeliveryID); 

        //    foreach(var _Order in _Orders)
        //        new DA_MT().CopyOrderProductsToDeliveryProducts(_Order, _Delivery);

        //    new Shipping().GenerateDeliveryLabel(DeliveryID);

        //    try
        //    {
        //        DEALVM _DEALVM = new DEALVM();
        //        //_DEALVM.InitDealVM();
        //        _DEALVM.DeliveryVMs = new List<DeliveryVM>();
        //        _DEALVM.OrderVMs = new List<OrderVM>();
        //        foreach (var _Order in _Orders)
        //            {
        //            OrderVM _OrderVM = new OrderVM();
        //            _OrderVM.Order = _Order;
        //            _DEALVM.OrderVMs.Add(_OrderVM);
        //        }
        //        DeliveryVM _DeliveryVM = new DeliveryVM();
        //        _DeliveryVM.Delivery = _Delivery;
        //        _DeliveryVM.DeliveryProducts = new DA_MT().GetDeliveryProducts(DeliveryID);
        //        _DEALVM.DeliveryVMs.Add(_DeliveryVM); 
        //        PutParcelResponse _DocumentsResponse = new Shipping().GenerateDeliveryDocuments(_DEALVM, _Delivery.DeliveryID, 0, 0, _Delivery, _DEALVM.OrderVMs.First().Order);
        //        //_ParcelResponse.Response.Documents.AddRange(_DocumentsResponse.Response.Documents);
        //    }
        //    catch { }

        //    return RedirectToAction("DEALDisplay", "Orders", new { DeliveryID = DeliveryID });
        //}
        
        //[HttpGet]
        //public ActionResult GenerateReturnLabel(int DeliveryID)
        //{

        //    #region Check Access rights
        //    string _Component = "GENERATELABELS";
        //    ViewModels.CheckComponentsReturn _CheckComponentsReturn = new ViewModels.CheckComponentsReturn();

        //    try
        //    {
        //        _CheckComponentsReturn = new Licencing().CheckComponentAccess(SessionBag.Instance.UserId, _Component);

        //        if (_CheckComponentsReturn.ComponentRightsStatus != Licencing.ComponentRightsStatus.Ok)
        //            return RedirectToAction(_CheckComponentsReturn.View, "Licencing", new
        //            {
        //                ComponentRightsStatus = _CheckComponentsReturn.ComponentRightsStatus,
        //                UserId = SessionBag.Instance.UserId,
        //                ComponentKey = _Component
        //            });
        //    }
        //    catch (Exception ex)
        //    {
        //        Tools.ErrorHandler("CheckComponentAccess Error : " + _Component, ex);
        //        return RedirectToAction(_CheckComponentsReturn.View, "Licencing");
        //    }
        //    #endregion Check Access rights

        //    Models.Delivery _Delivery = new DA_MT().GetDeliveryByID(DeliveryID);
        //    List<Models.Order> _Orders = new DA_MT().GetOrdersByDeliveryID(DeliveryID);

        //    //Models.Delivery _Delivery = new DA_MT().CreateDeliveryFromShipment(_Orders, _Delivery);


        //    //_Delivery.ProductCode = "CORE";

        //    new Shipping().GenerateDeliveryReturnLabel(0, 0,0,_Delivery);

        //    return RedirectToAction("DEALDisplay", "Orders", new { DeliveryID = DeliveryID });
        //}

        


        /*
        private byte[] PrintPDFLabels(long Product_ID)
        {
            using (var db = new AtomicTenantEntities(SessionBag.Instance.ConnectionString))
            {
                var query = from order in db.Order
                            join shipment in db.Delivery on order.Order_Delivery_ID equals shipment.DeliveryID
                            join carrierProduct in db.CarrierProduct on shipment.ShippingService equals carrierProduct.Product_ID
                            where shipment.ShipmentStatus == "P" && carrierProduct.Product_ID == Product_ID
                            select new
                            {
                                Order = order,
                                Shipment = shipment,
                                CarrierProduct = carrierProduct
                            };

                var ordersShipmentsList = query.ToList();

                var filePaths = new List<string>();
                string LabelFile = null;
                foreach (var shipment in ordersShipmentsList)
                {
                    LabelFile = shipment.Shipment.LabelPath;

                    if (string.IsNullOrEmpty(LabelFile))
                    {
                        Flash(new FlashMessage("Error: Label not found.",FlashMessageType.Error));

                        continue;
                    }
                    string FileExtension = "";
                    FileExtension = LabelFile.Substring(LabelFile.Length - 3);

                    if(FileExtension == "pdf")
                    {
                        filePaths.Add(LabelFile);

                        // neutralisé pour tests
                        // SQLServerEntities.UpdateShipmentStatus(ShipmentTMP.DeliveryID, "S");
                    }
                }

                // on combine tous les fichiers pdfs
                return(MergePdf(filePaths.Select(f => System.IO.File.ReadAllBytes(f)).ToList()));
            }
        }
        */
        /*
        private byte[] MergePdf(List<byte[]> pdfs)
        {
            List<PdfSharp.Pdf.PdfDocument> lstDocuments = new List<PdfSharp.Pdf.PdfDocument>();
            foreach (var pdf in pdfs)
            {
                lstDocuments.Add(PdfReader.Open(new MemoryStream(pdf), PdfDocumentOpenMode.ReadOnly));
            }

            using (PdfSharp.Pdf.PdfDocument outPdf = new PdfSharp.Pdf.PdfDocument())
            {
                for (int i = 1; i <= lstDocuments.Count; i++)
                {
                    foreach (PdfSharp.Pdf.PdfPage page in lstDocuments[i - 1].Pages)
                    {
                        outPdf.AddPage(page);
                    }
                }

                MemoryStream stream = new MemoryStream();
                outPdf.Save(stream, false);
                byte[] bytes = stream.ToArray();

                return bytes;
            }
        }
        */
    }
}
