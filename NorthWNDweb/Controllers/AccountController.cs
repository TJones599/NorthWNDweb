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

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(LoginPO form)
        {
            ActionResult response;
            if(ModelState.IsValid)
            {
                EmployeeDO userData = _EmployeeDAO.ViewByUsername(form.Username);
                if(!(userData.EmployeeId==0))
                {
                    if (form.Password.Equals(userData.Password)) 
                    {
                        Session["EmployeeID"] = userData.EmployeeId;
                        Session["Username"] = userData.Username;
                        Session["Title"] = userData.Title;
                        Session["Role"] = userData.Role;

                        response = RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Username or password was incorrect");
                        response = View(form);
                    }
                }
                else
                {
                    ModelState.AddModelError("Password", "Username or password was incorrect");
                    response = View(form);
                }
            }
            else
            {
                response = View(form);
            }
            return response;
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}