using Entekhab.Common.Functions;
using Entekhab.Data.EntityFramework.DbContext.EntityMaps.HRMapConfig;
using Entekhab.Domain.Entities.HumanResourceModels;
using Microsoft.EntityFrameworkCore;

namespace Entekhab.Data.EntityFramework.DbContexts;

public class MainDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    //********************************************************************************************************************
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(DataBaseFuncs.GetConnectionstring());
    }
    //********************************************************************************************************************
    public virtual DbSet<HREmployeeModel> HREmployee { get; set; }
    //********************************************************************************************************************

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Configure default schema
        modelBuilder.HasDefaultSchema("dbo");

        #region Identity
        new HREmployeeMapConfig(modelBuilder.Entity<HREmployeeModel>());
        #endregion

        base.OnModelCreating(modelBuilder);
    }
}
