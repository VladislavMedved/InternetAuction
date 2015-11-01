using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public partial class Bet
    {
        public int BetId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}
