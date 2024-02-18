using System.ComponentModel.DataAnnotations;

namespace SeminarHub.Models.SeminarModels
{
    public class BaseSeminarViewModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Topic")]
        public string Topic { get; set; } = string.Empty;

        [Display(Name = "Lecturer")]
        public string Lecturer { get; set; } = string.Empty;

        [Display(Name = "Category")]
        public string Category { get; set; } = string.Empty;

        [Display(Name = "Date and Time")]
        public string DateAndTime { get; set; } = string.Empty;

        [Display(Name = "Organizer")]
        public string Organizer { get; set; } = string.Empty;
    }
}
