using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Painty.Test.Database.Entities;

namespace Painty.Test.Database.EntityContext
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Friends).WithMany(x => x.Friends);
            builder.HasMany(x => x.Images);
        }
    }
}
