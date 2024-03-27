using System;
using Common_Layer.Request_Model;
using Repository_Layer.Enitty;

namespace Repository_Layer.Interfaces
{
	public interface IUserRepository
	{
        Task<UserEntity> RegisterUser(RegisterModel model);

    }
}

