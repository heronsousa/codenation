using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Models
{
    public class CodenationContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Acceleration> Accelerations { get; set; }
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Submission> Submissions { get; set; }
                
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Codenation;Trusted_Connection=True");            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acceleration>(entity =>
            {
                entity.HasMany(acceleration => acceleration.Candidates).WithOne();
                entity.HasOne(acceleration => acceleration.Challenge).WithMany(challenge => challenge.Accelerations).HasForeignKey("ChallengeId");
            });

            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.HasKey(candidate => new { candidate.AccelerationId, candidate.CompanyId, candidate.UserId } );
                entity.HasOne(candidate => candidate.Acceleration).WithMany(acceleration => acceleration.Candidates).HasForeignKey("AccelerationId");
                entity.HasOne(candidate => candidate.Company).WithMany(company => company.Candidates).HasForeignKey("CompanyId");
                entity.HasOne(candidate => candidate.User).WithMany(user => user.Candidates).HasForeignKey("UserId");
            });

            modelBuilder.Entity<Challenge>(entity =>
            {
                entity.HasMany(challenge => challenge.Accelerations).WithOne();
                entity.HasMany(challenge => challenge.Submissions).WithOne();
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasMany(company => company.Candidates).WithOne();
            });

            modelBuilder.Entity<Submission>(entity =>
            {
                entity.HasKey(submission => new { submission.UserId, submission.ChallengeId });
                entity.HasOne(submission => submission.Challenge).WithMany(challenge => challenge.Submissions);
                entity.HasOne(submission => submission.User).WithMany(user => user.Submissions);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasMany(user => user.Candidates).WithOne();
                entity.HasMany(user => user.Submissions).WithOne();
            });
        }
    }
}