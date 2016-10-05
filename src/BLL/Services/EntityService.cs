﻿using SiteCreator.BLL.IService;
using SiteCreator.DAL;
using SiteCreator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteCreator.BLL.Services
{
    public abstract class EntityService<T,Q> where T : class, WithId<Q>
    {
        IEntityRepository repository;

        public EntityService(IEntityRepository repository)
        {
            this.repository = repository;
        }

        public virtual void CreateAsync(T entity)
        {
            repository.Create<T>(entity);
        }

        public virtual void CreateRangeAsync(T[] entities)
        {
            repository.CreateRange<T>(entities);
        }

        public virtual void UpdateAsync(T entity)
        {
            repository.Update<T>(entity);
        }

        public virtual void DeleteAsync(T entity)
        {
            repository.Delete<T>(entity);
        }

        public virtual void DeleteRangeAsync(T[] entities)
        {
            repository.DeleteRange<T>(entities);
        }
        public virtual Task<IEnumerable<T>> GetAllAsync()
        {
            return repository.GetAllAsync<T>();
        }

        public async Task<T> GetSingleAsync(Q userId)
        {
            var sites = await repository.GetSingleAsync<T, Q>(userId);
            return sites;
        }
    }
}
