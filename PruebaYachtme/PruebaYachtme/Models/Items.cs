using System.ComponentModel.DataAnnotations;

namespace PruebaYachtme.Models
{
    public class Items
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public short Status { get; set; } = 1;
        [Required]
        public DateTime DueDate { get; set; }
    }
}
