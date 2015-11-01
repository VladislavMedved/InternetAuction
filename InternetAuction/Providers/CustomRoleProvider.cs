using BLL.Interface.Entities;
using BLL.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MvcPL.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        private IRoleService roleService;
        private IUserService userService;

        public CustomRoleProvider(IRoleService roleService, IUserService userService)
        {
            this.roleService = roleService;
            this.userService = userService;
        }

        public override bool IsUserInRole(string login, string roleName)
        {
            if (String.IsNullOrEmpty(login) || String.IsNullOrEmpty(roleName)) return false;
            bool outputResult = false;

            try
            {

                UserEntity user = userService.GetByPredicate(u => u.Login == login).FirstOrDefault();

                if (user != null)
                {
                    RoleEntity userRole = roleService.GetById(user.Role_Id);

                    if (userRole != null && userRole.Name == roleName)
                    {
                        return true;
                    }
                }

            }
            catch
            {
                outputResult = false;
            }

            return outputResult;
        }

        public override string[] GetRolesForUser(string login)
        {
            if (login == null) return null;
            
            string[] roles = new string[] { };

            try
            {
                UserEntity user = userService.GetByPredicate(u => u.Login == login).FirstOrDefault();

                if (user == null)
                {
                    return roles;
                }

                RoleEntity userRole = roleService.GetById(user.Role_Id);
                roles[0] = userRole.Name;
            }
            catch
            {
                return roles;
            }
            return roles;
        }

        public override void CreateRole(string roleName)
        {
            roleService.Create(new RoleEntity() { Name = roleName });
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            bool isDeleted = false;
            
            try
            {
                RoleEntity role = roleService.GetByPredicate(u => u.Name == roleName).FirstOrDefault();
                if (role != null)
                    roleService.Delete(role);
            }
            catch
            {
                isDeleted = false;
            }
            return isDeleted;            
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}