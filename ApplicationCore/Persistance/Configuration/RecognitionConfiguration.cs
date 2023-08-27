using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecognitionCore.Domain.Entities;

namespace ApplicationCore.Persistance.Configuration;

public class RecognitionConfiguration : IEntityTypeConfiguration<Recognition>
{
    public void Configure(EntityTypeBuilder<Recognition> builder)
    {
        builder.Property(p => p.Header).HasMaxLength(100).IsRequired(true);
        builder.Property(p => p.Description).HasMaxLength(1000);
        builder.HasOne(p => p.RecognizedUser)
                .WithMany(p => p.Recognitions)
                .HasForeignKey(p => p.RecognizedUserId)
                .IsRequired();
        
        builder.HasOne(p => p.RecognizedByUser)
            .WithMany(p => p.Recognitions)
            .HasForeignKey(p => p.RecognizedByUserId)
            .IsRequired();
    }
}