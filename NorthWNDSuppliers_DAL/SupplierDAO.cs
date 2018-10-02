using NorthWNDSuppliers_DAL;
using NorthWNDSuppliers_DAL.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace NorthWNDSuppliersV2
{

    public class SupplierDAO
    {
        public readonly string connectionString;
        public readonly string errorLogPath;

        public SupplierDAO(string connectionString, string errorLogPath)
        {
            this.connectionString = connectionString;
            this.errorLogPath = errorLogPath;
        }

        public List<SupplierDO> ObtainTableInfo()
        {
            List<SupplierDO> supplierList = new List<SupplierDO>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                using (SqlCommand viewSupplierTable = new SqlCommand("VIEW_SUPPLIER_TABLE", sqlConnection))
                {
                    viewSupplierTable.CommandType = System.Data.CommandType.StoredProcedure;
                    viewSupplierTable.CommandTimeout = 90;

                    sqlConnection.Open();

                    using (SqlDataReader reader = viewSupplierTable.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            supplierList.Add(Mapper.ReaderToSupplier(reader));
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Logger.ErrorLogPath = errorLogPath;
                Logger.SqlExceptionLog(sqlEx);

                throw sqlEx;
            }
            return supplierList;
        }

        public SupplierDO ObtainSupplierSingle(int ID)
        {
            SupplierDO response = new SupplierDO();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                using (SqlCommand viewSupplierByID = new SqlCommand("VIEW_ROW_BY_ID", sqlConnection))
                {
                    viewSupplierByID.CommandType = System.Data.CommandType.StoredProcedure;
                    viewSupplierByID.CommandTimeout = 90;

                    viewSupplierByID.Parameters.AddWithValue("SupplierID", ID);

                    sqlConnection.Open();

                    using (SqlDataReader reader = viewSupplierByID.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            response = Mapper.ReaderToSupplier(reader);
                        }
                    }

                    sqlConnection.Close();
                }
            }
            catch (SqlException sqlEx)
            {
                Logger.ErrorLogPath = errorLogPath;
                Logger.SqlExceptionLog(sqlEx);

                throw sqlEx;
            }
            return response;
        }

        public int CreateNewSupplier(SupplierDO suppInfo)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                using (SqlCommand createSupplier = new SqlCommand("CREATE_SUPPLIER", sqlConnection))
                {
                    createSupplier.CommandType = System.Data.CommandType.StoredProcedure;
                    createSupplier.CommandTimeout = 90;

                    createSupplier.Parameters.AddWithValue("CompanyName", suppInfo.CompanyName);
                    createSupplier.Parameters.AddWithValue("ContactName", suppInfo.ContactName);
                    createSupplier.Parameters.AddWithValue("ContactTitle", suppInfo.ContactTitle);
                    createSupplier.Parameters.AddWithValue("Address", suppInfo.Address);
                    createSupplier.Parameters.AddWithValue("City", suppInfo.City);
                    createSupplier.Parameters.AddWithValue("Region", suppInfo.Region);
                    createSupplier.Parameters.AddWithValue("PostalCode", suppInfo.PostalCode);
                    createSupplier.Parameters.AddWithValue("Country", suppInfo.Country);
                    createSupplier.Parameters.AddWithValue("Phone", suppInfo.Phone);
                    createSupplier.Parameters.AddWithValue("Fax", suppInfo.Fax);
                    createSupplier.Parameters.AddWithValue("HomePage", suppInfo.HomePage);

                    sqlConnection.Open();
                    rowsAffected = createSupplier.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
            catch (SqlException sqlEx)
            {
                Logger.ErrorLogPath = errorLogPath;
                Logger.SqlExceptionLog(sqlEx);

                throw sqlEx;
            }
            return rowsAffected;
        }

        public void UpdateInformation(SupplierDO suppInfo)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                using (SqlCommand updateSupplier = new SqlCommand("UPDATE_SUPPLIER_INFO", sqlConnection))
                {
                    updateSupplier.CommandType = System.Data.CommandType.StoredProcedure;
                    updateSupplier.CommandTimeout = 90;

                    updateSupplier.Parameters.AddWithValue("supplierID", suppInfo.SupplierID);
                    updateSupplier.Parameters.AddWithValue("CompanyName", suppInfo.CompanyName);
                    updateSupplier.Parameters.AddWithValue("ContactName", suppInfo.ContactName);
                    updateSupplier.Parameters.AddWithValue("ContactTitle", suppInfo.ContactTitle);
                    updateSupplier.Parameters.AddWithValue("Address", suppInfo.Address);
                    updateSupplier.Parameters.AddWithValue("City", suppInfo.City);
                    updateSupplier.Parameters.AddWithValue("Region", suppInfo.Region);
                    updateSupplier.Parameters.AddWithValue("PostalCode", suppInfo.PostalCode);
                    updateSupplier.Parameters.AddWithValue("Country", suppInfo.Country);
                    updateSupplier.Parameters.AddWithValue("Phone", suppInfo.Phone);
                    updateSupplier.Parameters.AddWithValue("Fax", suppInfo.Fax);
                    updateSupplier.Parameters.AddWithValue("HomePage", suppInfo.HomePage);

                    sqlConnection.Open();
                    int i = updateSupplier.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
            catch (SqlException sqlEx)
            {
                Logger.ErrorLogPath = errorLogPath;
                Logger.SqlExceptionLog(sqlEx);

                throw sqlEx;
            }
        }

        public int DeleteSupplier(int ID)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                using (SqlCommand deleteSupplier = new SqlCommand("DELETE_SUPPLIER", sqlConnection))
                {
                    deleteSupplier.CommandType = System.Data.CommandType.StoredProcedure;
                    deleteSupplier.CommandTimeout = 90;
                    deleteSupplier.Parameters.AddWithValue("SupplierID", ID);

                    sqlConnection.Open();
                    rowsAffected = deleteSupplier.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
            catch (SqlException sqlEx)
            {
                Logger.ErrorLogPath = errorLogPath;
                Logger.SqlExceptionLog(sqlEx);

                throw sqlEx;
            }
            return rowsAffected;
        }
    }
}
