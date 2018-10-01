using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NorthWNDweb.Models;
using System.Configuration;
using NorthWNDSuppliersV2;
using System.Reflection;
using System.IO;
using System.Threading;
using NorthWNDSuppliers_DAL.Models;
using NorthWNDweb.Mapping;
using System.Data.SqlClient;

namespace NorthWNDweb.Controllers
{
    public class SuppliersController : Controller
    {
        private string filePath;
        private string logsPath;
        private string connectionString;
        private SupplierDAO dao;

        public SuppliersController()
        {
            //System.Web.HttpContext.Current.Server
            filePath = Path.GetDirectoryName(System.Web.HttpContext.Current.Server.MapPath("~"));
            logsPath = filePath + @"\Error Log.txt";
            connectionString = ConfigurationManager.ConnectionStrings["dataSource"].ConnectionString;
            dao = new SupplierDAO(connectionString, logsPath);
        }

        // GET: Suppliers
        public ActionResult Index()
        {
            ActionResult result = new ViewResult();
            List<SuppliersPO> allSuppliers = new List<SuppliersPO>();
            try
            {
                List<SupplierDO> doList = dao.ObtainTableInfo();
                allSuppliers = Mapper.DOListToPOList(doList);
                result = View(allSuppliers);
            }
            catch (SqlException sqlEx)
            {
                Logger.errorLogPath = logsPath;

                if (!(sqlEx.Data.Contains("Logged") && (bool)sqlEx.Data["Logged"] == true))
                {
                    Logger.SqlExceptionLog(sqlEx);
                }

            }
            catch (Exception exception)
            {
                Logger.errorLogPath = logsPath;

                if (!(exception.Data.Contains("Logged") && (bool)exception.Data["Logged"] == true))
                {
                    Logger.ExceptionLog(exception, "");
                }
            }
            finally
            {

            }
            return result;
        }
    }
}