using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_DAL.Doctors;
using Zyael_DAL.Masters;
using Zyael_Models.Doctors;
using Zyael_Models.Masters;

namespace Zyael_Services.Con_Services.Masters
{
    public class Symptoms
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        public SymptomsDAL _symptomsdal;
        public Symptoms(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _httpContextAccessor = httpContextAccessor;
            _symptomsdal = new SymptomsDAL(httpContextAccessor, config);
        }

        public async Task<SymptomsModel> SetSymptoms(string SymptomTitle, [FromBody] List<symptomslist> item)
        {
            try
            {
                var result = await _symptomsdal.SetSymptoms(SymptomTitle, item);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }





        public async Task<int> SymptomImageUpload(symptomsImage img)
        {
            try
            {
                var result = await _symptomsdal.SymptomImageUpload(img);
                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public async Task<List<symptomslist>> GetSymptoms()
        {
            try
            {
                var result = await _symptomsdal.GetSymptoms();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<List<symptomslist>> GetSymptoms(string SymptomTitle)
        {
            try
            {
                var result = await _symptomsdal.GetSymptoms(SymptomTitle);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
