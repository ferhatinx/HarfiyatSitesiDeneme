using System.Reflection;
using Harfiyat_Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Harfiyat_DataAccess.Context;

public class ConsturactionContext : DbContext
{   
    public DbSet<JobRequest>? JobRequests { get; set; }
    public DbSet<Job>? Jobs { get; set; }
    public DbSet<Image>? Images { get; set; }
    public ConsturactionContext(DbContextOptions<ConsturactionContext> options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<JobRequest>().HasData( new JobRequest[] {
            new(){Id=1,RequestedBy="Ferhat Ersoy", RequestDate=DateTime.Now ,JobTitle="Bina Yıkımı",IsApproved=false},
            new(){Id=2,RequestedBy="Osman Ersoy", RequestDate=DateTime.Now ,JobTitle="Kanalizasyon kazimi",IsApproved=false},
            new(){Id=3,RequestedBy="İlker Yalçın", RequestDate=DateTime.Now,JobTitle="Duvar Yikimi",IsApproved=true},
            new(){Id=4,RequestedBy="Uzay Can", RequestDate=DateTime.Now ,JobTitle="Çiçek çukuru kazma",IsApproved=false},
        } );
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
    }
}
