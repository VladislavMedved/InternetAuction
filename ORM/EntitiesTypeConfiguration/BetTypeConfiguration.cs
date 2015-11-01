using ORM;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.EntitiesTypeConfiguration
{
    public class BetTypeConfiguration : EntityTypeConfiguration<Bet>
    {
        #region Ctor
        public BetTypeConfiguration()
        {
            ToTable("Bets");
            HasKey<int>(p => p.BetId);
            Property(p => p.UserId).IsRequired().HasColumnName("User");
            Property(p => p.ProductId).IsRequired().HasColumnName("Product");
            Property(p => p.Price).IsRequired();
            Property(p => p.Date).IsRequired();
            //HasRequired(p => p.User).WithMany(p => p.Bets).HasForeignKey(p => p.UserId);
            //HasRequired(p => p.Product).WithMany(p => p.Bets).HasForeignKey(p => p.ProductId);
        }
        #endregion
    }
}
