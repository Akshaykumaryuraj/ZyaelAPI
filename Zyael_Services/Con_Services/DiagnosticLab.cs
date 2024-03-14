using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_DAL.DiagnosticLab;
using Zyael_DAL.Hospital;
using Zyael_Models.DiagnosticLabs;
using Zyael_Models.Hospitals;

namespace Zyael_Services.Con_Services
{
    public class DiagnosticLab
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        public DiagnosticDAL _diagnosticdal;
        public DiagnosticLab(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _httpContextAccessor = httpContextAccessor;
            _diagnosticdal = new DiagnosticDAL(httpContextAccessor, config);
        }

        public async Task<DiagnosticLabModel> DiagnosticLabCredentialAdd(int DLVID)
        {
            try
            {
                var result = await _diagnosticdal.DiagnosticLabCredentialAdd(DLVID);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> DiagnosticLabCredentialDetails_InsertUpdate(DiagnosticLabModel item)
        {
            try
            {
                var result = await _diagnosticdal.DiagnosticLabCredentialDetails_InsertUpdate(item);
                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<HospitalModel> DiagnosticLabCredentialDetailsDelete(int DLVID)
        {
            try
            {
                var result = await _diagnosticdal.DiagnosticLabCredentialDetailsDelete(DLVID);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<List<DiagnosticLabModel>> GetAllDiagnosticCredentialDetails()
        {
            try
            {
                var result = await _diagnosticdal.GetAllDiagnosticCredentialDetails();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
