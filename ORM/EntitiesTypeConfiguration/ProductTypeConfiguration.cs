using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.EntitiesTypeConfiguration
{
    public class ProductTypeConfiguration : EntityTypeConfiguration<Product>
    {
        #region Ctor
        public ProductTypeConfiguration()
        {
            ToTable("Products");
            HasKey<int>(p => p.Id);
            Property(p => p.Description).IsRequired();
            Property(p => p.AuctionStart).IsRequired().HasColumnName("Start");
            Property(p => p.AuctionEnd).IsRequired().HasColumnName("End");
            Property(p => p.Auction_Cost).IsRequired();
            Property(p => p.Seller_Id).IsRequired().HasColumnName("Seller");
        }
        #endregion
    }
}
