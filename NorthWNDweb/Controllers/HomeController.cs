using NorthWNDweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthWNDweb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult ViewProductsTable(int id)
        {
            //Data access.
            List<ProductPO> products = new List<ProductPO>();

            products.Add(new ProductPO() { Name = "Vans High Tops", CategoryName = "Shoes", Discontinued = false, QuantityPerUnit = "2", ReorderLevel = 5, UnitPrice = 127, UnitsInStock = 20, UnitsOnOrder = 0});
            products.Add(new ProductPO() { Name = "Vans Medium Tops", CategoryName = "Shoes", Discontinued = false, QuantityPerUnit = "2", ReorderLevel = 5, UnitPrice = 127, UnitsInStock = 20, UnitsOnOrder = 0 });
            products.Add(new ProductPO() { Name = "Vans Low Tops", CategoryName = "Shoes", Discontinued = false, QuantityPerUnit = "2", ReorderLevel = 5, UnitPrice = 127, UnitsInStock = 20, UnitsOnOrder = 0 });
            products.Add(new ProductPO() { Name = "Huntin' Boots", CategoryName = "Shoes", Discontinued = false, QuantityPerUnit = "2", ReorderLevel = 5, UnitPrice = 127, UnitsInStock = 20, UnitsOnOrder = 0 });
            products.Add(new ProductPO() { Name = "Tennis Shoes", CategoryName = "Shoes", Discontinued = false, QuantityPerUnit = "2", ReorderLevel = 5, UnitPrice = 127, UnitsInStock = 20, UnitsOnOrder = 0 });
            return PartialView("_ProductsTable", products);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}