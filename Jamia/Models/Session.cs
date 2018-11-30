using Jamia.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jamia.Models
{
    [Table("Session", Schema = AreaNames.Admin)]
    public class Session
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        [Display(Name = "Session Name")]
        public string SessionName { get; set; }
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        public virtual ICollection<Course> Course { get; set; }
        [Display(Name = "Campus")]
        public virtual Guid CampusId { get; set; }
        [ForeignKey("CampusId")]
        public virtual Campus Campus { get; set; }
    }
}
