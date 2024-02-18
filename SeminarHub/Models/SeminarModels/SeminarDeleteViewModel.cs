using System.ComponentModel.DataAnnotations;

namespace SeminarHub.Models.SeminarModels
{
    public class SeminarDeleteViewModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "Topic")]
        public string Topic { get; set; }=string.Empty;
        [Display(Name = "Date and Time")]
        public DateTime DateAndTime {  get; set; }

    }
}
