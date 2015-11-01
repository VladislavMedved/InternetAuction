using DAL.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class BetRepository: IBetRepository
    {
        private readonly DbContext context;

        public BetRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            this.context = context;
        }

        public IEnumerable<Interface.DTO.DalBet> GetBetsByUser(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Interface.DTO.DalBet> GetBetsByProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Interface.DTO.DalBet> GetAll()
        {
            throw new NotImplementedException();
        }

        public Interface.DTO.DalBet GetById(int key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Interface.DTO.DalBet> GetByPredicate(System.Linq.Expressions.Expression<Func<Interface.DTO.DalBet, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(Interface.DTO.DalBet e)
        {
            throw new NotImplementedException();
        }

        public void Delete(Interface.DTO.DalBet e)
        {
            throw new NotImplementedException();
        }

        public void Update(Interface.DTO.DalBet e)
        {
            throw new NotImplementedException();
        }
    }
}
