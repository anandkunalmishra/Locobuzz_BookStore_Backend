using System;
using Common_Layer.Request_Model;
using Repository_Layer.Enitty;

namespace Manager_Layer.Interfaces
{
	public interface IAddressManager
	{
        Task<AddressEntity> AddAddress(int userId, AddAddressModel model);
        Task<bool> UpdateAddress(int userId, int addressId, AddAddressModel model);
        Task<AddressEntity> RemoveAddress(int userId, int addressId);
        Task<List<AddressEntity>> GetAllAddress(int userId);
    }
}

