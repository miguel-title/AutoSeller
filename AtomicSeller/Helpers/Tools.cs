using AtomicSeller.Controllers;
using AtomicSeller.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
//using Microsoft.Extensions.Logging;
//using NLog.Web;
using NLog;
using NLog.Targets;
using AtomicSeller.Models;
using System.Net;
using System.Net.Mail;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Http;
//using NLog.Extensions.Logging;


namespace AtomicSeller
{
    public class Tools
    {
        public static string LabelFilesDirectory = "LabelFiles";
        public static string EDIFilesDirectory = "EDIFiles";
        public static string EDISentFilesDirectory = "Sent";
        public static string ExportFilesDirectory = "ExportFiles";
        //public static string AppdataDirectory = "Atomic";
        public static string InvoiceFilesDirectory = "Invoices";

        public static bool TaxManagement = false;


        static string AppData = string.Empty;


        
      
      
        public static Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private readonly TempDataDictionary tempData;


        private readonly IHttpContextAccessor _context;


        public string GetBaseURL()
        {
            //string url = string.Empty;
            string baseUrl = string.Empty;

            /*
            string toto = System.Web.HttpContext.Current.Server.MapPath("~");
            //System.IO.Directory.Exists(HttpContext.Current.Server.MapPath(RefPath));
            string titi = System.Web.Hosting.HostingEnvironment.MapPath("~/");
            string tutu = HttpRuntime.AppDomainAppPath;
            */

            try
            {
                HttpRequest Request = _context.HttpContext.Request;
                //string toto = System.Net.Dns.GetHostName();
                //string titi = System.Net.Http.Headers. 
                baseUrl = Request.PathBase;

                //baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";
            }
            catch (Exception ex)
            {
                baseUrl = System.Net.Dns.GetHostName();
                //baseUrl = ex.Message + "</br> " + ex.InnerException.Message + "</br> " + ex.StackTrace + "</br> ";
            }

            return baseUrl;
        }

        private static string ProdSetting = string.Empty;
        private static string DevSetting = string.Empty;
        private static string DemoSetting = string.Empty;
        private static string EcommerceSetting = string.Empty;

        public static void ErrorHandler(string Message, Exception ex = null, bool DisplayMessage = false, bool TraceLog = true, bool DisplayTrace = false, BaseController controller = null)
        {


        }

        public decimal ConvertStringToDecimal(string Value, string Culture = null)
        {

            //CultureInfo _CultureInfo = new CultureInfo("en-US");
            //if (Culture!=null) _CultureInfo = new CultureInfo(Culture);

            if (string.IsNullOrEmpty(Value)) return 0;
            Value = Regex.Replace(Value, "[^\\d,^\\.,^\\,]*", "");
            Value = Value.Replace(",", ".");
            try
            {
                return Convert.ToDecimal(Value, CultureInfo.InvariantCulture);
            }
            catch
            {
                return 0;
            }
        }

        public int ConvertStringToInt(string Value)
        {
            if (string.IsNullOrEmpty(Value)) return 0;
            Value = Regex.Replace(Value, "[^\\d,^\\.,^\\,]*", "");
            Value = Value.Replace(",", ".");
            if (string.IsNullOrEmpty(Value)) return 0;

            int Ret = 0;
            try
            {
                Ret = (int)Convert.ToDouble(Value, CultureInfo.InvariantCulture);
                //Ret = Convert.ToInt32(Value, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                Tools.ErrorHandler("ConvertStringToInt error Value=" + Value.ToString(), ex);
            }
            return Ret;
        }

        public string ConvertDateToString(DateTime InputDate, string DateFormat = null, string _Culture = null)
        {
            if (DateFormat != null)
                return InputDate.ToString(DateFormat);

            switch (_Culture)
            {
                case "en-US":
                    return InputDate.ToString("MM/dd/yyyy");
                //break;
                case "fr-FR":
                    return InputDate.ToString("dd/MM/yyyy");
                //break;
                case "":
                case null:
                    if (string.IsNullOrEmpty(DateFormat))
                        return InputDate.ToString("yyyyMMdd");
                    else
                        return InputDate.ToString(DateFormat);
                //break;
                default:
                    return InputDate.ToString("MM/dd/yyyy");
                    //break;
            }
        }

        public DateTime ConvertStringToDate(string InputString, string _Culture = null)
        {
            if (string.IsNullOrEmpty(InputString)) return new DateTime(1900, 1, 1);

            List<string> formats = new List<string>();

            if (string.IsNullOrEmpty(_Culture)) _Culture = "";
            switch (_Culture)
            {
                case "fr-FR":
                    //"21\/02\/2019"
                    formats.Add("dd/MM/yyyy");
                    formats.Add("dd/M/yyyy");
                    formats.Add("d/M/yyyy");
                    formats.Add("d/MM/yyyy");
                    formats.Add("dd/MM/yy");
                    formats.Add("dd/M/yy");
                    formats.Add("d/M/yy");
                    formats.Add("d/MM/yy");
                    formats.Add("ddd dd MMM yyyy h:mm tt zzz");
                    formats.Add("dd-MM-yyyy");
                    formats.Add("dd/MM/yyyy HH:mm:ss"); // 25/04/2019 00:00:00 // 11/06/2019 00:00:00
                    //"MM/dd/yyyy HH:mm:ss",
                    formats.Add("dd/MM/yyyy HH:mm");
                    //"MM/dd/yyyy HH:mm"
                    formats.Add("yyyy-MM-dd HH:mm:ss");
                    formats.Add("yyyy-MM-dd'T'HH:mm:ss.fff'Z'"); //"2020-07-15T07:07:55.000Z"
                    formats.Add("yyyy-MM-dd'T'HH:mm:ss"); //"2020-07-15T07:07:55.000Z"
                    break;
                default:
                    //"21\/02\/2019"
                    formats.Add("dd/MM/yyyy");
                    formats.Add("dd/M/yyyy");
                    formats.Add("d/M/yyyy");
                    formats.Add("d/MM/yyyy");
                    formats.Add("dd/MM/yy");
                    formats.Add("dd/M/yy");
                    formats.Add("d/M/yy");
                    formats.Add("d/MM/yy");
                    formats.Add("ddd dd MMM yyyy h:mm tt zzz");
                    formats.Add("dd-MM-yyyy");
                    formats.Add("dd/MM/yyyy HH:mm:ss");
                    //"MM/dd/yyyy HH:mm:ss",
                    formats.Add("dd/MM/yyyy HH:mm");
                    //"MM/dd/yyyy HH:mm"
                    formats.Add("yyyy-MM-dd HH:mm:ss");
                    formats.Add("yyyy-MM-dd'T'HH:mm:ss.fff'Z'"); //"2020-07-15T07:07:55.000Z" 2020-05-29T07:37:48.000Z"
                    formats.Add("yyyy-MM-dd'T'HH:mm:ss");
                    formats.Add("yyyy-MM-ddTHH:mm:ss.fffZ"); //"2020-07-15T07:07:55.000Z" 2020-05-29T07:37:48.000Z"
                    break;
            }


            DateTime ResultDate;

            //            if (!DateTime.TryParse(InputString, out ResultDate))
            if (DateTime.TryParseExact(InputString, formats.ToArray(),
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out ResultDate))
                return ResultDate;

            if (DateTime.TryParse(InputString, out ResultDate))
                return ResultDate;

            //if (DateTime.TryParse(InputString, out ResultDate)) return ResultDate;

            return new DateTime(1900, 1, 1);
        }



    }
}
