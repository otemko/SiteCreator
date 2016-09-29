using SiteCreator.BLL.IService;
using SiteCreator.DAL;
using SiteCreator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteCreator.BLL.Services
{
    public class TagService : EntityService<Tag, int>, ITagService
    {
        IEntityRepository repository;

        public TagService(IEntityRepository repository): base(repository)
        {
            this.repository = repository;
        }
    }
}
