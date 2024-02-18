using Microsoft.EntityFrameworkCore;
using SeminarHub.Contracts;
using SeminarHub.Data;
using SeminarHub.Data.Models;
using SeminarHub.Models.SeminarModels;

using static SeminarHub.GlobalConstant.ValidationConst;

namespace SeminarHub.Service
{
    public class SeminarService : ISeminarService
    {
        private readonly SeminarHubDbContext data;
        public SeminarService(SeminarHubDbContext _data)
        {
            data = _data;
        }
        /// <summary>
        /// Adds a new seminar to the database asynchronously.
        /// </summary>
        /// <param name="formModel"></param>
        /// <param name="currentUserId"></param>
        /// <param name="dateAndTime"></param>
        /// <returns></returns>
        public async Task AddSeminarAsync(SeminarFormModel formModel, string currentUserId, DateTime dateAndTime)
        {
            bool exist = SeminarExists(formModel.Topic, 
                                        formModel.Lecturer, 
                                        dateAndTime, 
                                        formModel.Duration,
                                        formModel.CategoryId);
            if(!exist )
            {
                Seminar newSeminar = new Seminar()
                {
                    Topic = formModel.Topic,
                    Lecturer = formModel.Lecturer,
                    Details = formModel.Details,
                    DateAndTime = dateAndTime,
                    Duration = formModel.Duration,
                    CategoryId = formModel.CategoryId,
                    OrganizerId = currentUserId
                };


                await data.Seminars.AddAsync(newSeminar);
                await data.SaveChangesAsync();
            }
            
        }
        /// <summary>
        /// Show all seminars from database asynchronously.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<BaseSeminarViewModel>> GetAllSeminarAsync()
        {
            var result = await data.Seminars
                .AsNoTracking()
                .Select(x => new BaseSeminarViewModel()
                {
                    Id = x.Id,
                    Topic = x.Topic,
                    Lecturer = x.Lecturer,
                    Category = x.Category.Name,
                    DateAndTime = x.DateAndTime.ToString(SeminarDateFormat),
                    Organizer = x.Organizer.UserName
                }).ToListAsync();

            return result;
        }

