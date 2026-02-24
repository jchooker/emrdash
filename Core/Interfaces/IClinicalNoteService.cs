using EMRDash.Core.Services.Common;

namespace EMRDash.Core.Interfaces
{
    public interface IClinicalNoteService
    {
        Task<ServiceResult<string>> GenerateSummaryAsync(Guid noteId);
    }
}
