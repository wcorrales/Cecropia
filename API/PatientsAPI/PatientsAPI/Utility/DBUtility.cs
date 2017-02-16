using PatientsAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PatientsAPI.Utility
{
    public static class DBUtility
    {
        // Get Countries asyncronously
        public static async Task<List<CountryModel>> GetCountries()
        {
            try
            {
                List<CountryModel> countries = null;
                using (PatientsAPIContext dbContext = new PatientsAPIContext("PatientsAPIContext"))
                {
                    countries = await dbContext.Database.SqlQuery<CountryModel>("exec sp_GetCountries").ToListAsync();
                };

                return countries;
            }
            catch (Exception ex)
            {
                string sMsg = string.Format("GetCountries");
                throw new Exception(sMsg, ex);
            }
        
        }

        // Get BloodTypes asyncronously
        public static async Task<List<BloodTypeModel>> GetBloodTypes()
        {
            try
            {
                List<BloodTypeModel> bloodTypes = null;
                using (PatientsAPIContext dbContext = new PatientsAPIContext("PatientsAPIContext"))
                {
                    bloodTypes = await dbContext.Database.SqlQuery<BloodTypeModel>("exec sp_GetBloodTypes").ToListAsync();
                };

                return bloodTypes;
            }
            catch (Exception ex)
            {
                string sMsg = string.Format("GetBloodTypes");
                throw new Exception(sMsg, ex);
            }
        }

        // Get Patients asyncronously
        public static async Task<List<PatientModel>> GetPatients()
        {
            try
            {
                List<PatientModel> patients = null;
                using (PatientsAPIContext dbContext = new PatientsAPIContext("PatientsAPIContext"))
                {
                     patients = await dbContext.Database.SqlQuery<PatientModel>("exec sp_GetPatients").ToListAsync();
                };

                return patients;
            }
            catch (Exception ex)
            {
                string sMsg = string.Format("GetPatients");
                throw new Exception(sMsg, ex);
            }
        }

        // Get Patients by id asyncronously
        public static async Task<PatientModel> GetPatientById(int id)
        {
            try
            {
                PatientModel patient = null;
                using (PatientsAPIContext dbContext = new PatientsAPIContext("PatientsAPIContext"))
                {
                    SqlParameter param1 = new SqlParameter("@Id", id);
                    patient = await dbContext.Database.SqlQuery<PatientModel>("exec sp_GetPatient @Id", param1).FirstOrDefaultAsync();
                };

                return patient;
            }
            catch (Exception ex)
            {
                string sMsg = string.Format("GetPatientById");
                throw new Exception(sMsg, ex);
            }
        }

        // Update Patient asyncronously
        public static async Task UpdatePatient(PatientModel patient)
        {
            try
            {
                using (PatientsAPIContext dbContext = new PatientsAPIContext("PatientsAPIContext"))
                {
                    SqlParameter id = new SqlParameter("@Id", patient.Id);
                    SqlParameter firstname = new SqlParameter("@FirstName", patient.FirstName);
                    SqlParameter lastname = new SqlParameter("@LastName", patient.LastName);
                    SqlParameter dob = new SqlParameter("@DateOfBirth", patient.DateOfBirth);
                    SqlParameter nationality = new SqlParameter("@Nationality", patient.Nationality);
                    SqlParameter diseases = new SqlParameter("@Diseases", patient.Diseases);
                    SqlParameter phone = new SqlParameter("@PhoneNumber", patient.PhoneNumber);
                    SqlParameter bloodtype = new SqlParameter("@BloodType", patient.BloodType);

                    await dbContext.Database.ExecuteSqlCommandAsync("exec sp_UpdatePatient @Id, @FirstName, @LastName, @DateOfBirth, @Nationality, @Diseases, @PhoneNumber, @BloodType", id, firstname, lastname, dob, nationality, diseases, phone, bloodtype);

                };

            }
            catch (Exception ex)
            {
                string sMsg = string.Format("UpdatePatient");
                throw new Exception(sMsg, ex);
            }
        }

        //Create Patient asyncronously
        public static async Task CreatePatient(PatientModel patient)
        {
            try
            {
                using (PatientsAPIContext dbContext = new PatientsAPIContext("PatientsAPIContext"))
                {
                    SqlParameter firstname = new SqlParameter("@FirstName", patient.FirstName);
                    SqlParameter lastname = new SqlParameter("@LastName", patient.LastName);
                    SqlParameter dob = new SqlParameter("@DateOfBirth", patient.DateOfBirth);
                    SqlParameter nationality = new SqlParameter("@Nationality", patient.Nationality);
                    SqlParameter diseases = new SqlParameter("@Diseases", patient.Diseases);
                    SqlParameter phone = new SqlParameter("@PhoneNumber", patient.PhoneNumber);
                    SqlParameter bloodtype = new SqlParameter("@BloodType", patient.BloodType);

                    await dbContext.Database.ExecuteSqlCommandAsync("exec sp_CreatePatient @FirstName, @LastName, @DateOfBirth, @Nationality, @Diseases, @PhoneNumber, @BloodType", firstname, lastname, dob, nationality, diseases, phone, bloodtype);

                };

            }
            catch (Exception ex)
            {
                string sMsg = string.Format("CreatePatient");
                throw new Exception(sMsg, ex);
            }
        }

        //Delete Patient asyncronously
        public static async Task DeletePatient(int id)
        {
            try
            {
                using (PatientsAPIContext dbContext = new PatientsAPIContext("PatientsAPIContext"))
                {
                    SqlParameter param1 = new SqlParameter("@Id", id);

                    await dbContext.Database.ExecuteSqlCommandAsync("exec sp_DeletePatient @Id", param1);

                };

            }
            catch (Exception ex)
            {
                string sMsg = string.Format("DeletePatient");
                throw new Exception(sMsg, ex);
            }
        }

    }
}