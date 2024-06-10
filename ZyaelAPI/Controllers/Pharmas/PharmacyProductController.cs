using Microsoft.AspNetCore.Mvc;
using Zyael_Models.Doctors;
using Zyael_Models.Pharmacy;
using Zyael_Models.PharmacyModel;
using Zyael_Services.Con_Services;

namespace ZyaelAPI.Controllers.Pharmas
{
    [Route("api/[controller]")]
    public class PharmacyProductController : ControllerBase
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IHostEnvironment _hostingEnvironment;
        public PharmacyProduct _pharmacyproduct;


        public PharmacyProductController(IHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _pharmacyproduct = new PharmacyProduct(httpContextAccessor, config);
        }


        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PharmacyProductAdd(int ProductID)
        {
            PharmacyProductModel item = new PharmacyProductModel();
            if (ProductID > 0)
            {
                item = await _pharmacyproduct.PharmacyProductAdd(ProductID);

                item.ProductID = ProductID;
            }

            return Ok(item);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetAllPharmacyProductDetails()
        {
            List<PharmacyProductModel> list = new List<PharmacyProductModel>();
            list = await _pharmacyproduct.GetAllPharmacyProductDetails();

            return Ok(list);

        }




        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<IActionResult> PharmacyProductAdd_InsertUpdate(PharmacyProductModel item)
        {
            PharmacyProductModel test = new PharmacyProductModel();

            var result = await _pharmacyproduct.PharmacyProductAdd_InsertUpdate(item);

            if (result == 0)
            {

                test.returnId = result;
                test.message = "added successfully";
                return Ok(test);


            }
            else if (result == 2)
            {
                test.returnId = result;
                test.message = "updated successfully";
                return Ok(test);

            }
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete]

        public async Task<IActionResult> PharmacyProductAddDetailsDelete(int ProductID)
        {
            //HospitalModel result = new HospitalModel();

            var respose = await _pharmacyproduct.PharmacyProductAddDetailsDelete(ProductID);
            if (Response != null)
            {
                return BadRequest("not found");


            }
            return Ok(respose);

        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("[action]")]
        public async Task<IActionResult> PharmacyProductCategory_InsertUpdate(PharmacyCategoryModel item)
        {
            PharmacyCategoryModel test = new PharmacyCategoryModel();

            var result = await _pharmacyproduct.PharmacyProductCategory_InsertUpdate(item);

            if (result == 0)
            {

                test.returnId = result;
                test.message = "added successfully";
                return Ok(test);


            }
            else if (result == 2)
            {
                test.returnId = result;
                test.message = "updated successfully";
                return Ok(test);

            }
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("[action]")]
        public async Task<IActionResult> PharmacyProductCategoryDetailsDelete(int ProductCategoryID)
        {
            //HospitalModel result = new HospitalModel();

            var respose = await _pharmacyproduct.PharmacyProductCategoryDetailsDelete(ProductCategoryID);
            if (Response != null)
            {
                return BadRequest("not found");


            }
            return Ok(respose);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPharmacyProductCategory()
        {
            List<PharmacyCategoryModel> list = new List<PharmacyCategoryModel>();
            list = await _pharmacyproduct.GetAllPharmacyProductCategory();

            return Ok(list);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("[action]")]
        public async Task<IActionResult> PharmacyProductDetailsSearchBy(string data)
        {
            List<PharmacyProductModel> result = new List<PharmacyProductModel>();

            result = await _pharmacyproduct.PharmacyProductDetailsSearchBy(data);


            return Ok(result);
        }

    }
}
