using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jamia.Areas.Admin.Models
{
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
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
    }
}
