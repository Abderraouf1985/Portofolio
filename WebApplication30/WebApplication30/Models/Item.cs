using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication30.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [Required]
        [DisplayName("Category")]
        public int CategoryId { get; set; }
    }
}
