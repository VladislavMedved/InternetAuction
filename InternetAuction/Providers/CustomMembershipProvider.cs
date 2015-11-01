using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Helpers;
using System.Security.Principal;
using Ninject;
using BLL.Interface.Services;
using BLL.Interface.Entities;

namespace MvcPL.Providers
{
    public class CustomMembershipProvider : MembershipProvider
    {
        private IUserService userService;

        public CustomMembershipProvider()
        {
            this.userService = userService = (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));
        }

        public override MembershipUser GetUser(string login, bool userIsOnline)
        {
            if (login == null) return null;

            MembershipUser membershipUser = null;

            try
            {
                var user = userService.GetByPredicate(u => u.Login == login).FirstOrDefault();

                if (user == null) return null;

                membershipUser = new MembershipUser("CustomMembershipProvider", user.Login, null, null, null, null,
                        false, false, user.RegistryDate, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue);

            }
            catch
            {
                return null;
            }
            return membershipUser;
        }

        public MembershipUser CreateUser(UserEntity user)
        {
            if (user == null) return null;

            MembershipUser membershipUser = GetUser(user.Login, false);
            if (membershipUser == null)
            {
                try
                {
                    //user.Password = Crypto.HashPassword(user.Password);
                    userService.Create(user);
                    membershipUser = GetUser(user.Login, false);
                    return membershipUser;
                }
                catch
                {
                    return null;
                }

            }
            return null;
        }

        public override bool ValidateUser(string username, string password)
        {
            bool isValid = false;
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password)) return false;

            try
            {
                var user = userService.GetByPredicate(u => u.Login == username).FirstOrDefault();
                //if (user != null && Crypto.VerifyHashedPassword(user.Password, password))
                if (user != null && String.CompareOrdinal(user.Password, password) == 0)
                {
                    isValid = true;
                }
            }
            catch
            {
                //Log неудачная попытка входа в систему
                isValid = false;
            }
            return isValid;
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(oldPassword) || String.IsNullOrEmpty(newPassword)) return false;

            bool isChanged = false;

            try
            {

                MembershipUser membershipUser = GetUser(username, false);

                if (membershipUser == null)
                {
                    return false;
                }

                if (!ValidateUser(username, newPassword)) return false;

                var user = userService.GetByPredicate(u => u.Login == username).FirstOrDefault();

                user.Password = newPassword;
            }
            catch
            {
                return false;
            }
            return isChanged;
        }

        public IEnumerable<UserEntity> GetAllUsers()
        {

            IEnumerable<UserEntity> users = null;
            try
            {
                users = userService.GetAllEntities();
            }
            catch
            {
                return null;
            }

            return users;
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }
    }
}