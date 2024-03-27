using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common_Layer.Request_Model;
using Common_Layer.Response_Model;
using Manager_Layer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository_Layer.Enitty;

namespace BookStore_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserManager userManager;
        public UserController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser(RegisterModel model)
        {
            try
            {
                var response = await userManager.RegisterUser(model);
                if (response != null)
                {
                    return Ok(new ResModel<UserEntity> { Success = true, Message = "User Successfully registered", Data = response });
                }
                else
                {
                    return BadRequest(new ResModel<UserEntity> { Success = false , Message="User not registered",Data = null});
                }
            }
            catch(Exception ex)
            {
                return BadRequest(new ResModel<UserEntity> { Success = false, Message = ex.Message, Data = null });
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUser(LoginModel model)
        {
            try
            {
                var response = await userManager.LoginUser(model);
                if (response != null)
                {
                    return Ok(new ResModel<string> { Success = true, Message = "User login successfu", Data = response });
                }
                else
                {
                    return BadRequest(new ResModel<string> { Success = false, Message = "User login unsuccessful", Data = null });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<string> { Success = false, Message = ex.Message, Data = null });
            }
        }

    }
}

