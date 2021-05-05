using BlazorDemo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorDemo.Database.EntityConfigurations
{
    public class SurveyConfiguration : IEntityTypeConfiguration<Survey>
    {
        public void Configure(EntityTypeBuilder<Survey> builder)
        {
            builder.HasMany(s => s.Answers);

            builder.Property(s => s.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(s => s.LastName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(s => s.Gender)
                .IsRequired();
            builder.Property(s => s.Nationality)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(s => s.Email)
                .HasMaxLength(50);
            builder.Property(s => s.PhoneNumber)
                .HasMaxLength(13);
        }
    }
}
