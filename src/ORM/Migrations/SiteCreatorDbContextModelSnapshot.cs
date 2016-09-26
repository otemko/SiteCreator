using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ORM;

namespace ORM.Migrations
{
    [DbContext(typeof(SiteCreatorDbContext))]
    partial class SiteCreatorDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ORM.Model.Achievement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<byte[]>("Image");

                    b.HasKey("Id");

                    b.ToTable("Achievement");
                });

            modelBuilder.Entity("ORM.Model.AchievementUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AchievementId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AchievementId");

                    b.HasIndex("UserId");

                    b.ToTable("AchievementUser");
                });

            modelBuilder.Entity("ORM.Model.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<int>("PageId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PageId");

                    b.HasIndex("UserId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("ORM.Model.Content", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Html");

                    b.Property<int>("PageId");

                    b.HasKey("Id");

                    b.ToTable("Content");
                });

            modelBuilder.Entity("ORM.Model.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("ORM.Model.Layout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Html");

                    b.Property<byte[]>("Image");

                    b.HasKey("Id");

                    b.ToTable("Layout");
                });

            modelBuilder.Entity("ORM.Model.Page", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ContentId");

                    b.Property<DateTime>("LastModififcation");

                    b.Property<int>("LayoutId");

                    b.Property<int>("Order");

                    b.Property<int>("Rating");

                    b.Property<int>("SiteId");

                    b.HasKey("Id");

                    b.HasIndex("ContentId")
                        .IsUnique();

                    b.HasIndex("LayoutId");

                    b.HasIndex("SiteId");

                    b.ToTable("Page");
                });

            modelBuilder.Entity("ORM.Model.Site", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Name");

                    b.Property<int>("StyleMenuId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("StyleMenuId");

                    b.HasIndex("UserId");

                    b.ToTable("Site");
                });

            modelBuilder.Entity("ORM.Model.Style", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Style");
                });

            modelBuilder.Entity("ORM.Model.StyleMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("StyleMenu");
                });

            modelBuilder.Entity("ORM.Model.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Name");

                    b.HasKey("Id");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("ORM.Model.TagSite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("SiteId");

                    b.Property<int>("TagId");

                    b.HasKey("Id");

                    b.HasIndex("SiteId");

                    b.HasIndex("TagId");

                    b.ToTable("TagSite");
                });

            modelBuilder.Entity("ORM.Model.User", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<int>("LanguageId");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<int>("StyleId");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.HasIndex("StyleId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ORM.Model.User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ORM.Model.User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ORM.Model.User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ORM.Model.AchievementUser", b =>
                {
                    b.HasOne("ORM.Model.Achievement", "Achievement")
                        .WithMany("AchievementUser")
                        .HasForeignKey("AchievementId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ORM.Model.User", "User")
                        .WithMany("AchievementUser")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ORM.Model.Comment", b =>
                {
                    b.HasOne("ORM.Model.Page", "Page")
                        .WithMany("Comment")
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ORM.Model.User", "User")
                        .WithMany("Comment")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ORM.Model.Page", b =>
                {
                    b.HasOne("ORM.Model.Content", "Content")
                        .WithOne("Page")
                        .HasForeignKey("ORM.Model.Page", "ContentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ORM.Model.Layout", "Layout")
                        .WithMany("Page")
                        .HasForeignKey("LayoutId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ORM.Model.Site", "Site")
                        .WithMany("Page")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ORM.Model.Site", b =>
                {
                    b.HasOne("ORM.Model.StyleMenu", "StyleMenu")
                        .WithMany("Site")
                        .HasForeignKey("StyleMenuId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ORM.Model.User", "User")
                        .WithMany("Site")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ORM.Model.TagSite", b =>
                {
                    b.HasOne("ORM.Model.Site", "Site")
                        .WithMany("TagSite")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ORM.Model.Tag", "Tag")
                        .WithMany("TagSite")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ORM.Model.User", b =>
                {
                    b.HasOne("ORM.Model.Language", "Language")
                        .WithMany("User")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ORM.Model.Style", "Style")
                        .WithMany("User")
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
