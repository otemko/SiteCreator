using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class DalLayout : IDalEntity
    {
        public int Id { get; set; }
        public string Html { get; set; }
        public byte[] Image { get; set; }
    }
}
