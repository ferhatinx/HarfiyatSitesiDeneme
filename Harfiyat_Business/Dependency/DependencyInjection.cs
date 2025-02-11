
using System.Reflection;
using FluentValidation;
using Harfiyat_Business.Interfaces;
using Harfiyat_Business.Managers;
using Harfiyat_Business.Services;
using Harfiyat_Business.Validations;
using Harfiyat_DataAccess.Concrete;
using Harfiyat_DataAccess.Context;
using Harfiyat_DataAccess.Contracts;
using Harfiyat_Entities.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;

namespace Harfiyat_Business.Dependency;

public static class DependencyInjection
{
    public static void GetDependency(this IServiceCollection services)
    {
        services.AddDbContext<ConsturactionContext>(opt=>{
            opt.UseSqlite("Data Source=dbharfiyat",opt => opt.MigrationsAssembly("Harfiyat_DataAccess"));
        });

    }
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IJobRequestReepository,JobRequestRepository>();
        services.AddScoped<IRepositoryManager,RepositoryManager>();
        services.AddScoped<IJobRepository,JobRepository>();
    }
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IJobRequestService,JobRequestManager>();
        services.AddScoped<IBaseService,ServiceManager>();
        services.AddScoped<IJobService,JobManager>();
    }
    public static void ConfigureFluentValidation(this IServiceCollection services)
    {
        services.AddTransient<IValidator<JobRequest>, JobRequestValidation>();
        services.AddTransient<IValidator<Job>,JobValidation>();
        
        //! AUTO Fluentvalidaton NET6 Da çalışmıyor ????
        // services.AddValidatorsFromAssemblyContaining<JobRequest>();
    }
    public static void ConfigureAutoMigrate(this IApplicationBuilder app)
    {
       ConsturactionContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ConsturactionContext>();    
        if(context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }
    }
}
