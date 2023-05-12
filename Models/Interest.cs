using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Labb3API2.Models
{
    public class Interest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InterestId { get; set; }
        public string Title { get; set;}
        public string Description { get; set;}
        [ForeignKey("Person")]
        public int FK_PersonId { get; set; }
        public Person Person { get; set; }
    }
}
