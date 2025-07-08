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
    public class CoveraConfigDbContextFactory : IDesignTimeDbContextFactory<CoveraConfigDbContext>
    {
        public CoveraConfigDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<CoveraConfigDbContext>()
                .UseSqlServer(configuration.GetConnectionString("ConfigDb"));

            return new CoveraConfigDbContext(builder.Options);
        }
    }
}
