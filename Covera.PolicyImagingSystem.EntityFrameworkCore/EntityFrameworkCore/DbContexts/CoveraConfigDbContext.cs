using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Covera.PolicyImagingSystem.EntityFrameworkCore.DbContexts
{
    public class CoveraConfigDbContext : DbContext
    {

        public CoveraConfigDbContext(DbContextOptions<CoveraConfigDbContext> options) : base(options) { }
    }
}
