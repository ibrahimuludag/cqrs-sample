using CqrsSample.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CqrsSample.Data.Configuration
{
    public class StudentConfiguration : BaseEntityConfiguration<Student>
    {
        public override void Configure(EntityTypeBuilder<Student> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
