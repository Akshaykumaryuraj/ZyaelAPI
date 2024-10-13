using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_DAL.Clinic;
using Zyael_DAL.DiagnosticLab;
using Zyael_DAL.Doctors;
using Zyael_DAL.InternalDoctor;
using Zyael_DAL.Masters;
using Zyael_DAL.PharmacyDAL;
using Zyael_Models.Clinics;
using Zyael_Models.DiagnosticLabs;
using Zyael_Models.Doctors;
using Zyael_Models.InternalDoctor;
using Zyael_Models.Masters;

namespace Zyael_Services.Con_Services
{
    public class DiagnosticLabProduct
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        public DiagnosticLabProductDAL _daignosticlabproductdal;
        public DiagnosticLabProduct(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _httpContextAccessor = httpContextAccessor;
            _daignosticlabproductdal = new DiagnosticLabProductDAL(httpContextAccessor, config);
        }
        public async Task<int> LabTestCategoryImageDetails_InsertUpdate(LabTestImageModel item)
        {
            try
            {
                var result = await _daignosticlabproductdal.LabTestCategoryImageDetails_InsertUpdate(item);
                return result;
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
                var result = await _daignosticlabproductdal.LabTestDetails_InsertUpdate(item);
                return result;
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
                var result = await _daignosticlabproductdal.GetAllLabTestDetails();
                return result;
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
                var result = await _daignosticlabproductdal.LabTestDetails_InsertUpdateByDiagnosisLab(item);
                return result;
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
                var result = await _daignosticlabproductdal.GetLabTestDetailsByDiagnosisLabVendorID(DLVID);
                return result;
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
                var result = await _daignosticlabproductdal.GetLabTestCategoryDetails();
                return result;
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
                var result = await _daignosticlabproductdal.HealthPackagesCategoryDetails_InsertUpdate(item);
                return result;
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
                var result = await _daignosticlabproductdal.GetHealthPackagesCategoryDetails();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<HealthPackagesCategoryModel> SetPackage(int PackageID, string HealthPackageCategoryName, string HealthPackageName, [FromBody] List<LabTests> item)
        {
            try
            {
                var result = await _daignosticlabproductdal.SetPackage(PackageID, HealthPackageCategoryName, HealthPackageName, item);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<HealthPackageModel>> GetLabTestListDetailsByPackageName(string HealthPackageName)
        {
            try
            {
                var result = await _daignosticlabproductdal.GetLabTestListDetailsByPackageName(HealthPackageName);
                return result;
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
                var result = await _daignosticlabproductdal.GetAllPackageDetails();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
