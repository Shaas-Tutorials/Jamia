﻿using Jamia.Infrastructure;
using System;
using System.Collections.Generic;
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
        public string Description { get; set; }
        public virtual ICollection<UserInstitute> UserInstitutes { get; set; }
        public virtual ICollection<Campus> CampusCollection { get; set; }
    }
}
