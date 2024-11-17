using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewMVCProject.Models
{
    public class Guild
    {
        [Key]
        public int GuildId { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Player> Players { get; set; } = new List<Player>();

    }
}
