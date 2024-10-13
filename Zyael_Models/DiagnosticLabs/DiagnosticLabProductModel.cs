using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zyael_Models.DiagnosticLabs
{
    public class DiagnosticLabProductModel
    {
        public int DLID { get; set; }
    }

    public class LabTestImageModel
    {
        public int LabTestCategoryID { get; set; }
        public int LabTestCategoryImageID { get; set; }
        public string LabTestCategoryName { get; set; }
        public string LabTestCategoryCode { get; set; }
        public IFormFile LabTestCategoryImage { get; set; }

        public string LabTestCategoryImageName { get; set; }
        public string LabTestCategoryImagePath { get; set; }
        public int returnId { get; set; }
        public string message { get; set; }
        public bool status { get; set; }
        public bool TopPriority { get; set; }
    }


    public class LabTestDetailsModel
    {
        public int LabTestID { get; set; }
        public string LabTestName { get; set; }
        public string LabTestSubTitle_1 { get; set; }
        public string LabTestSubTitle_2 { get; set; }
        public string LabTestCode { get; set; }
        public int LabTestPrice { get; set; }
        public int LabTestDiscountPrice { get; set; }
        public string LabTestOffer { get; set; }
        public string LabTestReportIn { get; set; }
        public bool VisitForHome{ get; set; }
        public bool VisitForCentre{ get; set; }
        public string AboutLabTest_1 { get; set; }
        public string AboutLabTest_2 { get; set; }
        public string Prerequisites_1 { get; set; }
        public string Prerequisites_2 { get; set; }
        public string DiseasesCovered_1  { get; set; }
        public string DiseasesCovered_2  { get; set; }
        public string DiseasesCovered_3  { get; set; }
        public string BodyFunction_1  { get; set; }
        public string BodyFunction_2  { get; set; }
        public string BodyFunction_3  { get; set; }
        public string LifeStyle_1 { get; set; }
        public string LifeStyle_2 { get; set; }
        public string LifeStyle_3 { get; set; }
        public string LabTestCategoryName { get; set; }



    }
    public class DiagnosisLabTestDetailsModel
    {
        public int LabTestID { get; set; }
        public int DLVID { get; set; }
        public int DLVPID { get; set; }
        public string UserName { get; set; }

        public string LabTestName { get; set; }
        public string LabTestSubTitle_1 { get; set; }
        public string LabTestSubTitle_2 { get; set; }
        public string LabTestCode { get; set; }
        public int LabTestPrice { get; set; }
        public int LabTestDiscountPrice { get; set; }
        public string LabTestOffer { get; set; }
        public string LabTestReportIn { get; set; }
        public bool VisitForHome { get; set; }
        public bool VisitForCentre { get; set; }
        public string AboutLabTest_1 { get; set; }
        public string AboutLabTest_2 { get; set; }
        public string Prerequisites_1 { get; set; }
        public string Prerequisites_2 { get; set; }
        public string DiseasesCovered_1 { get; set; }
        public string DiseasesCovered_2 { get; set; }
        public string DiseasesCovered_3 { get; set; }
        public string BodyFunction_1 { get; set; }
        public string BodyFunction_2 { get; set; }
        public string BodyFunction_3 { get; set; }
        public string LifeStyle_1 { get; set; }
        public string LifeStyle_2 { get; set; }
        public string LifeStyle_3 { get; set; }
        public string LabTestCategoryName { get; set; }



    }


    public class HealthPackagesCategoryModel
    {
        public int HealthPackageCategoryID { get; set; }
        public int HealthPackageCategoryImageID { get; set; }
        public string HealthPackageCategoryName { get; set; }
        public string HealthPackageName { get; set; }
        public string LabTestName { get; set; }
        public string LabTestSubTitle_1 { get; set; }
        public string HealthPackageCategoryCode { get; set; }
        public IFormFile HealthPackageCategoryImage { get; set; }
       
        public string HealthPackageCategoryImageName { get; set; }
        public string HealthPackageCategoryImagePath { get; set; }
        public int returnId { get; set; }
        public string message { get; set; }
        public string VisitType { get; set; }
        public bool status { get; set; }
        public bool TopPriority { get; set; }
        public int Price { get; set; }
        public int DiscountPrice { get; set; }
        public List<LabTests> LabTests { get; set; }

    }


    public class HealthPackageModel
    {
       
        public string HealthPackageCategoryName { get; set; }
        public string HealthPackageName { get; set; }
        public string LabTestName { get; set; }
        public string LabTestSubTitle_1 { get; set; }
       
        //public int Price { get; set; }
        //public int DiscountPrice { get; set; }
        public List<LabTests> LabTests { get; set; }

    }





    public class LabTests
    {
        public string LabTestName { get; set; }
        public string LabTestSubTitle_1 { get; set; }
    }
}
