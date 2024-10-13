using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Zyael_Models.Clinics;
using Zyael_Models.DiagnosticLabs;
using Zyael_Models.Doctors;
using Zyael_Models.InternalDoctor;
using Zyael_Models.Masters;
using Zyael_Services.Con_Services;
using Zyael_Services.Con_Services.InternalDoctor;
using Zyael_Services.Con_Services.Masters;

namespace ZyaelAPI.Controllers.DiagnosticLabs
{
 
        [Route("api/[controller]")]
        public class DiagnosticLabProductController : ControllerBase
        {
            readonly IHttpContextAccessor _httpContextAccessor;
            readonly IHostEnvironment _hostingEnvironment;
            public DiagnosticLabProduct _daignosticlabproduct;


            public DiagnosticLabProductController(IHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IConfiguration config)
            {
                _hostingEnvironment = hostingEnvironment;
                _httpContextAccessor = httpContextAccessor;
            _daignosticlabproduct = new DiagnosticLabProduct(httpContextAccessor, config);
            }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("[action]")]
        public async Task<IActionResult> LabTestCategoryDetails_InsertUpdate(LabTestImageModel item)
        {
            LabTestImageModel test = new LabTestImageModel();
            if (item.LabTestCategoryImage != null)
            {
                try
                {
                    var samplefilepath = $"{this._hostingEnvironment.ContentRootPath}" + "/" + "LabTestCategoryImageUpload" + "/" + "LabTestCategoryImage" + "/";
                    var fileName = ContentDispositionHeaderValue.Parse(item.LabTestCategoryImage.ContentDisposition).FileName;
                    var filesize = ContentDispositionHeaderValue.Parse(item.LabTestCategoryImage.ContentDisposition).Size;
                    fileName = fileName.Contains("\\")
                     ? fileName.Trim('"').Substring(fileName.LastIndexOf("\\", StringComparison.Ordinal) + 1)
                    : fileName.Trim('"');
                    if (!Directory.Exists(samplefilepath))
                    {
                        Directory.CreateDirectory(samplefilepath);
                    }
                    var extension = Path.GetExtension(fileName);
                    var FileGuid = Guid.NewGuid();
                    var fullFilePath = Path.Combine(
                        "LabTestCategoryImageUpload" + "/",
                        FileGuid + extension);
                    item.LabTestCategoryImagePath = "/" + "LabTestCategoryImage" + "/" + FileGuid + extension;
                    item.LabTestCategoryImageName = fileName;
                    using (var stream = new FileStream(fullFilePath, FileMode.Create))
                    {
                        await item.LabTestCategoryImage.CopyToAsync(stream);
                    }
                    item.LabTestCategoryImagePath = "https://zyael-api.scm.azurewebsites.net/api/vfs/site/wwwroot/" + fullFilePath;
                }
                catch (Exception ex)
                {
                    item.LabTestCategoryImageName = "";
                }
            }


            var result = await _daignosticlabproduct.LabTestCategoryImageDetails_InsertUpdate(item);

            if (result == 0)
            {

                test.returnId = result;
                test.message = "Uploaded successfully";
                return Ok(test);


            }
            else if (result == 2)
            {
                test.returnId = result;
                test.message = "Updated successfully";
                return Ok(test);

            }
            return Ok(result);
        }


        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> LabTestDetails_InsertUpdate(LabTestDetailsModel item)
        {
            LabTestDetailsModel test = new LabTestDetailsModel();
            var result = await _daignosticlabproduct.LabTestDetails_InsertUpdate(item);
            return Ok(result);
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllLabTestDetails()
        {
            List<LabTestDetailsModel> list = new List<LabTestDetailsModel>();
            list = await _daignosticlabproduct.GetAllLabTestDetails();

            return Ok(list);

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetLabTestCategoryDetails()
        {
            List<LabTestImageModel> list = new List<LabTestImageModel>();
            list = await _daignosticlabproduct.GetLabTestCategoryDetails();

            return Ok(list);

        }


        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> LabTestDetails_InsertUpdateByDiagnosisLab(DiagnosisLabTestDetailsModel item)
        {
            DiagnosisLabTestDetailsModel test = new DiagnosisLabTestDetailsModel();
            var result = await _daignosticlabproduct.LabTestDetails_InsertUpdateByDiagnosisLab(item);
            return Ok(result);
        }


        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLabTestDetailsByDiagnosisLabVendorID(int DLVID)
        {
            List<DiagnosisLabTestDetailsModel> item = new List<DiagnosisLabTestDetailsModel>();
            if (DLVID > 0)
            {
                item = await _daignosticlabproduct.GetLabTestDetailsByDiagnosisLabVendorID(DLVID);
            }

            return Ok(item);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("[action]")]
        public async Task<IActionResult> HealthPackagesCategoryDetails_InsertUpdate(HealthPackagesCategoryModel item)
        {
            HealthPackagesCategoryModel test = new HealthPackagesCategoryModel();
            if (item.HealthPackageCategoryImage != null)
            {
                try
                {
                    var samplefilepath = $"{this._hostingEnvironment.ContentRootPath}" + "/" + "HealthPackageCategoryImageUpload" + "/" + "HealthPackageCategoryImage" + "/";
                    var fileName = ContentDispositionHeaderValue.Parse(item.HealthPackageCategoryImage.ContentDisposition).FileName;
                    var filesize = ContentDispositionHeaderValue.Parse(item.HealthPackageCategoryImage.ContentDisposition).Size;
                    fileName = fileName.Contains("\\")
                     ? fileName.Trim('"').Substring(fileName.LastIndexOf("\\", StringComparison.Ordinal) + 1)
                    : fileName.Trim('"');
                    if (!Directory.Exists(samplefilepath))
                    {
                        Directory.CreateDirectory(samplefilepath);
                    }
                    var extension = Path.GetExtension(fileName);
                    var FileGuid = Guid.NewGuid();
                    var fullFilePath = Path.Combine(
                        "HealthPackageCategoryImageUpload" + "/",
                        FileGuid + extension);
                    item.HealthPackageCategoryImagePath = "/" + "HealthPackageCategoryImage" + "/" + FileGuid + extension;
                    item.HealthPackageCategoryImageName = fileName;
                    using (var stream = new FileStream(fullFilePath, FileMode.Create))
                    {
                        await item.HealthPackageCategoryImage.CopyToAsync(stream);
                    }
                    item.HealthPackageCategoryImagePath = "https://zyael-api.scm.azurewebsites.net/api/vfs/site/wwwroot/" + fullFilePath;
                }
                catch (Exception ex)
                {
                    item.HealthPackageCategoryImageName = "";
                }
            }


            var result = await _daignosticlabproduct.HealthPackagesCategoryDetails_InsertUpdate(item);

            if (result == 0)
            {

                test.returnId = result;
                test.message = "Uploaded successfully";
                return Ok(test);


            }
            else if (result == 2)
            {
                test.returnId = result;
                test.message = "Updated successfully";
                return Ok(test);

            }
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetHealthPackagesCategoryDetails()
        {
            List<HealthPackagesCategoryModel> list = new List<HealthPackagesCategoryModel>();
            list = await _daignosticlabproduct.GetHealthPackagesCategoryDetails();

            return Ok(list);

        }


        [HttpPost("[action]")]
        public async Task<IActionResult> SetPackage(int PackageID,  string HealthPackageCategoryName, string HealthPackageName, [FromBody] List<LabTests> item)
        {

            var result = await _daignosticlabproduct.SetPackage(PackageID, HealthPackageCategoryName, HealthPackageName, item);

            return Ok(result);
        }


        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLabTestListDetailsByPackageName(string HealthPackageName)
        {
            List<HealthPackageModel> item = new List<HealthPackageModel>();
            
                item = await _daignosticlabproduct.GetLabTestListDetailsByPackageName(HealthPackageName);
            

            return Ok(item);
        }

        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllPackageDetails()
        {
            List<HealthPackageModel> item = new List<HealthPackageModel>();

            item = await _daignosticlabproduct.GetAllPackageDetails();


            return Ok(item);
        }
    }
}
