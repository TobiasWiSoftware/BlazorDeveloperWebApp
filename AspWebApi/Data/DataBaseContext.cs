using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Entities;
using System.Reflection.Emit;

namespace ASPWebAPI.Data
{
    public class DataBaseContext : IdentityDbContext<UserEntity>
    {
        private readonly IConfiguration _confi;
        public DataBaseContext(DbContextOptions<DataBaseContext> options, IConfiguration confi) : base(options)
        {
            _confi = confi;
        }
        public DbSet<SectionComponentProjectsEntity> SectionComponentProjects { get; set; }
        public DbSet<PictureEntity> PictureEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PictureEntity>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.Base64Data).IsRequired();

                entity.HasOne(p => p.SectionComponentProjectsEntityForSlider)
                      .WithMany(b => b.ImageSliderPictures)
                      .HasForeignKey(p => p.SectionComponentProjectsEntityId);

                entity.HasOne(p => p.SectionComponentProjectsEntityForIcons)
                      .WithMany(b => b.IconPictures)
                      .HasForeignKey(p => p.SectionComponentProjectsEntityId);
            });

            builder.Entity<PictureEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            string? connectionString = _confi.GetConnectionString("DefaultConnection");
            if (!option.IsConfigured && connectionString != null)
            {
                option.UseMySQL(connectionString);
            }
        }



    }
}
