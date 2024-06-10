using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_DAL;
using Zyael_Models.Doctors;
using Zyael_Models.Pharmacy;
using Zyael_Models.PharmacyModel;

namespace Zyael_DAL.PharmacyDAL
{
    public class PharmacyProductDAL : SqlDAL
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        public PharmacyProductDAL(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            this._httpContextAccessor = httpContextAccessor;
            _config = config;
        }


        public async Task<PharmacyProductModel> PharmacyProductAdd(int ProductID)
        {
            try
            {
                var Connection = new SqlConnection(_config.GetConnectionString("DefautConnection"));
                using (SqlConnection con = Connection)
                {
                    con.Open();
                    var Param =
                            new
                            {
                                ProductID = ProductID

                            };
                    return (await con.QueryAsync<PharmacyProductModel>("Sp_GetPharmacyProductDetailsById", Param, commandType: System.Data.CommandType.StoredProcedure)).FirstOrDefault();
                }
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
                var Connection = new SqlConnection(_config.GetConnectionString("DefautConnection"));
                using (SqlConnection con = Connection)
                {
                    con.Open();
                    var Param =
                            new
                            {
                                PVID = item.PVID,
                                ProductID = item.ProductID,
                                ProductName = item.ProductName,
                                ProductCode = item.ProductCode,
                                ProductBrand = item.ProductBrand,
                                ProductMRP = item.ProductMRP,
                                ProductQuantity = item.ProductQuantity,
                                ProductInfo = item.ProductInfo,
                                ProductManufacturer = item.ProductManufacturer,
                                ProductHighlights = item.ProductHighlights,
                                ProductHighlights1 = item.ProductHighlights1,
                                ProductDescription = item.ProductDescription,
                                ProductBenefits = item.ProductBenefits,
                                ProductBenefits1 = item.ProductBenefits1,
                                ProductBenefits2 = item.ProductBenefits2,
                                ProductDisclaimer = item.ProductDisclaimer,
                                ProductReturnPolicy = item.ProductReturnPolicy,
                                ProductCategory=item.ProductCategory






                            };
                    var response = await con.ExecuteScalarAsync<int>("Sp_SetPharmacyProductDetails", Param, commandType: System.Data.CommandType.StoredProcedure);
                    return response;
                }
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

                var Connection = new SqlConnection(_config.GetConnectionString("DefautConnection"));
                using (SqlConnection con = Connection)
                {
                    con.Open();
                    var Param =
                            new
                            {
                                ProductID = ProductID

                            };
                    var response = await con.ExecuteScalarAsync<PharmacyProductModel>("SP_getPharmacyProductAddDetailsDelete", Param, commandType: System.Data.CommandType.StoredProcedure);
                    return response;
                }
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
                var Connection = new SqlConnection(_config.GetConnectionString("DefautConnection"));
                using (SqlConnection con = Connection)
                {
                    con.Open();
                    var Param =
                            new
                            {
                                ProductCategoryID = item.ProductCategoryID,
                                ProductCategory = item.ProductCategory


                            };
                    var response = await con.ExecuteScalarAsync<int>("Sp_SetPharmacyProductCategoryDetails", Param, commandType: System.Data.CommandType.StoredProcedure);
                    return response;
                }
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

                var Connection = new SqlConnection(_config.GetConnectionString("DefautConnection"));
                using (SqlConnection con = Connection)
                {
                    con.Open();
                    var Param =
                            new
                            {
                                ProductCategoryID = ProductCategoryID

                            };
                    var response = await con.ExecuteScalarAsync<PharmacyCategoryModel>("", Param, commandType: System.Data.CommandType.StoredProcedure);
                    return response;
                }
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
                var Connection = new SqlConnection(_config.GetConnectionString("DefautConnection"));
                using (SqlConnection con = Connection)
                {
                    con.Open();
                    var Param =
                            new
                            {

                            };
                    return (await con.QueryAsync<PharmacyCategoryModel>("Sp_GetAllPharmacyProductCategoryDetails", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();
                }
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
                var Connection = new SqlConnection(_config.GetConnectionString("DefautConnection"));
                using (SqlConnection con = Connection)
                {
                    con.Open();
                    var Param =
                            new
                            {

                            };
                    return (await con.QueryAsync<PharmacyProductModel>("Sp_GetAllPharmacyProductDetails", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();
                }
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

                var Connection = new SqlConnection(_config.GetConnectionString("DefautConnection"));
                using (SqlConnection con = Connection)
                {
                    con.Open();
                    var Param =
                            new
                            {
                                data = data

                            };
                    return (await con.QueryAsync<PharmacyProductModel>("Sp_searchPharmacyProductDetailsSearchBy", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();


                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        

    }
}

