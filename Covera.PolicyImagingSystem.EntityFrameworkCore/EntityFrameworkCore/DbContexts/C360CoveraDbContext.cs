using Covera.PolicyImagingSystem.Core.C360.LifeAssures;
using Covera.PolicyImagingSystem.Core.C360.PolicyHeaders;
using Covera.PolicyImagingSystem.Core.C360.PolicyOwners;
using Microsoft.EntityFrameworkCore;

namespace Covera.PolicyImagingSystem.EntityFrameworkCore.DbContexts
{
    public class C360CoveraDbContext : DbContext
    {

        public DbSet<PolicyOwner> PolicyOwners { get; set; }
        public DbSet<LifeAssure> LifeAssures { get; set; }
        public DbSet<PolicyHeader> PolicyHeaders { get; set; }

        public C360CoveraDbContext(DbContextOptions<C360CoveraDbContext> options)
            : base(options)
        {
        }

    }
}