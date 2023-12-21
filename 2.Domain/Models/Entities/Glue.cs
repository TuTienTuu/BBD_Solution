using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Glues",Schema ="Paper")]
    public class Glue
    {
        [Required]
        [Key]
        public int ID { get; set; }
        public string GlueName { get; set; }
        public string GlueCode { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Deleted { get; set; }
    }
}