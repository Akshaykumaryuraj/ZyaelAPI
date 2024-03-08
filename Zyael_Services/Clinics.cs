using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_DAL.Clinic;
using Zyael_DAL.Hospital;
using Zyael_Models.Clinics;
using Zyael_Models.Hospitals;

namespace Zyael_Services
{
    public class Clinic
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        public ClinicDAL _clinicdal;
        public Clinic(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            this._httpContextAccessor = httpContextAccessor;
            _clinicdal = new ClinicDAL(httpContextAccessor, config);
        }
        public async Task<ClinicModel> ClinicCredentialAdd(int ClinicVendorID)
        {
            try
            {
                var result = await _clinicdal.ClinicCredentialAdd(ClinicVendorID);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> ClinicCredentialDetails_InsertUpdate(ClinicModel item)
        {
            try
            {
                var result = await _clinicdal.ClinicCredentialDetails_InsertUpdate(item);
                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


        public async Task<ClinicModel> ClinicCredentialDetailsDelete(int ClinicVendorID)
        {
            try
            {
                var result = await _clinicdal.ClinicCredentialDetailsDelete(ClinicVendorID);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



    }
}
