using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class ProductsViewModel
    {
        [Display(Name = "Lot №")]
        public int Id { get; set; }

        [Display(Name = "Product Cost")]
        public decimal Auction_Cost { get; set; }

        [Required]
        [Display(Name = "End Time")]
        public DateTime AuctionEnd { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        public DateTime AuctionStart { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}