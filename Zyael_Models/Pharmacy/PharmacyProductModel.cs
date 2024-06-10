using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zyael_Models.Pharmacy
{
    public class PharmacyProductModel
    {
        public int PVID { get; set; }
        public int ProductID { get; set; }
        public int ProductCategoryID { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string ProductBrand { get; set; }
        public int ProductMRP { get; set; }
        public string ProductQuantity { get; set; }
        public string ProductInfo { get; set; }
        public string ProductManufacturer { get; set; }
        public string ProductHighlights { get; set; }
        public string ProductHighlights1 { get; set; }
        public string ProductDescription { get; set; }
        public string ProductBenefits { get; set; }
        public string ProductBenefits1 { get; set; }
        public string ProductBenefits2 { get; set; }
        public string ProductDisclaimer { get; set; }
        public string ProductReturnPolicy { get; set; }
        public int returnId { get; set; }
        public string message { get; set; }
        public string ProductCategory { get; set; }
        public string data { get; set; }

    }
}
