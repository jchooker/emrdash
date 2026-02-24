using EMRDash.Data;
using EMRDash.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EMRDash.Controllers.API
//API ECLIPSING (TEMPORARILY) OTHER TYPES OF CONTROLLERS DUE TO LLM CHAT NEEDS?
//“The controller layer is thin and delegates orchestration to an application service.
//The AI integration is isolated behind an interface to allow mocking or provider swapping.”
{
    [ApiController]
    [Route("api/notes")]
    public class NotesController : ControllerBase
    {
        private readonly EMRDbContext _db;
        public NotesController(EMRDbContext db)
        {
            _db = db;
        }
        [HttpPost("{patientId}")]
        public async Task<IActionResult> CreateNoteAsync(Guid patientId, [FromBody] string content)
        {
            var note = new ClinicNote
            {
                PatientId = patientId,
                Content = content,
                CreatedAt = DateTime.Now
            };

            _db.ClinicNotes.Add(note);
            await _db.SaveChangesAsync();

            return Ok(note);
        }
    }
}
