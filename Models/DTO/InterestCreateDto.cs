using Microsoft.Build.Framework;

namespace Labb3API2.Models.DTO
{
    public class InterestCreateDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int PersonId { get; set; }
    }
}
