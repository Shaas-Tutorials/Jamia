using Jamia.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jamia.Models
{
    [Table("Institute", Schema = SchemaNames.SuperAdmin)]
    public class Institute
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public string Description { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
