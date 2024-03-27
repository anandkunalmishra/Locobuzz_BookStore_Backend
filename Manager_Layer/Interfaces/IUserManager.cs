using System;
using Common_Layer.Request_Model;
using Repository_Layer.Enitty;

namespace Manager_Layer.Interfaces
{
	public interface IUserManager
	{
        Task<UserEntity> RegisterUser(RegisterModel model);
        Task<string> LoginUser(LoginModel model);
        Task<string> ForgetPassword(ForgetPassModel model);

    }
}

