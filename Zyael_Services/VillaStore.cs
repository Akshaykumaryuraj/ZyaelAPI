using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyael_Models;

namespace Zyael_Services
{
    public static class VillaStore
    {
        public static List<VillaDTO> GetVillaList = new List<VillaDTO>
            {
                new VillaDTO {Id=1,Name="pool villa"},
                new VillaDTO {Id=2,Name="beach villa"},
                new VillaDTO {Id=3,Name="lake villa"},

            };
    }
}
