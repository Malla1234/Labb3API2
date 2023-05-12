using System.ComponentModel.DataAnnotations;

namespace Labb3API2.Models.DTO
{
    public class LinkCreateDto
    {
        [Required]
        public string Url { get; set; }

        [Required]
        public int InterestId { get; set; }
    }
}