        /// <summary>
        /// Recieved all categories from database asynchronously.
        /// </summary>
        /// <returns></returns>        
        public async Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync()
        {
            var result = await data.Categories
                    .AsNoTracking()
                    .Select(c=> new CategoryViewModel()
                    {
                        Id = c.Id,
                        Name = c.Name,
                    }).ToListAsync();

            return result;
        }
        /// <summary>
        /// Show all joined from users seminars from database asynchronously.
        /// </summary>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<JoinedSeminarViewModel>> GetJoinedAsync(string currentUserId)
        {
            var result = await data.SeminarsParticipants
                .Where(sp => sp.ParticipantId == currentUserId)
                .Select(sp => new JoinedSeminarViewModel()
                {
                    Id = sp.SeminarId,
                    Topic = sp.Seminar.Topic,
                    Lecturer = sp.Seminar.Lecturer,
                    DateAndTime = sp.Seminar.DateAndTime.ToString(SeminarDateFormat),
                    Organizer = sp.Seminar.Organizer.UserName
                }).ToListAsync();

            return result;
        }
        /// <summary>
        /// Show exact seminar details with given id  asynchronously
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DetailsSeminarViewModel> GetSeminarDetailsByIdAsync(int id)
        {
            var result = await data.Seminars
                .Where (s=>s.Id==id)
                .Select(s => new DetailsSeminarViewModel()
                {
                    Id=s.Id,
                    Topic=s.Topic,
                    Duration =s.Duration,
                    DateAndTime = s.DateAndTime.ToString(SeminarDateFormat),
                    Lecturer = s.Lecturer,
                    Category= s.Category.Name,
                    Details = s.Details,
                    Organizer= s.Organizer.UserName
                })
                .FirstOrDefaultAsync();

            return result;
        }
        /// <summary>
        /// Join seminar to user collection asynchronously
        /// </summary>
        /// <param name="thisSeminar"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        public async Task JoinSeminarAsync(Seminar thisSeminar, string currentUserId)
        {
            
            if (!thisSeminar.SeminarsParticipants
                .Any(sp => sp.SeminarId == thisSeminar.Id && sp.ParticipantId == currentUserId))
            {
                SeminarParticipant newSp = new SeminarParticipant()
                {
                    SeminarId = thisSeminar.Id,
                    ParticipantId = currentUserId
                };
                thisSeminar.SeminarsParticipants.Add(newSp);

                await data.SaveChangesAsync();
            }
        }
        /// <summary>
        /// Get seminar by given id asynchronously
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Seminar?> GetSeminarByIdAsync(int id)
        {
            var result = await data.Seminars
                .Where(s => s.Id == id)
                .Include(s => s.SeminarsParticipants)
                .FirstOrDefaultAsync();

            return result;
        }
        /// <summary>
        /// User leave given seminar asynchronously
        /// </summary>
        /// <param name="seminar"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        public async Task LeaveSeminarAsync(Seminar seminar, string currentUserId)
        {
            var tempSp = await data.SeminarsParticipants
                .Where(sp => sp.SeminarId == seminar.Id && sp.ParticipantId == currentUserId)
                .FirstOrDefaultAsync();
            if(tempSp != null)
            {
                seminar.SeminarsParticipants.Remove(tempSp);
                await data.SaveChangesAsync();
            }
        }
        /// <summary>
        /// Return edit form with data for edit asynchronously
        /// </summary>
        /// <param name="currentSeminar"></param>
        /// <returns></returns>
        public async Task<SeminarFormModel> GetDataForEditAsync(Seminar currentSeminar)
        {
            var categories = await GetCategoriesAsync();
            SeminarFormModel editSeminar = new SeminarFormModel()
            {
                Topic = currentSeminar.Topic,
                Lecturer = currentSeminar.Lecturer,
                Details = currentSeminar.Details,
                DateAndTime = currentSeminar.DateAndTime.ToString(SeminarDateFormat),
                Duration = currentSeminar?.Duration ?? 0,
                CategoryId = currentSeminar.CategoryId,
                Categories = categories
            };
            return editSeminar;
        }
        /// <summary>
        /// Save edited data from user  asynchronously
        /// </summary>
        /// <param name="formModel"></param>
        /// <param name="dateTime"></param>
        /// <param name="currenSeminar"></param>
        /// <returns></returns>
        public async Task SaveEditAsync(SeminarFormModel formModel, DateTime dateTime, Seminar currenSeminar)
        {
            currenSeminar.Topic=formModel.Topic;
            currenSeminar.Lecturer= formModel.Lecturer;
            currenSeminar.Details = formModel.Details;
            currenSeminar.DateAndTime = dateTime;
            currenSeminar.Duration= formModel.Duration;
            currenSeminar.CategoryId = formModel.CategoryId;

            await data.SaveChangesAsync();
        }
        /// <summary>
        /// Delete chesen seminar by id asynchronously
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteSeminarAsync(int id)
        {
            var deleteSeminar = await data.Seminars
                .Include(s => s.SeminarsParticipants)
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();
            if(deleteSeminar!=null)
            {
                data.SeminarsParticipants.RemoveRange(deleteSeminar.SeminarsParticipants);
                data.Seminars.Remove(deleteSeminar);
                await data.SaveChangesAsync();
            }
        }
        /// <summary>
        /// Check if seminar exist
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="lecturer"></param>
        /// <param name="dateAndTime"></param>
        /// <param name="duration"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        private bool SeminarExists(string topic, string lecturer, DateTime dateAndTime, int duration, int categoryId)
        {
            return data.Seminars.Any(s => s.Topic == topic 
                                        && s.Lecturer == lecturer 
                                        && s.DateAndTime == dateAndTime
                                        && s.Duration==duration
                                        && s.CategoryId == categoryId);
        }
    }
}
