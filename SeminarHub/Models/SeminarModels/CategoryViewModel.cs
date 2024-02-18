using System.ComponentModel.DataAnnotations;

namespace SeminarHub.Models.SeminarModels
{
    public class CategoryViewModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; } = string.Empty;
    }
}