using BLL.Interface.Entities;
using DAL.Interface.DTO;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Mappers
{
    public static class UserMapper
    {
        public static DalUser ToDalUser(this UserEntity userEntity)
        {
            List<DalProduct> soldProducts = null;
            if (userEntity.SoldProducts != null)            
                 soldProducts = userEntity.SoldProducts.Select(e => e.ToDalProduct()).ToList();

            List<DalProduct> boughtProducts = null;

            if (userEntity.BoughtProducts != null) 
                 boughtProducts = userEntity.BoughtProducts.Select(e => e.ToDalProduct()).ToList();
            
            return new DalUser()
            {
                Id = userEntity.Id,
                Login = userEntity.Login,
                E_mail = userEntity.E_mail,
                Password = userEntity.Password,
                Role_Id = userEntity.Role_Id,
                RegistryDate = userEntity.RegistryDate,
                SoldProducts = soldProducts,
                BoughtProducts = boughtProducts
            };
        }

        public static UserEntity ToBllUser(this DalUser dalUser)
        {
            List<ProductEntity> soldProducts = null;
            if (dalUser.SoldProducts != null)
                soldProducts = dalUser.SoldProducts.Select(e => e.ToBllProduct()).ToList();

            List<ProductEntity> boughtProducts = null;

            if (dalUser.BoughtProducts != null)
                boughtProducts = dalUser.BoughtProducts.Select(e => e.ToBllProduct()).ToList();
            
            return new UserEntity()
            {
                Id = dalUser.Id,
                Login = dalUser.Login,
                E_mail = dalUser.E_mail,
                Password = dalUser.Password,
                Role_Id = dalUser.Role_Id,
                RegistryDate = dalUser.RegistryDate,
                SoldProducts = soldProducts,
                BoughtProducts = boughtProducts
            };
        }
    }
}
