using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ORM.Model
{
    public class Style: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }


        public virtual ICollection<User> User { get; set; }
    }
}