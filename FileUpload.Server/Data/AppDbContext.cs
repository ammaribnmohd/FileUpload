using Microsoft.EntityFrameworkCore;
using FileUpload.Server.Data.Entities;

namespace FileUpload.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<FileAttachment> FileAttachments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>()
                .HasMany(u => u.FileAttachments)
                .WithOne(f => f.UserInfo)
                .HasForeignKey(f => f.UserInfoId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
