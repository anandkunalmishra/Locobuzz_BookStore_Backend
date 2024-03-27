
using System;
using Common_Layer.Encrypt;
using Common_Layer.Request_Model;
using Microsoft.EntityFrameworkCore;
using Repository_Layer.Context;
using Repository_Layer.Enitty;
using Repository_Layer.Interfaces;

namespace Repository_Layer.Services
{
	public class UserRepository : IUserRepository
	{
		private readonly BookStoreContext context;
		public UserRepository(BookStoreContext context)
		{ 
			this.context = context;
		}
		public async Task<UserEntity> RegisterUser(RegisterModel model)
		{
			if( await context.UserTable.FirstOrDefaultAsync(x=>x.Email_Id == model.Email_Id) == null)
			{
                Encrypt objencrypt = new Encrypt();
                //A new entity obj is created to store the value from model
                UserEntity entity = new UserEntity();

                //adding the values to entity
                entity.FullName = model.FullName;
                entity.Email_Id = model.Email_Id;
                entity.Password = objencrypt.generateHash(model.Password);
                entity.Mobile_Number = model.Mobile_Number;
                entity.CreatedAt = DateTime.Now;
                entity.UpdatedAt = DateTime.Now;
                entity.UserRole = "User";

                //Trying the addition of the entity to the table
                try
                {
                    context.UserTable.Add(entity);
                    await context.SaveChangesAsync();
                }
                //Error analysis
                catch
                {
                    throw new Exception("Database update failed - some error occured");
                }


                //Finally return the output
                return entity;
            }
            throw new Exception("User Already Exists");
		}
		
	}
}

