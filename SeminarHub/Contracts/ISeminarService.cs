using SeminarHub.Data.Models;
using SeminarHub.Models.SeminarModels;

namespace SeminarHub.Contracts
{
    /// <summary>
    /// Represent service for dealing with seminars
    /// </summary>
    public interface ISeminarService
    {
        Task AddSeminarAsync(SeminarFormModel formModel, string currentUserId, DateTime dateAndTime);
        Task<IEnumerable<BaseSeminarViewModel>> GetAllSeminarAsync();
        Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync();
        Task<IEnumerable<JoinedSeminarViewModel>> GetJoinedAsync(string currentUserId);
        Task<DetailsSeminarViewModel> GetSeminarDetailsByIdAsync(int id);
        Task JoinSeminarAsync(Seminar thisSeminar, string currentUserId);
        Task<Seminar?> GetSeminarByIdAsync(int id);
        Task LeaveSeminarAsync(Seminar seminar, string currentUserId);
        Task<SeminarFormModel> GetDataForEditAsync(Seminar currentSeminar);
        Task SaveEditAsync(SeminarFormModel formModel, DateTime dateTime, Seminar currenSeminar);
        Task DeleteSeminarAsync(int id);
    }
}
