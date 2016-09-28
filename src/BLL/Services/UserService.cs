using SiteCreator.BLL.IService;
using SiteCreator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiteCreator.DAL;

namespace SiteCreator.BLL.Services
{
    public class UserService : EntityService<User, string>, IUserService
    {
        IEntityRepository repository;

        public UserService(IEntityRepository repository) : base(repository)
        {
            this.repository = repository;
        }


    }
}
