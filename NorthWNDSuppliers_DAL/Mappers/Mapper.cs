using NorthWNDSuppliers_DAL.Models;
using System;
using System.Data.SqlClient;

namespace NorthWNDSuppliers_DAL
{
    public static class Mapper
    {
        public static SupplierDO ReaderToSupplier(SqlDataReader from)
        {
            SupplierDO to = new SupplierDO
            {
                SupplierID = from.GetInt32(0),
                CompanyName = from.GetValue(1) as string,
                ContactName = from.GetValue(2) as string,
                ContactTitle = from.GetValue(3) as string,
                Address = from.GetValue(4) as string,
                City = from.GetValue(5) as string,
                Region = from.GetValue(6) as string,
                PostalCode = from.GetValue(7) as string,
                Country = from.GetValue(8) as string,
                Phone = from.GetValue(9) as string,
                Fax = from.GetValue(10) as string,
                HomePage = from.GetValue(11) as string
            };

            return to;
        }

        public static EmployeeDO ReaderToEmployee(SqlDataReader from)
        {
            EmployeeDO to = new EmployeeDO();

            to.EmployeeId = (int)from["EmployeeId"];
            to.LastName = from["LastName"] as string;
            to.FirstName = from["FirstName"] as string;
            to.Title = from["Title"] as string;
            to.TitleOfCourtesy = from["TitleOfCourtesy"] as string;

            if (!(from["BirthDate"] is DBNull))
            {
                to.BirthDate = (DateTime)from["BirthDate"];
            }
            if (!(from["HireDate"] is DBNull))
            {
                to.HireDate = (DateTime)from["HireDate"];
            }

            to.Address = from["Address"] as string;
            to.City = from["City"] as string;
            to.Region = from["Region"] as string;
            to.PostalCode = from["PostalCode"] as string;
            to.Country = from["Country"] as string;
            to.HomePhone = from["HomePhone"] as string;
            to.Extension = from["Extension"] as string;
            //Removed photo
            to.Notes = from["Notes"] as string;
            to.ReportsTo = from["ReportsTo"] as int?;
            to.PhotoPath = from["PhotoPath"] as string;
            to.Username = from["Username"] as string;
            to.Password = from["Password"] as string;
            to.Role = (int)from["Role"];

            return to;
        }

        public static ProductDO ReaderToProduct(SqlDataReader from)
        {
            ProductDO to = new ProductDO();
            
            to.Name = from["ProductName"] as string;
            to.CategoryName = from["CategoryName"] as string;
            to.QuantityPerUnit = from["QuantityPerUnit"] as string;
            to.UnitPrice = Math.Round((decimal)from["UnitPrice"], 2);
            to.UnitsInStock = (Int16)from["UnitsInStock"];
            to.UnitsOnOrder = (Int16)from["UnitsOnOrder"];
            to.ReorderLevel = (Int16)from["ReorderLevel"];
            to.Discontinued = (bool)from["Discontinued"];

            return to;
        }
    }
}
