using GymCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymCore.Persistence.Configurations
{
    public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(w => w.Id)
                 .ValueGeneratedOnAdd();
            builder
                 .Property(w => w.ModifiedDate)
                 .HasDefaultValueSql("now()");
        }

        public abstract void ConfigureEntityProperties(EntityTypeBuilder<T> builder);
    }
}
