using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Common_Layer.Request_Model;
using Common_Layer.Response_Model;
using Manager_Layer.Interfaces;
using Manager_Layer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository_Layer.Enitty;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore_Backend.Controllers
{
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressManager addressManager;
        public AddressController(IAddressManager addressManager)
        {
            this.addressManager = addressManager;
        }
        [HttpPost]
        [Authorize]
        [Route("AddAddres")]
        public async Task<IActionResult> AddAddress(AddAddressModel model)
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
                var response = await addressManager.AddAddress(userId, model);
                if (response != null)
                {
                    return Ok(new ResModel<AddressEntity> { Success = true, Message = "Address Added successfully!", Data = response });
                }
                return BadRequest(new ResModel<AddressEntity> { Success = false, Message = "Address Addition Unsuccessful", Data = null });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<AddressEntity> { Success = false, Message = ex.Message, Data = null });
            }
        }

        [HttpPut]
        [Authorize]
        [Route("UpdateAddres")]
        public async Task<IActionResult> UpdateAddress(int AddressId,AddAddressModel model)
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
                var response = await addressManager.UpdateAddress(userId, AddressId,model);
                if (response != null)
                {
                    return Ok(new ResModel<bool> { Success = true, Message = "Address updated successfully!", Data = response });
                }
                return BadRequest(new ResModel<bool> { Success = false, Message = "Address updation Unsuccessful", Data = false });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<bool> { Success = false, Message = ex.Message, Data = false });
            }
        }

        [HttpGet]
        [Authorize]
        [Route("GetAllAddres")]
        public async Task<IActionResult> GetAllAddress(AddAddressModel model)
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
                var response = await addressManager.GetAllAddress(userId);
                if (response != null)
                {
                    return Ok(new ResModel<List<AddressEntity>> { Success = true, Message = "Display items present in addresslist Successfully!", Data = response });
                }
                return BadRequest(new ResModel<List<AddressEntity>> { Success = false, Message = "Something went wrong", Data = null });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<List<AddressEntity>> { Success = false, Message = ex.Message, Data = null });
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("DeleteAddres")]
        public async Task<IActionResult> DeleteAddress(int AddressId)
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
                var response = await addressManager.RemoveAddress(userId, AddressId);
                if (response != null)
                {
                    return Ok(new ResModel<AddressEntity> { Success = true, Message = "Address removed Successfully!", Data = response });
                }
                return BadRequest(new ResModel<AddressEntity> { Success = false, Message = "Something went wrong", Data = null });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<AddressEntity> { Success = false, Message = ex.Message, Data = null });
            }
        }
    }
}

