﻿using System;
namespace DAL.Interface.DTO
{
    public class DalProduct : IEntity
    {
        public int Id { get; set; }
        public decimal Auction_Cost { get; set; }
        public DateTime AuctionStart { get; set; }
        public DateTime AuctionEnd { get; set; }
        public int Seller_Id { get; set; }
        public int Customer_Id { get; set; }
        public string Description { get; set; }
    }
}
