using EMRDash.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMRDash.Controllers.API
{
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly EMRDbContext _db;
        public PatientsController(EMRDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        [Route("api/patients")]
        public async Task<IActionResult> GetAllPatientsAsync()
        {
            return Ok(await _db.Patients.ToListAsync());
        }

        [HttpGet]
        [Route("api/patient")]
        public async Task<IActionResult> GetPatientByIdAsync(Guid id) {
            var patient = await _db.Patients
                .FirstOrDefaultAsync(p => p.Id == id);
            return Ok(patient);
        }
    }
}
