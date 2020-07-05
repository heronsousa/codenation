using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codenation.Challenge.Models
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("user");

            entity.HasKey(a => a.UserId);
            entity.Property(a => a.UserId)
                .HasColumnName("id")
                .IsRequired();

            entity.Property(a => a.FullName)
                .HasColumnName("full_name")
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(a => a.Email)
               .HasColumnName("email")
               .HasMaxLength(100)
               .IsRequired();

            entity.Property(a => a.Nickname)
                .HasColumnName("nickname")
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(a => a.Password)
               .HasColumnName("password")
               .HasMaxLength(255)
               .IsRequired();

            entity.Property(a => a.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();

            entity.HasMany(user => user.Candidates)
                .WithOne();
            
            entity.HasMany(user => user.Submissions)
                .WithOne();
        }
    }
}