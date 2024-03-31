using System;
using Common_Layer.Request_Model;
using Manager_Layer.Interfaces;
using Repository_Layer.Enitty;
using Repository_Layer.Interfaces;

namespace Manager_Layer.Services
{
	public class AddressManager:IAddressManager
	{
        private readonly IAddressRepository address;
		public AddressManager(IAddressRepository address)
		{
            this.address = address;
		}

        public async Task<AddressEntity> AddAddress(int userId, AddAddressModel model)
        {
            return await address.AddAddress(userId, model);
        }
        public async Task<bool> UpdateAddress(int userId, int addressId, AddAddressModel model)
        {
            return await address.UpdateAddress(userId,addressId, model);
        }
        public async Task<AddressEntity> RemoveAddress(int userId, int addressId)
        {
            return await address.RemoveAddress(userId, addressId);
        }
        public async Task<List<AddressEntity>> GetAllAddress(int userId)
        {
            return await address.GetAllAddress(userId);
        }
    }
}

