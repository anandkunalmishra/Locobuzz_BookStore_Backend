
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Common_Layer.Encrypt;
using Common_Layer.Request_Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository_Layer.Context;
using Repository_Layer.Enitty;
using Repository_Layer.Interfaces;

namespace Repository_Layer.Services
{
	public class UserRepository : IUserRepository
	{
		private readonly BookStoreContext context;
        private readonly IConfiguration config;
        Encrypt objencrypt = new Encrypt();
        public UserRepository(BookStoreContext context,IConfiguration config)
		{ 
			this.context = context;
            this.config = config;
		}
		public async Task<UserEntity> RegisterUser(RegisterModel model)
		{
			if( await context.UserTable.FirstOrDefaultAsync(x=>x.Email_Id == model.Email_Id) == null)
			{
                
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

        private string GenerateToken(UserEntity user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("email",user.Email_Id),
                new Claim("role",user.UserRole),
                new Claim("userId",user.UserId.ToString())
            };

            var token = new JwtSecurityToken(config["Jwt:Issuer"],
                config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> LoginUser(LoginModel model)
        {
            try
            {
                var user = await context.UserTable.FirstOrDefaultAsync(x => x.Email_Id == model.Email_Id);
                if (user != null)
                {
                    if (objencrypt.matchPassword(model.Password, user.Password))
                    {
                        var token = GenerateToken(user);
                        return token;
                    }
                    throw new Exception("Wrong Credential");
                }
                throw new Exception($"User with email_Id{model.Email_Id} does not exist");
            }
            catch
            {
                throw;
            }
        }
        public async Task<string> ForgetPassword(ForgetPassModel model)
        {
            try
            {
                var user = await context.UserTable.FirstOrDefaultAsync(x => x.Email_Id == model.Email_Id);
                if (user != null)
                {
                    var token = GenerateToken(user);
                    return token;
                }
                throw new Exception($"User with email_Id{model.Email_Id} does not exist");
            }
            catch
            {
                throw;
            }
        }


    }
}

