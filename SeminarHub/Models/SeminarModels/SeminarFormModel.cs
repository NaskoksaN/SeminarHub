using System.ComponentModel.DataAnnotations;

using static SeminarHub.GlobalConstant.SeminarErrorMsg;
using static SeminarHub.GlobalConstant.DataConst;
using static SeminarHub.GlobalConstant.ValidationConst;

namespace SeminarHub.Models.SeminarModels
{
    public class SeminarFormModel
    {
        [Display(Name = "Topic")]
        [Required(ErrorMessage =RequiredErrorMsg )]
        [StringLength(SeminarTopicMaxLength, MinimumLength = SeminarTopicMinLength,
            ErrorMessage = LengthErrorMsg)]
        public string Topic { get; set; } =string.Empty;

        [Display(Name = "Lecturer")]
        [Required(ErrorMessage =RequiredErrorMsg )]
        [StringLength(SeminarLecturerMaxLength, MinimumLength = SeminarLecturerMinLength,
            ErrorMessage =LengthErrorMsg)]
        public string Lecturer {  get; set; } =string.Empty;
        [Display(Name = "Details")]
        [Required(ErrorMessage =RequiredErrorMsg )]
        [StringLength(SeminarDetailsMaxLength, MinimumLength = SeminarDetailsMinLength,
            ErrorMessage = LengthErrorMsg)]
        public string Details {  get; set; } =string.Empty;

        [Display(Name = "Date and Time")]
        [Required(ErrorMessage =RequiredErrorMsg )]
        [RegularExpression(RegexDateValidation, ErrorMessage = ErrorDateFormat)]
        public string DateAndTime {  get; set; } =string.Empty;
        [Display(Name = "Duration")]
        [Range(DurationMinRange, DurationMaxRange)]
        [Required(ErrorMessage =RequiredErrorMsg)]
        public int Duration { get; set; }
        [Display(Name = "Category")]
        [Required]
        [Range(CategoryMinRange, CategoryMaxRange)]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; } 
            = new List<CategoryViewModel>();
    }
}
