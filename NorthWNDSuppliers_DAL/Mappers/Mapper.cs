using NorthWNDSuppliers_DAL.Models;
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
    }
}
