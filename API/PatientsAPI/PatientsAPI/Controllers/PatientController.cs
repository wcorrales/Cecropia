using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Description;
using PatientsAPI.Models;
using PatientsAPI.Utility;
using System.Web.Http;

namespace PatientsAPI.Controllers
{
    public class PatientController : ApiController
    {
        private PatientsAPIContext db = new PatientsAPIContext();

        // Get all Patients in DB
        [Route("services/patient/get")]
        [HttpGet]
        public async Task<List<PatientModel>> Get()
        {
            return await DBUtility.GetPatients();
        }

        //Get all countries in DB
        [Route("services/countries/get")]
        [HttpGet]
        public async Task<List<CountryModel>> GetCountries()
        {
            return await DBUtility.GetCountries();
        }

        //Get all BloodTypes in DB
        [Route("services/bloodtypes/get")]
        [HttpGet]
        public async Task<List<BloodTypeModel>> GetBloodTypes()
        {
            return await DBUtility.GetBloodTypes();
        }

        // Get a patient by id
        [Route("services/getpatient/{id}")]
        [ResponseType(typeof(PatientModel))]
        [HttpGet]
        public async Task<IHttpActionResult> GetPatient(int id)
        {
            PatientModel patientmodel = await DBUtility.GetPatientById(id);
            if (patientmodel == null)
            {
                return NotFound();
            }

            return Ok(patientmodel);
        }

        // Update a patient
        [Route("services/patient/update")]
        [HttpPost]
        public async Task<IHttpActionResult> Update([FromBody]PatientModel patientmodel)
        {
            try
            {
                await DBUtility.UpdatePatient(patientmodel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientModelExists(patientmodel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // Create a patient
        [Route("services/patient/create")]
        [HttpPost]
        [ResponseType(typeof(PatientModel))]
        public async Task<IHttpActionResult> Create([FromBody]PatientModel patientmodel)
        {
            await DBUtility.CreatePatient(patientmodel);

            return CreatedAtRoute("DefaultApi", new { id = patientmodel.Id }, patientmodel);
        }

        // Delete a patient
        [Route("services/patient/delete/{id}")]
        [HttpPost]
        [ResponseType(typeof(PatientModel))]
        public async Task<IHttpActionResult> Delete(int id)
        {
            await DBUtility.DeletePatient(id);

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatientModelExists(int id)
        {
            return db.Patients.Count(e => e.Id == id) > 0;
        }
    }
}