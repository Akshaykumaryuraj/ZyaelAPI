﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zyael_Models.Doctors
{
    public class DoctorProfileModel
    {
        public int DoctorPId { get; set; }
        public int DoctorID { get; set; }

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Gender { get; set; }
        public String Studies { get; set; }
        public String Experience { get; set; }
        public Int64 Phone { get; set; }
        public String ConsultationCategory { get; set; }
        public String ConsultationFees { get; set; }
        public String status { get; set; }
        public String ProficientLanguage { get; set; }
        public String Specialization { get; set; }
        public string DoctorBio { get; set; }
        public string DoctorBio_1 { get; set; }
        public string DoctorBio_2 { get; set; }
        public string DoctorProcedure { get; set; }
        public string DoctorProcedure_1 { get; set; }
        public string DoctorProcedure_2 { get; set; }
        public string message { get; set; }
        public int returnId { get; set; }
        public string DoctorIntroVideoLink { get; set; }
        //public List<achievements> achievements { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public String City { get; set; }
        public string Address_1 { get; set; }
        public string Address_2 { get; set; }
        public IFormFile DoctorProfileImage { get; set; }

        public string DoctorProfileImageName { get; set; }
        public string DoctorProfileImagePath { get; set; }



    }
    public class achievements
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int DoctorID { get; set; }
        public int DoctorPId { get; set; }
    }

    public class DoctorProfileImageModel
    {
        public int DoctorPId { get; set; }
        public int DoctorID { get; set; }
        public int DoctorProfileImageID { get; set; }
        public int returnId { get; set; }
        public string  message { get; set; }
        public IFormFile DoctorProfileImage { get; set; }

        public string DoctorProfileImageName { get; set; }
        public string DoctorProfileImagePath { get; set; }
    }
}
