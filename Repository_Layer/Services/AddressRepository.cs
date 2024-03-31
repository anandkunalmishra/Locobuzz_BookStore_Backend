using System;
using Common_Layer.Request_Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository_Layer.Context;
using Repository_Layer.Enitty;
using Repository_Layer.Interfaces;
using RepositoryLayer.Migrations;

namespace Repository_Layer.Services
{
	public class AddressRepository:IAddressRepository
	{
		private readonly BookStoreContext context;

		public AddressRepository(BookStoreContext context)
		{
			this.context = context;
		}

        public async Task<AddressEntity> AddAddress(int userId,AddAddressModel model)
        {
            var user = await context.UserTable.FirstOrDefaultAsync(a => a.UserId == userId);
            if (user == null)
            {
                throw new Exception("User doesn't exist");
            }
            
            if (user.UserRole != "Admin")
            {
                AddressEntity address = new AddressEntity();
                address.User = user;
                address.UserId = user.UserId;
                address.StreetAddress = model.StreetAddress;
                address.State = model.State;
                address.City = model.City;
                address.Country = model.Country;
                address.LandMark = model.LandMark;
                address.PostalCode = model.PostalCode;

                context.AddressTable.Add(address);
                await context.SaveChangesAsync();
                return address;
            }
            throw new Exception("Admin can't add address!");
        }

        public async Task<bool> UpdateAddress(int userId,int addressId,AddAddressModel model)
        {
            var user = await context.UserTable.FirstOrDefaultAsync(a => a.UserId == userId);
            if (user == null)
            {
                throw new Exception("User doesn't exist");
            }
            if (user.UserRole != "Admin")
            {
                var entity = await context.AddressTable.FirstOrDefaultAsync(a => a.AddressId == addressId);
                if (entity != null)
                {
                    entity.StreetAddress = model.StreetAddress;
                    entity.State = model.State;
                    entity.City = model.City;
                    entity.Country = model.Country;
                    entity.LandMark = model.LandMark;
                    entity.PostalCode = model.PostalCode;

                    await context.SaveChangesAsync();
                    return true;
                }
                throw new Exception("Address does not exists!");
            }
            throw new Exception("Admin can't remove address!");
        }

        public async Task<AddressEntity> RemoveAddress(int userId, int addressId)
        {
            var user = await context.UserTable.FirstOrDefaultAsync(a => a.UserId == userId);
            if (user == null)
            {
                throw new Exception("User doesn't exist");
            }
            if (user.UserRole != "Admin")
            {
                var entity = await context.AddressTable.FirstOrDefaultAsync(a => a.AddressId == addressId);
                if (entity != null)
                {
                    context.AddressTable.Remove(entity);
                    await context.SaveChangesAsync();
                    return entity;
                }
                throw new Exception("Address does not exists!");
            }
            throw new Exception("Admin can't remove address!");
        }

        public async Task<List<AddressEntity>> GetAllAddress(int userId)
        {
            var user = await context.UserTable.FirstOrDefaultAsync(a => a.UserId == userId);
            if (user == null)
            {
                throw new Exception("User doesn't exist");
            }
            if (user.UserRole != "Admin")
            {
                var entity = await context.AddressTable.Where(a => a.UserId == userId).ToListAsync();
                if (entity != null)
                {
                    return entity;
                }
                throw new Exception("addresslist is empty!");
            }
            throw new Exception("Admin can't see address!");
        }

    }
}


