using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Covera.PolicyImagingSystem.EntityFrameworkCore.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Covera.PolicyImagingSystem.EntityFrameworkCore.Factories
{
    public class C360CoveraDbContextFactory : IDesignTimeDbContextFactory<C360CoveraDbContext>
    {
        public C360CoveraDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<C360CoveraDbContext>()
                .UseSqlServer(configuration.GetConnectionString("BusinessDb"));

            return new C360CoveraDbContext(builder.Options);
        }
    }
}
