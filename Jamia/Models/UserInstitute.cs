using Jamia.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jamia.Models
{
    [Table("UserInstitute", Schema = SchemaNames.SuperAdmin)]
    public class UserInstitute
    {
        public virtual string ApplicationUserId { get; set; }
        public virtual Guid InstituteId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Institute Institute { get; set; }
    }
}
