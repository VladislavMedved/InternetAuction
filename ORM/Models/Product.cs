using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public partial class Product
    {
        public int Id { get; set; }
        public decimal Auction_Cost { get; set; }
        public DateTime AuctionStart { get; set; }
        public DateTime AuctionEnd { get; set; }
        public int Seller_Id { get; set; }
        public int Customer_Id { get; set; }
        public string Description { get; set; }
        public virtual User Seller { get; set; }
        public virtual User Customer { get; set; }
    }
}
