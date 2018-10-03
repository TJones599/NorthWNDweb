using NorthWNDSuppliers_DAL.Models;
using NorthWNDSuppliersV2;
using NorthWNDweb.Custom;
using NorthWNDweb.Mapping;
using NorthWNDweb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web.Mvc;

namespace NorthWNDweb.Controllers
{
    
    public class SuppliersController : Controller
    {
        private string filePath;
        private string logsPath;
        private string connectionString;
        private SupplierDAO dao;
        private List<SuppliersPO> allSuppliers = new List<SuppliersPO>();

        public SuppliersController()
        {
            //System.Web.HttpContext.Current.Server
            filePath = Path.GetDirectoryName(System.Web.HttpContext.Current.Server.MapPath("~"));
            logsPath = filePath + @"\Error Log.txt";
            connectionString = ConfigurationManager.ConnectionStrings["dataSource"].ConnectionString;
            dao = new SupplierDAO(connectionString, logsPath);
        }

        // GET: Suppliers
        [SecurityFilter(1)]
        [HttpGet]
        public ActionResult Index()
        {
            ActionResult result = new ViewResult();
            if (!(Session["Username"] is null))
            {
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
            }
            else
            {
                result = RedirectToAction("Login", "Account");
            }
            return result;
        }

        [SecurityFilter(2)]
        [HttpGet]
        public ActionResult CreateSupplier()
        {
            return View();
        }

        [SecurityFilter(2)]
        [HttpPost]
        public ActionResult CreateSupplier(SuppliersPO form)
        {
            ActionResult response;
            try
            {
                SupplierDO sup = Mapper.SupplierPOtoSupplierDO(form);
                dao.CreateNewSupplier(sup);
                response = RedirectToAction("Index", "Suppliers");
            }
            catch (SqlException sqlEx)
            {
                response = View(form);
            }

            return response;
        }


        [SecurityFilter(2)]
        [HttpGet]
        public ActionResult UpdateSupplier(int id)
        {
            ActionResult response;
            try
            {
                SupplierDO supDO = dao.ObtainSupplierSingle(id);
                SuppliersPO supplier = Mapper.SupplierDOtoSupplierPO(supDO);
                response = View(supplier);
            }
            catch (SqlException sqlEx)
            {
                response = RedirectToAction("Index", "Suppliers");
            }
            return response;
        }

        [SecurityFilter(2)]
        [HttpPost]
        public ActionResult UpdateSupplier(SuppliersPO form)
        {
            ActionResult response;
            try
            {
                SupplierDO sup = Mapper.SupplierPOtoSupplierDO(form);
                dao.UpdateInformation(sup);
                response = RedirectToAction("Index", "Suppliers");
            }
            catch (SqlException sqlEx)
            {
                response = View(form);
            }

            return response;
        }

        [SecurityFilter(3)]
        [HttpGet]
        public ActionResult DeleteSupplier(int id)
        {
            ActionResult response;
            try
            {
                dao.DeleteSupplier(id);
                response = RedirectToAction("Index", "Suppliers");
            }
            catch (SqlException sqlEx)
            {
                response = RedirectToAction("Index", "Suppliers");
            }
            return response;
        }
    }
}