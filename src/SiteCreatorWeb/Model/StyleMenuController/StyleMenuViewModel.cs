using SiteCreator.Entities;

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
