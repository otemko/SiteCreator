using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class DalAchievementUser : IDalEntity
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public int AchievementId { get; set; }
    }
}
