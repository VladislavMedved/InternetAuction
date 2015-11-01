using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repository;
using System;
using Helpers;
using DAL.Interface.DTO;
using System.Linq.Expressions;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork uow;
        private readonly IUserRepository userRepository;

        public UserService(IUnitOfWork uow, IUserRepository repository)
        {
            this.uow = uow;
            this.userRepository = repository;
        }

        public void Create(UserEntity user)
        {
            userRepository.Create(user.ToDalUser());
            uow.Commit();
        }

        public void Edit(UserEntity user)
        {
            userRepository.Update(user.ToDalUser());
            uow.Commit();
        }

        public void Delete(UserEntity user)
        {
            userRepository.Delete(user.ToDalUser());
            uow.Commit();
        }

        public IEnumerable<UserEntity> GetAllEntities()
        {
            return userRepository.GetAll().Select(user => user.ToBllUser());
        }

        public UserEntity GetById(int id)
        {
            return userRepository.GetById(id).ToBllUser();
        }

        public IEnumerable<UserEntity> GetByPredicate(Expression<Func<UserEntity, bool>> f)
        {
            var modifier = new ParameterExpressionModifier<UserEntity, DalUser>(Expression.Parameter(typeof(DalUser), f.Parameters[0].Name));
            var expression = Expression.Lambda<Func<DalUser, bool>>(modifier.Visit(f.Body), modifier.NewParameterExpr);
            return userRepository.GetByPredicate(expression).Select(user => user.ToBllUser());
        }

        public IEnumerable<UserEntity> GetUsersWithRole(int id)
        {
            IEnumerable<UserEntity> list = userRepository.GetAll().Select(user => user.ToBllUser());
            list = list.Where(u => u.Role_Id == id);
            return list;
        }
    }
}
