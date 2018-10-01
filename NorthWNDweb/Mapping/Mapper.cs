using NorthWNDSuppliers_DAL.Models;
using NorthWNDweb.Models;
using System.Collections.Generic;

namespace NorthWNDweb.Mapping
{
    public static class Mapper
    {
        public static SuppliersPO SupplierDOtoSupplierPO(SupplierDO from)
        {
            SuppliersPO to = new SuppliersPO
            {
                SupplierID = from.SupplierID,
                CompanyName = from.CompanyName,
                ContactName = from.ContactName,
                ContactTitle = from.ContactTitle,
                Address = from.Address,
                City = from.City,
                Region = from.Region,
                PostalCode = from.PostalCode,
                Country = from.Country,
                Phone = from.Phone,
                Fax = from.Fax,
                HomePage = from.HomePage
            };

            return to;
        }
        public static SupplierDO SupplierPOtoSupplierDO(SuppliersPO from)
        {
            SupplierDO to = new SupplierDO
            {
                SupplierID = from.SupplierID,
                CompanyName = from.CompanyName,
                ContactName = from.ContactName,
                ContactTitle = from.ContactTitle,
                Address = from.Address,
                City = from.City,
                Region = from.Region,
                PostalCode = from.PostalCode,
                Country = from.Country,
                Phone = from.Phone,
                Fax = from.Fax,
                HomePage = from.HomePage
            };

            return to;
        }

        public static List<SuppliersPO> DOListToPOList(List<SupplierDO> from)
        {
            List<SuppliersPO> toFull = new List<SuppliersPO>();

            for (int i = 0; i < from.Count; i++)
            {
                SuppliersPO to = new SuppliersPO
                {
                    SupplierID = from[i].SupplierID,
                    CompanyName = from[i].CompanyName,
                    ContactName = from[i].ContactName,
                    ContactTitle = from[i].ContactTitle,
                    Address = from[i].Address,
                    City = from[i].City,
                    Region = from[i].Region,
                    PostalCode = from[i].PostalCode,
                    Country = from[i].Country,
                    Phone = from[i].Phone,
                    Fax = from[i].Fax,
                    HomePage = from[i].HomePage
                };
                toFull.Add(to);
            }

            return toFull;
        }
    }
}

