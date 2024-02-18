using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static SeminarHub.GlobalConstant.DataConst;

namespace SeminarHub.Data.Models
{
    public class Category
    {
        [Comment("Primary key")]
        [Key]
        public int Id { get; set; }
        [Comment("Category name")]
        [Required]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; } = string.Empty;
        public ICollection<Seminar> Seminars { get; set; } = new List<Seminar>();
    }
}