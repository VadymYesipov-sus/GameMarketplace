using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewMVCProject.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int MoneyAmount { get; set; }
        public string Class {  get; set; }
        [ForeignKey("Guild")]
        public int? GuildId { get; set; }
        public Guild? Guild { get; set; }
        public ICollection<Item> Items { get; set; } = new List<Item>();

    }
}
