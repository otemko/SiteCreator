using SiteCreator.Entities;

namespace SiteCreator.Web.Model.Shared
{
    public class TagViewModel
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        
        public TagViewModel()
        {

        }

        public TagViewModel(Tag tag)
        {
            Id = tag.Id;
            Name = tag.Name;
        }
    }
}
