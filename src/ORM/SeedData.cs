using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SiteCreator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteCreator.ORM
{
    public class SeedData
    {
        private SiteCreatorDbContext context;

        public SeedData(SiteCreatorDbContext context)
        {
            this.context = context;
        }

        public async void Seed()
        {
            //AddStyles();
            
            //AddLanguages();
            
            //AddStylesMenu();
            
            //AddTags();            

            //var userId = await AddUsers();
            
            //AddSites(userId);
            
            //AddTagSites();

            //await context.SaveChangesAsync();
        }

        private void AddStylesMenu()
        {
            if (context.StyleMenu.Count() == 0)
            {
                context.StyleMenu.Add(new StyleMenu
                {
                    Name = "Horizontal"
                });
                context.StyleMenu.Add(new StyleMenu
                {
                    Name = "Vertical"
                });
            }
        }

        private void AddLanguages()
        {
            if (context.Language.Count() == 0)
            {
                context.Language.Add(new Language
                {
                    Name = "En",
                    Url = "someurl"
                });
                context.Language.Add(new Language
                {
                    Name = "Ru",
                    Url = "someurl"
                });
            }
        }

        private void AddStyles()
        {
            if (context.Style.Count() == 0)
            {
                context.Style.Add(new Style
                {
                    Name = "White",
                    Url = "someurl"
                });
                context.Style.Add(new Style
                {
                    Name = "Black",
                    Url = "someurl"
                });
            }
        }

        private void AddTags()
        {
            if (context.Tag.Count() == 0)
            {
                context.Tag.Add(new Tag
                {
                    Name = "C"                    
                });

                context.Tag.Add(new Tag
                {
                    Name = "C++"
                });

                context.Tag.Add(new Tag
                {
                    Name = "C#"
                });
            }
        }

        private async Task<string> AddUsers()
        {
            if (context.Users.Count() == 0)
            {
                await context.SaveChangesAsync();

                var user = new User
                {
                    FirstName = "Bob",
                    LanguageId = 1,
                    LastName = "Marley",
                    LockoutEnabled = true,
                    NormalizedUserName = "EE94A22317884C8A9D8E8447A356B006",
                    PhoneNumberConfirmed = false,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    StyleId = 1,
                    TwoFactorEnabled = false,
                    UserName = "ee94a22317884c8a9d8e8447a356b006"
                };

                var userStore = new UserStore<User>(context);
                await userStore.CreateAsync(user);

                var id = await userStore.GetUserIdAsync(user);

                context.UserLogins.Add(new Microsoft.AspNetCore.Identity.EntityFrameworkCore.
                    IdentityUserLogin<string>
                {
                    LoginProvider = "Twitter",
                    ProviderKey = "772510886347014144",
                    UserId = id
                });

                return id;            
            }

            return "";
        }

        private void AddSites(string userId)
        {
            if (context.Site.Count() == 0)
            {
                context.Site.Add(new Site
                {
                    DateCreated = new DateTime(2016, 09, 28),
                    Name = "First Site",
                    StyleMenuId = 1,
                    UserId = userId
                });

                context.Site.Add(new Site
                {
                    DateCreated = new DateTime(2016, 09, 29),
                    Name = "Second Site",
                    StyleMenuId = 2,
                    UserId = userId
                });
            }
        }

        private void AddTagSites()
        {
            if (context.TagSite.Count() == 0)
            {
                context.TagSite.Add(new TagSite
                {
                    SiteId = 1,
                    TagId = 1
                });

                context.TagSite.Add(new TagSite
                {
                    SiteId = 1,
                    TagId = 3
                });

                context.TagSite.Add(new TagSite
                {
                    SiteId = 2,
                    TagId = 1
                });

                context.TagSite.Add(new TagSite
                {
                    SiteId = 2,
                    TagId = 2
                });

                context.TagSite.Add(new TagSite
                {
                    SiteId = 2,
                    TagId = 3
                });
            }
        }
    }
}
