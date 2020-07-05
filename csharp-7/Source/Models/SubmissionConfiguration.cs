using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codenation.Challenge.Models
{
    public class SubmissionConfiguration : IEntityTypeConfiguration<Submission>
    {
        public void Configure(EntityTypeBuilder<Submission> entity)
        {
            entity.ToTable("submission");

            entity.Property(c => c.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            entity.Property(c => c.ChallengeId)
                .HasColumnName("challenge_id")
                .IsRequired();

            entity.Property(c => c.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();

            entity.Property(c => c.Score)
                .HasColumnName("score")
                .HasColumnType("decimal(9,2)")
                .IsRequired();

            entity.HasKey(submission => new { submission.UserId, submission.ChallengeId });

            entity.HasOne(submission => submission.Challenge)
                .WithMany(challenge => challenge.Submissions);
            
            entity.HasOne(submission => submission.User)
                .WithMany(user => user.Submissions);
        }
    }
}