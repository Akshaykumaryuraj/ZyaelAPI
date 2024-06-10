using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_DAL.Doctors;
using Zyael_DAL.PharmacyDAL;
using Zyael_Models.Doctors;
using Zyael_Models.Pharmacy;
using Zyael_Models.PharmacyModel;

namespace Zyael_Services.Con_Services
{
    public class PharmacyProduct
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        public PharmacyProductDAL _pharmacyproductdal;
        public PharmacyProduct(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _httpContextAccessor = httpContextAccessor;
            _pharmacyproductdal = new PharmacyProductDAL(httpContextAccessor, config);
        }

        public async Task<PharmacyProductModel> PharmacyProductAdd(int ProductID)
        {
            try
            {
                var result = await _pharmacyproductdal.PharmacyProductAdd(ProductID);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> PharmacyProductAdd_InsertUpdate(PharmacyProductModel item)
        {
            try
            {
                var result = await _pharmacyproductdal.PharmacyProductAdd_InsertUpdate(item);
                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<PharmacyProductModel> PharmacyProductAddDetailsDelete(int ProductID)
        {
            try
            {
                var result = await _pharmacyproductdal.PharmacyProductAddDetailsDelete(ProductID);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<int> PharmacyProductCategory_InsertUpdate(PharmacyCategoryModel item)
        {
            try
            {
                var result = await _pharmacyproductdal.PharmacyProductCategory_InsertUpdate(item);
                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<PharmacyCategoryModel> PharmacyProductCategoryDetailsDelete(int ProductCategoryID)
        {
            try
            {
                var result = await _pharmacyproductdal.PharmacyProductCategoryDetailsDelete(ProductCategoryID);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<PharmacyCategoryModel>> GetAllPharmacyProductCategory()
        {
            try
            {
                var result = await _pharmacyproductdal.GetAllPharmacyProductCategory();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<PharmacyProductModel>> GetAllPharmacyProductDetails()
        {
            try
            {
                var result = await _pharmacyproductdal.GetAllPharmacyProductDetails();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<List<PharmacyProductModel>> PharmacyProductDetailsSearchBy(string data)
        {
            try
            {
                var result = await _pharmacyproductdal.PharmacyProductDetailsSearchBy(data);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}


