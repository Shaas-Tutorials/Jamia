using Jamia.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jamia.Models
{
    [Table("Course", Schema = AreaNames.Admin)]
    public class Course
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
        public string Description { get; set; }
        [Required]
        [Display(Name = "Seats Limit of Course")]
        public int SeatsLimit { get; set; }
        [Required]
        [Display(Name = "Select Session")]
        public Guid SessionID { get; set; }
        [ForeignKey("SessionID")]
        public virtual Session Session { get; set; }
    }
}