using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_DAL;
using Zyael_DAL.Hospital;
using Zyael_Models.Hospitals;

namespace Zyael_Services
{
    public class Hospital
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        public HospitalDAL _hospitaldal;
        public Hospital(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            this._httpContextAccessor = httpContextAccessor;
            _hospitaldal = new HospitalDAL(httpContextAccessor, config);
        }

        public async Task<HospitalModel> HospitalCredentialAdd(int HospitalVendorID)
        {
            try
            {
                var result = await _hospitaldal.HospitalCredentialAdd(HospitalVendorID);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<int> HospitalCredentialDetails_InsertUpdate(HospitalModel item)
        {
            try
            {
                var result = await _hospitaldal.HospitalCredentialDetails_InsertUpdate(item);
                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<HospitalModel> HospitalCredentialDetailsDelete(int HospitalVendorID)
        {
            try
            {
                var result = await _hospitaldal.HospitalCredentialDetailsDelete(HospitalVendorID);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public async Task<List<HospitalModel>> GetAllHospitalCredentialDetails()
        {
            try
            {
                var result = await _hospitaldal.GetAllHospitalCredentialDetails();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
