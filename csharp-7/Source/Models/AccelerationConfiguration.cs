using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codenation.Challenge.Models
{
    public class AccelerationConfiguration : IEntityTypeConfiguration<Acceleration>
    {
        public void Configure(EntityTypeBuilder<Acceleration> entity)
        {
            entity.ToTable("acceleration");

            entity.HasKey(a => a.AccelerationId);
            entity.Property(a => a.AccelerationId)
                .HasColumnName("id")
                .IsRequired();

            entity.Property(a => a.ChallengeId)
                .HasColumnName("challenge_id")
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

            entity.HasMany(a => a.Candidates)
                .WithOne();

            entity.HasOne(a => a.Challenge)
                .WithMany(challenge => challenge.Accelerations)
                .HasForeignKey("ChallengeId");
        }
    }
}