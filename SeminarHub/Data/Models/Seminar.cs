using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static SeminarHub.GlobalConstant.DataConst;

namespace SeminarHub.Data.Models
{
    public class Seminar
    {
        [Comment("Primary Key")]
        [Key]
        public int Id { get; set; }
        [Comment("Topic name")]
        [Required]
        [MaxLength(SeminarTopicMaxLength)]
        public string Topic { get; set; } = string.Empty;
        [Comment("Lecturer name")]
        [Required]
        [MaxLength(SeminarLecturerMaxLength)]
        public string Lecturer { get; set; }=string.Empty;
        [Comment("Details of topic")]
        [Required]
        [MaxLength(SeminarDetailsMaxLength)]
        public string Details { get; set; } =string.Empty;
        [Comment("Orginizer Id")]
        [Required]
        public string OrganizerId { get; set; } = string.Empty;
        [Comment("Organizer")]
        [ForeignKey(nameof(OrganizerId))]
        public IdentityUser Organizer { get; set; } = null!;
        [Comment("DateAndtiem of creation the Topic")]
        [Required]
        public DateTime DateAndTime {  get; set; }
        [Comment("Duration of topic")]
        [Required]
        public int Duration { get; set; }
        [Comment("Topics category id")]
        [Required]
        public int CategoryId { get; set; }
        [Comment("Topics category")]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;
        public ICollection<SeminarParticipant> SeminarsParticipants = new List<SeminarParticipant>();
    }
}

