﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class DalContent : IDalEntity
    {
        public int Id { get; set; }
        public string Html { get; set; }

        public int PageId { get; set; }
    }
}
