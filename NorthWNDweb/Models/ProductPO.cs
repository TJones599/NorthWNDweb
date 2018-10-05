using System;

namespace NorthWNDweb.Models
{
    public class ProductPO
    {
        public string Name { get; set; }

        public string  CategoryName { get; set; }

        public string QuantityPerUnit { get; set; }

        public decimal UnitPrice { get; set; }

        public Int16 UnitsInStock { get; set; }

        public Int16 UnitsOnOrder { get; set; }

        public Int16 ReorderLevel { get; set; }

        public bool Discontinued { get; set; }
    }
}