using System.ComponentModel.DataAnnotations;

namespace Labb3API2.Models.DTO
{
    public class PersonCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
    }
}
