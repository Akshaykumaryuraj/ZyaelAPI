using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_DAL.DiagnosticLab;
using Zyael_DAL.PharmacyDAL;

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
    }
}
