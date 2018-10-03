using NorthWNDSuppliers_DAL;
using NorthWNDSuppliers_DAL.Models;
using NorthWNDweb.Mapping;
using NorthWNDweb.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web.Mvc;

namespace NorthWNDweb.Controllers
{
    public class AccountController : Controller
    {
        private EmployeeDAO _EmployeeDAO;
        public AccountController()
        {
            string relativePath = ConfigurationManager.AppSettings["logPath"];
            string logPath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~"), relativePath);

            string connectionString = ConfigurationManager.ConnectionStrings["dataSource"].ConnectionString;
            _EmployeeDAO = new EmployeeDAO(connectionString, logPath);
        }
        // GET: Account
        public ActionResult Index()
        {
            ActionResult response;
            try
            {
                List<EmployeeDO> allEmployees = _EmployeeDAO.ViewAll();
                List<EmployeePO> displayList = EmployeeMapper.DOToPO(allEmployees);
                response = View(displayList);
            }
            catch(SqlException ex)
            {
                TempData["ErrorMessage"] = "Sorry, we encountered an issue";
                response = View();
            }
            return response;
        }
    }
}