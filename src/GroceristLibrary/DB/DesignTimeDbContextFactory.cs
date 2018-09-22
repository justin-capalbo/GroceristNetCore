using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace GroceristLibrary.DB
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<GroceristContext>
    {
        public GroceristContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<GroceristContext>();

            var connectionString = configuration.GetConnectionString("GroceristService");

            builder.UseSqlServer(connectionString);

            return new GroceristContext(builder.Options);
        }
    }
}
