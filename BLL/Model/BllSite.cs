using System;

namespace BLL.Model
{
    public class BllSite
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        //public string UserName { get; set; }
        public int StyleMenuId { get; set; }
    }
}
