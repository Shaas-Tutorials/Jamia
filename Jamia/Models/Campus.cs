using Jamia.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jamia.Models
{
    [Table("Campus",Schema = SchemaNames.SuperAdmin)]
    public class Campus
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Guid InstituteID { get; set; }
        [ForeignKey("InstituteID")]
        public virtual Institute Institute { get; set; }
    }
}
