using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class DalComment: IDalEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public string UserId { get; set; }

        public int PageId { get; set; }
    }
}
