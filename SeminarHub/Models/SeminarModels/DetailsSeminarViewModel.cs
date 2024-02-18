using System.ComponentModel.DataAnnotations;

namespace SeminarHub.Models.SeminarModels
{
    public class DetailsSeminarViewModel : BaseSeminarViewModel
    {
        [Display(Name = "Details")]
        public string Details { get; set; } = string.Empty;

        [Display(Name = "Duration")]
        public int Duration { get; set; }
    }
}
