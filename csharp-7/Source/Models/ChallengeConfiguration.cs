using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codenation.Challenge.Models
{
    public class ChallengeConfiguration : IEntityTypeConfiguration<Challenge>
    {
        public void Configure(EntityTypeBuilder<Challenge> entity)
        {
            entity.ToTable("challenge");

            entity.HasKey(a => a.ChallengeId);
            entity.Property(a => a.ChallengeId)
                .HasColumnName("id")
                .IsRequired();

            entity.Property(a => a.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(a => a.Slug)
                .HasColumnName("slug")
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(a => a.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();

            entity.HasMany(challenge => challenge.Accelerations)
                .WithOne();

            entity.HasMany(challenge => challenge.Submissions)
                .WithOne();
        }
    }
}