using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Harfiyat_DataAccess.Context;

public class ConsturactionContextFactory : IDesignTimeDbContextFactory<ConsturactionContext>
{
    public ConsturactionContext CreateDbContext(string[] args)
    {
        var optBuilder = new DbContextOptionsBuilder<ConsturactionContext>();
        optBuilder.UseSqlite("Data Source=dbharfiyat");

        return new ConsturactionContext(optBuilder.Options);
    }

}
