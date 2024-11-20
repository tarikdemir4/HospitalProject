using HospitalProjectServer.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalProjectServer.Entities.Configurations;
internal sealed class DoctorDetailConfiguration : IEntityTypeConfiguration<DoctorDetail>
{
    public void Configure(EntityTypeBuilder<DoctorDetail> builder)
    {
        builder.HasKey(key => key.UserId);
    }
}
