using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecognitionCore.Domain.Entities;

namespace ApplicationCore.Persistance.Configuration;

public class UserConfiguration: IEntityTypeConfiguration<User>
{
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
}