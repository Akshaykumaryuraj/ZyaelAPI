using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_Models.Clinics;
using Zyael_Models.DiagnosticLabs;
using Zyael_Models.Doctors;
using Zyael_Models.InternalDoctor;
using Zyael_Models.Masters;

namespace Zyael_DAL.DiagnosticLab
{
    public class DiagnosticLabProductDAL : SqlDAL
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        public DiagnosticLabProductDAL(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            this._httpContextAccessor = httpContextAccessor;
            _config = config;
        }

        public async Task<int> LabTestCategoryImageDetails_InsertUpdate(LabTestImageModel item)
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
                                LabTestCategoryID = item.LabTestCategoryID,
                                LabTestCategoryImageID = item.LabTestCategoryImageID,
                                LabTestCategoryCode = item.LabTestCategoryCode,
                                LabTestCategoryName = item.LabTestCategoryName,
                                LabTestCategoryImageName = item.LabTestCategoryImageName,
                                LabTestCategoryImagePath = item.LabTestCategoryImagePath,
                                status = item.status,
                                TopPriority = item.TopPriority

                            };
                    var response = await con.ExecuteScalarAsync<int>("Sp_SetLabTestCategoryDetails", Param, commandType: System.Data.CommandType.StoredProcedure);
                    return response;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


        public async Task<int> LabTestDetails_InsertUpdate(LabTestDetailsModel item)
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
                                LabTestID = item.LabTestID,
                                LabTestName = item.LabTestName,
                                LabTestSubTitle_1 = item.LabTestSubTitle_1,
                                LabTestSubTitle_2 = item.LabTestSubTitle_2,
                                LabTestCode = item.LabTestCode,
                                LabTestPrice = item.LabTestPrice,
                                LabTestDiscountPrice = item.LabTestDiscountPrice,
                                LabTestOffer = item.LabTestOffer,
                                VisitForHome = item.VisitForHome,
                                VisitForCentre = item.VisitForCentre,
                                AboutLabTest_1 = item.AboutLabTest_1,
                                AboutLabTest_2 = item.AboutLabTest_2,
                                Prerequisites_1 = item.Prerequisites_1,
                                Prerequisites_2 = item.Prerequisites_2,
                                DiseasesCovered_1 = item.DiseasesCovered_1,
                                DiseasesCovered_2 = item.DiseasesCovered_2,
                                DiseasesCovered_3 = item.DiseasesCovered_3,
                                BodyFunction_1 = item.BodyFunction_1,
                                BodyFunction_2 = item.BodyFunction_2,
                                BodyFunction_3 = item.BodyFunction_3,
                                LifeStyle_1 = item.LifeStyle_1,
                                LifeStyle_2 = item.LifeStyle_2,
                                LifeStyle_3 = item.LifeStyle_3,
                                LabTestCategoryName = item.LabTestCategoryName,
                                LabTestReportIn = item.LabTestReportIn



                            };
                    var response = await con.ExecuteScalarAsync<int>("Sp_SetLabTestDetails", Param, commandType: System.Data.CommandType.StoredProcedure);
                    return response;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<List<LabTestDetailsModel>> GetAllLabTestDetails()
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
                    return (await con.QueryAsync<LabTestDetailsModel>("Sp_GetAllLabTestDetails", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<int> LabTestDetails_InsertUpdateByDiagnosisLab(DiagnosisLabTestDetailsModel item)
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
                                LabTestID = item.LabTestID,
                                DLVID = item.DLVID,
                                DLVPID = item.DLVPID,
                                LabTestName = item.LabTestName,
                                LabTestSubTitle_1 = item.LabTestSubTitle_1,
                                LabTestSubTitle_2 = item.LabTestSubTitle_2,
                                LabTestCode = item.LabTestCode,
                                LabTestPrice = item.LabTestPrice,
                                LabTestDiscountPrice = item.LabTestDiscountPrice,
                                LabTestOffer = item.LabTestOffer,
                                VisitForHome = item.VisitForHome,
                                VisitForCentre = item.VisitForCentre,
                                AboutLabTest_1 = item.AboutLabTest_1,
                                AboutLabTest_2 = item.AboutLabTest_2,
                                Prerequisites_1 = item.Prerequisites_1,
                                Prerequisites_2 = item.Prerequisites_2,
                                DiseasesCovered_1 = item.DiseasesCovered_1,
                                DiseasesCovered_2 = item.DiseasesCovered_2,
                                DiseasesCovered_3 = item.DiseasesCovered_3,
                                BodyFunction_1 = item.BodyFunction_1,
                                BodyFunction_2 = item.BodyFunction_2,
                                BodyFunction_3 = item.BodyFunction_3,
                                LifeStyle_1 = item.LifeStyle_1,
                                LifeStyle_2 = item.LifeStyle_2,
                                LifeStyle_3 = item.LifeStyle_3,
                                LabTestCategoryName = item.LabTestCategoryName,
                                LabTestReportIn = item.LabTestReportIn



                            };
                    var response = await con.ExecuteScalarAsync<int>("Sp_SetDiagnosisLabTestDetails", Param, commandType: System.Data.CommandType.StoredProcedure);
                    return response;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<List<DiagnosisLabTestDetailsModel>> GetLabTestDetailsByDiagnosisLabVendorID(int DLVID)

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
                                DLVID = DLVID


                            };
                    return (await con.QueryAsync<DiagnosisLabTestDetailsModel>("SP_GetLabTestDetailsByDiagnosisLabVendorID", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();


                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<LabTestImageModel>> GetLabTestCategoryDetails()
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
                    return (await con.QueryAsync<LabTestImageModel>("Sp_GetLabTestCategoryDetails", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<int> HealthPackagesCategoryDetails_InsertUpdate(HealthPackagesCategoryModel item)
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
                                HealthPackageCategoryID = item.HealthPackageCategoryID,
                                HealthPackageCategoryImageID = item.HealthPackageCategoryImageID,
                                HealthPackageCategoryName = item.HealthPackageCategoryName,
                                HealthPackageName = item.HealthPackageName,
                                HealthPackageCategoryCode = item.HealthPackageCategoryCode,
                                HealthPackageCategoryImageName = item.HealthPackageCategoryImageName,
                                HealthPackageCategoryImagePath = item.HealthPackageCategoryImagePath,
                                status = item.status,
                                TopPriority = item.TopPriority,
                                Price = item.Price,
                                DiscountPrice = item.DiscountPrice,
                                VisitType = item.VisitType

                            };
                    var response = await con.ExecuteScalarAsync<int>("Sp_SetHealthPackageCategoryDetails", Param, commandType: System.Data.CommandType.StoredProcedure);
                    return response;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }



        public async Task<List<HealthPackagesCategoryModel>> GetHealthPackagesCategoryDetails()
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
                    return (await con.QueryAsync<HealthPackagesCategoryModel>("Sp_GetHealthPackageCategoryDetails", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public async Task<HealthPackagesCategoryModel> SetPackage(int PackageID, string HealthPackageCategoryName, string HealthPackageName, [FromBody] List<LabTests> item)
        {
            {
                HealthPackagesCategoryModel result = new HealthPackagesCategoryModel();
                //IEnumerable<string> count = SlotsAvailable.Select(count = > count.ToString());

                try
                {

                    var Connection = new SqlConnection(_config.GetConnectionString("DefautConnection"));
                    using (SqlConnection con = Connection)
                    {
                        con.Open();
                        var del =
                               new
                               {
                                   PackageID = PackageID,
                                   HealthPackageCategoryName = HealthPackageCategoryName,
                                   HealthPackageName = HealthPackageName

                               };
                        var response = await con.ExecuteScalarAsync<HealthPackagesCategoryModel>("SP_SetPackageDetailsDelete", del, commandType: System.Data.CommandType.StoredProcedure);
                        foreach (var item1 in item)
                        {


                            var Param =
                                    new
                                    {
                                        HealthPackageCategoryName = HealthPackageCategoryName,
                                        HealthPackageName = HealthPackageName,
                                        LabTestName = item1.LabTestName,
                                        LabTestSubTitle_1 = item1.LabTestSubTitle_1

                                    };
                            await con.ExecuteScalarAsync<HealthPackagesCategoryModel>("SP_SetPackageDetails", Param, commandType: System.Data.CommandType.StoredProcedure);

                        }

                        result.LabTests = item.ToList();

                        return result;
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public async Task<List<HealthPackageModel>> GetLabTestListDetailsByPackageName(string HealthPackageName)
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
                                HealthPackageName = HealthPackageName

                            };
                    return (await con.QueryAsync<HealthPackageModel>("Sp_GetLabTestListDetailsByPackageName", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();


                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<List<HealthPackageModel>> GetAllPackageDetails()
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
                    return (await con.QueryAsync<HealthPackageModel>("Sp_GetAllPackageDetails", Param, commandType: System.Data.CommandType.StoredProcedure)).ToList();


                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
