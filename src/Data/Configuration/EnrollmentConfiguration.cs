using CqrsSample.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CqrsSample.Data.Configuration
{
    public class EnrollmentConfiguration : BaseEntityConfiguration<Enrollment>
    {
        public override void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            base.Configure(builder);

            builder.HasIndex(c => new { c.CourseId, c.StudentId })
                .IsUnique();

            builder.HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);

            builder.HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId);
        }
    }
}
