using System.ComponentModel.DataAnnotations;

namespace PruebaYachtme.Models.DTO
{
    public class ItemAddDTO
    {
        [Required]
       public string Name { get; set; }
       [Required]
       public string Description { get; set; }

       [Required]
       public DateTime DueDate { get; set; }
    }
}
