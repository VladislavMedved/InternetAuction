using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.EntitiesTypeConfiguration
{
    public class UserTypeConfiguration : EntityTypeConfiguration<User>
    {
        #region Ctor
        public UserTypeConfiguration()
        {
            ToTable("Users");
            HasKey<int>(p => p.Id);
            Property(p => p.Login).IsRequired().HasMaxLength(30);
            Property(p => p.E_mail).IsRequired();
            Property(p => p.Password).IsRequired();
            Property(p => p.RegistryDate).IsRequired();
            Property(p => p.Role_Id).IsRequired().HasColumnName("Role");
            HasMany(p => p.SoldProducts).WithRequired(p => p.Seller).HasForeignKey(p => p.Seller_Id).WillCascadeOnDelete(false);
            HasMany(p => p.BoughtProducts).WithRequired(p => p.Customer).HasForeignKey(p => p.Customer_Id).WillCascadeOnDelete(false);
            HasRequired(p => p.Role).WithMany(p => p.Users).HasForeignKey(p => p.Role_Id).WillCascadeOnDelete(false);
        }
        #endregion
    }
}
