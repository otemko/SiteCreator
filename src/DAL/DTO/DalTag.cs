using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class DalTag : IDalEntity
    {
        public int Id { get; set; }
        public int Name { get; set; }
    }
}
