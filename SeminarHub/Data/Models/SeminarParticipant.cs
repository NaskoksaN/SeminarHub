using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace SeminarHub.Data.Models
{
    public class SeminarParticipant
    {
        [Comment("Seminar ID")]
        [Required]
        public int SeminarId { get; set; }
        [Comment("Seminar")]
        [ForeignKey(nameof(SeminarId))]
        public Seminar Seminar { get; set; } = null!;
        [Comment("ParticipantId")]
        [Required]
        public string ParticipantId { get; set; } = string.Empty;
        [Comment("Participant")]
        [ForeignKey(nameof(ParticipantId))]
        public IdentityUser Participant { get; set; } = null!;

    }
}