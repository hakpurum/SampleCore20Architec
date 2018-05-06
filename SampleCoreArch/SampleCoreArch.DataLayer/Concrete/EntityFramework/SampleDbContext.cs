using Microsoft.EntityFrameworkCore;
using SampleCoreArch.Core.Logging;
using SampleCoreArch.Entities.Concrete;

namespace SampleCoreArch.DataLayer.Concrete.EntityFramework
{
    public class SampleDbContext : DbContext
    {
        public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<ContentCategoryRelation> ContentCategoryRelations { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<EventLog> EventLog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasOne(d => d.UserGroup)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserGroupId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}