using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Api.Domain.Entities;

namespace src.Api.Data.Mapping
{
  public class UserMap : IEntityTypeConfiguration<UserEntity>
  {
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
      builder.ToTable("UserEntity");

      builder.Property(c => c.Name).IsRequired().HasMaxLength(60);
      builder.Property(c => c.Email).HasMaxLength(100);

      builder.HasIndex(c => c.Email).IsUnique();
    }
  }
}
