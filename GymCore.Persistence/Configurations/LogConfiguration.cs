using GymCore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymCore.Persistence.Configurations
{
    public class LogConfiguration : BaseEntityConfiguration<LogEntity>
    {
        public override void ConfigureEntityProperties(EntityTypeBuilder<LogEntity> builder)
        {

        }
    }
}
