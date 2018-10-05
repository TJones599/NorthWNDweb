using NorthWNDSuppliers_DAL.Models;
using NorthWNDSuppliers_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWNDSuppliersV2
{
    public class ProductDAO
    {
        private readonly string connectionString;
        private readonly string logPath;

        public ProductDAO(string connectionString, string logPath)
        {
            this.connectionString = connectionString;
            this.logPath = logPath;
        }

        public List<ProductDO> ViewBySupplierID(int id)
        {
            List<ProductDO> products = new List<ProductDO>();
            try
            {
                using (SqlConnection sql = new SqlConnection(connectionString))
                using (SqlCommand sqlCMD = new SqlCommand("PRODUCT_BY_SUPPLIER", sql))
                {
                    sqlCMD.CommandType = CommandType.StoredProcedure;

                    sqlCMD.Parameters.AddWithValue("SupplierID", id);

                    sql.Open();

                    using (SqlDataReader reader = sqlCMD.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductDO temp = new ProductDO();
                            temp = Mapper.ReaderToProduct(reader);
                            products.Add(temp);
                        }
                    }
                    sql.Close();
                }

            }
            catch (SqlException sqlEx)
            {
                Logger.ErrorLogPath = logPath;
                Logger.SqlExceptionLog(sqlEx);

                throw sqlEx;
            }
                return products;
        }




    }
}
