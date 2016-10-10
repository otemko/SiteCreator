﻿using System;
using SiteCreator.BLL.IService;
using SiteCreator.DAL;
using SiteCreator.Entities;
using System.Threading.Tasks;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace SiteCreator.BLL.Services
{
    public class PageService : EntityService<Page, int>, IPageService
    {
        IEntityRepository repository;

        public PageService(IEntityRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<Page> GetPageWithSiteAndContent(int id)
        {
            var page = await repository.GetSingleAsync<Page>(p => p.Id == id, p => p.PageContent, p => p.Site);
            return page;
        }

        public async Task<Page> GetPageWithSite(int id)
        {
            var page = await repository.GetSingleAsync<Page>(p => p.Id == id, p => p.Site, p => p.Site);
            return page;
        }

        public async Task<Page> GetPageWithUserAndContentAndComments(int id)
        {
            var page = await repository.GetSingleAsync<Page>(p => p.Id == id, p => p.PageContent,
                p => p.Comment, p => p.Site, p => p.Site.User);
            if (page == null) return null;

            var comments = await repository.GetAllAsync<Comment>(p => p.PageId == id, p => p.User);
            page.Comment = comments.ToArray();
            return page;
        }

        public async Task<IEnumerable<Page>> GetMostCommentedPages(int take = 0, int skip = 0)
        {
            return await repository.GetAllOrderBySkippingAsync<Page, int>(true, p => p.Comment.Count, take, skip,
                null, p => p.Comment, p => p.Site, p => p.Site.User);
        }

        public async Task<IEnumerable<Page>> GetMostRatedPages(int take = 0, int skip = 0)
        {
            return await repository.GetAllOrderBySkippingAsync<Page, decimal>(true, p => p.Rating, take, skip,
                null, p => p.Site, p => p.Site.User);
        }

        public async Task Vote(Page page, int rating)
        {
            page.Rating = (page.Rating * page.CountRated + rating) / (++page.CountRated);
            await UpdateAsync(page);
        }
    }
}
