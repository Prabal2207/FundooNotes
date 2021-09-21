using BusinessLayer.Interface;
using CommonLayer;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Services
{
    public class UserRL : IUserRL
    {
        private UserContext _userContext;

        public UserRL(UserContext userContext)
        {
            this._userContext = userContext;
        }

        public bool RegisterUser(UserModel userModel)
        {
            try
            {
                User user = new User();
                user.FirstName = userModel.FirstName;
                user.LastName = userModel.LastName;
                user.Email = userModel.Email;
                user.Password = userModel.Password;
                user.CreatedAt = DateTime.Now;
                user.ModifiedAt = null;

                this._userContext.Users.Add(user);
                int result = _userContext.SaveChanges();

                if (result > 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public User UserLogIn(LogInModel logInModel)
        {
            try
            {
                var result = _userContext.Users.SingleOrDefault(e => e.Email == logInModel.email
                                                                    && e.Password == logInModel.password);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public User ForgetPassword(ForgetPasswordModel forgetpaswordModel)
        {
            try
            {
                var result = _userContext.Users.SingleOrDefault(e => e.Email == forgetpaswordModel.email);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public User ResetPassword(ResetPasswordModel resetpaswordModel,long UserId)
        {

            try
            {
                 User result = _userContext.Users.SingleOrDefault(e=>e.UserId == UserId);
                if (result != null)
                {
                    result.Password = resetpaswordModel.Password;

                    result.ModifiedAt = DateTime.Now;
                    _userContext.SaveChanges();
                }
                return result; 

            }
            catch (Exception)
            {

                throw;
            }





        }
    }
}

