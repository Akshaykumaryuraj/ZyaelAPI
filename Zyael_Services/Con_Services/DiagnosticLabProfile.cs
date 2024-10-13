using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_DAL.DiagnosticLab;
using Zyael_DAL.Doctors;
using Zyael_Models.DiagnosticLabs;
using Zyael_Models.Doctors;

namespace Zyael_Services.Con_Services
{
    public class DiagnosticLabProfile
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        public DiagnosticProfileDAL _diagnosticprofiledal;
        public DiagnosticLabProfile(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _httpContextAccessor = httpContextAccessor;
            _diagnosticprofiledal = new DiagnosticProfileDAL(httpContextAccessor, config);
        }

        public async Task<List<DiagnosticLabModel>> GetAllDiagnosticProfileDetails()
        {
            try
            {
                var result = await _diagnosticprofiledal.GetAllDiagnosticProfileDetails();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<DiagnosticLabModel> DiagnosticLabProfileDetailsByID(int DLVPID)
        {
            try
            {
                var result = await _diagnosticprofiledal.DiagnosticLabProfileDetailsByID(DLVPID);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<int> DiagnosticLabProfileImageDetails_InsertUpdate(DiagnosticLabProfileImageModel item)
        {
            try
            {
                var result = await _diagnosticprofiledal.DiagnosticLabProfileImageDetails_InsertUpdate(item);
                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
