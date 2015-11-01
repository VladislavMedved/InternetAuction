using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.EntitiesTypeConfiguration
{
    public class RoleTypeConfiguration : EntityTypeConfiguration<Role>
    {
        #region Ctor
        public RoleTypeConfiguration()
        {
            ToTable("Roles");
            HasKey<int>(p => p.Id);
            Property(p => p.Name).IsRequired().HasMaxLength(15);
        }
        #endregion
    }
}
