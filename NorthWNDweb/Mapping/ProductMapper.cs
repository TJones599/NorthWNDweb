using NorthWNDSuppliers_DAL.Models;
using NorthWNDweb.Models;
using System.Collections.Generic;

namespace NorthWNDweb.Mapping
{
    public class ProductMapper
    {
        public static ProductPO MapDoToPo(ProductDO from)
        {
            ProductPO to = new ProductPO();
            
            to.Name = from.Name;
            to.CategoryName = from.CategoryName;
            to.QuantityPerUnit = from.QuantityPerUnit;
            to.UnitPrice = from.UnitPrice;
            to.UnitsInStock = from.UnitsInStock;
            to.UnitsOnOrder = from.UnitsOnOrder;
            to.ReorderLevel = from.ReorderLevel;
            to.Discontinued = from.Discontinued;

            return to;
        }

        public static List<ProductPO> MapDoListToPo(List<ProductDO> from)
        {
            List<ProductPO> to = new List<ProductPO>();

            foreach(ProductDO item in from)
            {
                ProductPO temp = new ProductPO();

                temp.Name = item.Name;
                temp.CategoryName = item.CategoryName;
                temp.QuantityPerUnit = item.QuantityPerUnit;
                temp.UnitPrice = item.UnitPrice;
                temp.UnitsInStock = item.UnitsInStock;
                temp.UnitsOnOrder = item.UnitsOnOrder;
                temp.ReorderLevel = item.ReorderLevel;
                temp.Discontinued = item.Discontinued;

                to.Add(temp);
            }

            return to;
        }
    }
}