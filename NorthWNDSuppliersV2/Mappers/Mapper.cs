using NorthWNDSuppliers_DAL.Models;
using NorthWNDSuppliersV2.Models;
using System.Collections.Generic;

namespace NorthWNDSuppliersV2
{
    public static class Mapper
    {
        public static SupplierPO SupplierDOtoSupplierPO(SupplierDO from)
        {
            SupplierPO to = new SupplierPO
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
        public static SupplierDO SupplierPOtoSupplierDO(SupplierPO from)
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

        public static List<SupplierPO> DOListToPOList(List<SupplierDO> from)
        {
            List<SupplierPO> toFull = new List<SupplierPO>();

            for (int i = 0; i < from.Count; i++)
            {
                SupplierPO to = new SupplierPO
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

