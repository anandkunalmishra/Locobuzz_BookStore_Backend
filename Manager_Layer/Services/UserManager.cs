using System;
using Common_Layer.Request_Model;
using Manager_Layer.Interfaces;
using Repository_Layer.Enitty;
using Repository_Layer.Interfaces;

namespace Manager_Layer.Services
{
	public class UserManager:IUserManager
	{
		private readonly IUserRepository user;
		public UserManager(IUserRepository user)
		{
			this.user = user;
		}
        public async Task<UserEntity> RegisterUser(RegisterModel model)
		{
			return await user.RegisterUser(model);
		}
        public async Task<string> LoginUser(LoginModel model)
		{
			return await user.LoginUser(model);
		}

    }
}

