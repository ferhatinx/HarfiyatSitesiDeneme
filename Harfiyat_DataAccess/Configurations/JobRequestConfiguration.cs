using Harfiyat_Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Harfiyat_DataAccess.Configurations;

public class JobRequestConfiguration : IEntityTypeConfiguration<JobRequest>
{
    public void Configure(EntityTypeBuilder<JobRequest> builder)
    {
        builder.HasMany(x=>x.Jobs).WithOne(x=>x.JobRequest).HasForeignKey(x=>x.JobRequestId);
        builder.HasMany(x=>x.Images).WithOne(x=>x.JobRequest).HasForeignKey(x=>x.JobRequestId);
    }

}
public class JobConfiguration : IEntityTypeConfiguration<Job>
{
    public void Configure(EntityTypeBuilder<Job> builder)
    {
        
       
    }
}
