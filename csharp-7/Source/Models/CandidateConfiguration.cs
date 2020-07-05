using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codenation.Challenge.Models
{
    public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> entity)
        {
            entity.ToTable("candidate");

            entity.Property(c => c.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            entity.Property(c => c.AccelerationId)
                .HasColumnName("acceleration_id")
                .IsRequired();

            entity.Property(c => c.CompanyId)
                .HasColumnName("company_id")
                .IsRequired();

            entity.Property(c => c.Status)
                .HasColumnName("status")
                .IsRequired();

            entity.Property(c => c.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();

            entity.HasKey(candidate => new { candidate.AccelerationId, candidate.CompanyId, candidate.UserId });

            entity.HasOne(candidate => candidate.Acceleration)
                .WithMany(acceleration => acceleration.Candidates)
                .HasForeignKey("AccelerationId");

            entity.HasOne(candidate => candidate.Company)
                .WithMany(company => company.Candidates)
                .HasForeignKey("CompanyId");

            entity.HasOne(candidate => candidate.User)
                .WithMany(user => user.Candidates)
                .HasForeignKey("UserId");
        }
    }
}