using Entekhab.Domain.Entities.HumanResourceModels;
using Microsoft.EntityFrameworkCore;

namespace Entekhab.Data.EntityFramework.DbContext.EntityMaps.HRMapConfig;

public class HREmployeeMapConfig
{
    //********************************************************************************************************************
    public HREmployeeMapConfig(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<HREmployeeModel> entity)
    {
        entity.ToTable("HREmployee");
    }
    //********************************************************************************************************************
}