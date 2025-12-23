using Microsoft.EntityFrameworkCore;
using progCompany.Models;
using progCompany.Models.DeveloperModel;
using progCompany.Models.Project;
using progCompany.Models.UserModel;

namespace progCompany.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserClass> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectDeveloper> ProjectDevelopers { get; set; }
        public DbSet<developerModel> Developers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Primary key for developerModel
            modelBuilder.Entity<developerModel>()
                .HasKey(d => d.UserId);

            // ProjectDeveloper composite key
            modelBuilder.Entity<ProjectDeveloper>()
                .HasKey(pd => new { pd.ProjectId, pd.DeveloperId });

            // Project -> ProjectDeveloper relationship (restrict delete)
            modelBuilder.Entity<ProjectDeveloper>()
                .HasOne(pd => pd.Project)
                .WithMany(p => p.ProjectDevelopers)
                .HasForeignKey(pd => pd.ProjectId)
                .OnDelete(DeleteBehavior.Restrict); // <- critical

            // Developer -> ProjectDeveloper relationship (restrict delete)
            modelBuilder.Entity<ProjectDeveloper>()
                .HasOne(pd => pd.Developer)
                .WithMany(d => d.ProjectDevelopers)
                .HasForeignKey(pd => pd.DeveloperId)
                .OnDelete(DeleteBehavior.Restrict); // <- critical

            // Optional: Developer -> UserClass one-to-one
            modelBuilder.Entity<developerModel>()
                .HasOne(d => d.User)
                .WithOne()
                .HasForeignKey<developerModel>(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
