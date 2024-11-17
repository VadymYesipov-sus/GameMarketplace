using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewMVCProject.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public string Rarity { get; set; }
        [ForeignKey("Player")]
        public int PlayerId { get; set; }
        public Player? Player { get; set; }


    }
}
