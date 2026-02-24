using EMRDash.Core.Interfaces;
using EMRDash.Core.Services.Common;
using EMRDash.Data;

namespace EMRDash.Core.Services
{
    public class ClinicalNoteService : IClinicalNoteService
    {
        private readonly EMRDbContext _db;
        private readonly AISummaryService _ai;
        public ClinicalNoteService(EMRDbContext db, AISummaryService ai)
        {
            _db = db;
            _ai = ai;
        }

        public async Task<ServiceResult<string>> GenerateSummaryAsync(Guid noteId)
        {
            var note = await _db.ClinicNotes.FindAsync(noteId);
            if (note == null)
            {
                return ServiceResult<string>.Fail("Note not found!");
            }
            if (note.Content.Length > 4000)
            {
                return ServiceResult<string>.Fail("Too many characters in note! Note is too long.");
            }

            var summary = await _ai.GenerateAsync(note.Content);

            note.AISummary = summary;
            await _db.SaveChangesAsync();

            return ServiceResult<string>.Ok(summary);
        }
    }
}
