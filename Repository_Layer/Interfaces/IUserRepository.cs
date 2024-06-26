﻿using System;
using Common_Layer.Request_Model;
using Repository_Layer.Enitty;

namespace Repository_Layer.Interfaces
{
	public interface IUserRepository
	{
        Task<UserEntity> RegisterUser(RegisterModel model);
        Task<string> LoginUser(LoginModel model);
        Task<string> ForgetPassword(ForgetPassModel model);
        Task<bool> ResetPassword(int userId, ResetPassModel model);
    }
}

