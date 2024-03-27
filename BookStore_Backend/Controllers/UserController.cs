using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common_Layer.Request_Model;
using Common_Layer.Response_Model;
using Common_Layer.Utility;
using Manager_Layer.Interfaces;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Repository_Layer.Enitty;

namespace BookStore_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserManager userManager;
        private readonly IBus bus;
        public UserController(IUserManager userManager,IBus bus)
        {
            this.userManager = userManager;
            this.bus = bus;
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

        [HttpPost]
        [Route("forgetpass")]
        public async Task<IActionResult> ForgetPassword(ForgetPassModel model)
        {
            try
            {
                var response = await userManager.ForgetPassword(model);
                if (response != null)
                {
                    Send send = new Send();
                    string str = send.SendMail(model.Email_Id, response);
                    Uri uri = new Uri("rabbitmq://localhost/bookstore");
                    var endpoint = await bus.GetSendEndpoint(uri);
                    return Ok(new ResModel<bool> { Success = true, Message = "forget pass successfu", Data = true });
                }
                else
                {
                    return BadRequest(new ResModel<bool> { Success = false, Message = "forget pass unsuccessful", Data = false });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<bool> { Success = false, Message = ex.Message, Data = false });
            }
        }

    }
}

