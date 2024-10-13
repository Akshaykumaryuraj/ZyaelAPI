using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_DAL.Hospital;
using Zyael_DAL.PharmacyDAL;
using Zyael_Models.Hospitals;
using Zyael_Models.PharmacyModel;
namespace Zyael_Services.Con_Services
{
    public class Pharmacy
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        public PharmacyDAL _pharmacydal;
        public Pharmacy(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _httpContextAccessor = httpContextAccessor;
            _pharmacydal = new PharmacyDAL(httpContextAccessor, config);
        }


        public async Task<PharmacyModel> PharmacyVendorCredentialAdd(int PVID)
        {
            try
            {
                var result = await _pharmacydal.PharmacyVendorCredentialAdd(PVID);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> PharmacyVendorCredentialDetails_InsertUpdate(PharmacyModel item)
        {
            try
            {
                var result = await _pharmacydal.PharmacyVendorCredentialDetails_InsertUpdate(item);
                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<PharmacyModel> PharmacyVendorCredentialDetailsDelete(int PVID)
        {
            try
            {
                var result = await _pharmacydal.PharmacyVendorCredentialDetailsDelete(PVID);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<PharmacyModel>> GetAllPharmacyVendorCredentialDetails()
        {
            try
            {
                var result = await _pharmacydal.GetAllPharmacyVendorCredentialDetails();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<List<PharmacyModel>> GetAllPharmacyVendorProfileDetails()
        {
            try
            {
                var result = await _pharmacydal.GetAllPharmacyVendorProfileDetails();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
