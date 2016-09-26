using System.Collections.Generic;

namespace DAL.DTO
{
    public class DalAchievement : IDalEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }     
    }
}
