using System.Collections.Generic;

namespace NorthWNDweb.Models
{
    public class SupplierProducts
    {
        public List<ProductPO> products { get; set; }

        public SuppliersPO supplier { get; set; }
    }
}