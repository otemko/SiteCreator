using SiteCreator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteCreator.Web.Model.StyleMenuController
{
    public class StyleMenuViewModel
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public StyleMenuViewModel()
        {

        }

        public StyleMenuViewModel(StyleMenu styleMenu)
        {
            Id = styleMenu.Id;
            Name = styleMenu.Name;
        }
    }
}
