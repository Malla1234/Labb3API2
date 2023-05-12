using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Labb3API2.Models
{
    public class Link
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LinkId { get; set; }
        public string Url { get; set; }
        [ForeignKey("Interest")]
        public int FK_InterestId { get; set; }
        public Interest Interest { get; set; }


    }
}
