using System.ComponentModel.DataAnnotations.Schema;

namespace Labb3API2.Models.DTO
{
    public class InterestDto
    {
        public int InterestId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int FK_PersonId { get; set; }
    }
}
