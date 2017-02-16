using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientsAPI.Models
{
    public class PatientModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Nationality { get; set; }

        public string Diseases { get; set; }

        public string PhoneNumber { get; set; }

        public int BloodType { get; set; }
    }
}