using eRecruitment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eRecruitment.Infrastructure.Data.Configurations;
public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.Property(t => t.CompanyTitle)
            .HasMaxLength(200)
            .IsRequired();
    }
}
