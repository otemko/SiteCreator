using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class DalSite : IDalEntity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Name { get; set; }

        public string UserId { get; set; }

        public int StyleMenuId { get; set; }
    }
}
