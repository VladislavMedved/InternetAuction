using BLL.Interface.Services;
using DAL.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BetService: IBetService
    {
        private readonly IUnitOfWork uow;
        private readonly IBetRepository betRepository;

        public BetService(IUnitOfWork uow, IBetRepository repository)
        {
            this.uow = uow;
            this.betRepository = repository;
        }


        public IEnumerable<Interface.Entities.BetEntity> GetBetsByUser(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Interface.Entities.BetEntity> GetBetsByProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Interface.Entities.BetEntity> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public Interface.Entities.BetEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Interface.Entities.BetEntity> GetByPredicate(System.Linq.Expressions.Expression<Func<Interface.Entities.BetEntity, bool>> p)
        {
            throw new NotImplementedException();
        }

        public void Create(Interface.Entities.BetEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Interface.Entities.BetEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Interface.Entities.BetEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
