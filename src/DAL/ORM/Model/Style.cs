﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.ORM.Model
{
    public class Style: IEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}