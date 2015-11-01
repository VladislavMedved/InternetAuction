using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Repository
{
    public interface IBetRepository : IRepository<DalBet>
    {
        IEnumerable<DalBet> GetBetsByUser(int id);
        IEnumerable<DalBet> GetBetsByProduct(int id);
    }
}
