using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common_Layer.Response_Model;
using Manager_Layer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository_Layer.Enitty;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore_Backend.Controllers
{
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartManager manager;
        public CartController(ICartManager manager)
        {
            this.manager = manager;
        }

        [Authorize]
        [HttpPost]
        [Route("AddToCart")]
        public async Task<IActionResult> AddToCart(int BookId)
        {
            try
            {
                var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
                var response = await manager.AddToCart(userId, BookId);
                if (response == null)
                {
                    return BadRequest(new ResModel<CartEntity> { Success = false, Message = "Not able to add", Data = null });
                }
                return Ok(new ResModel<CartEntity> { Success = true, Message = "successfully added to the cart", Data = response });
            }
            catch(Exception ex)
            {
                return BadRequest(new ResModel<CartEntity> { Success = false, Message = ex.Message,Data=null });
            }
        }
        [Authorize]
        [HttpDelete]
        [Route("remove")]
        public async Task<IActionResult> RemoveFromCart(int BookId)
        {
            try
            {
                var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
                var response = await manager.RemoveBook(userId, BookId);
                if (response==false)
                {
                    return BadRequest(new ResModel<bool> { Success = false, Message = "Not able to remove", Data = false });
                }
                return Ok(new ResModel<bool> { Success = true, Message = "successfully removed to the cart", Data = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<bool> { Success = false, Message = ex.Message, Data = false });
            }
        }

        [Authorize]
        [HttpPut]
        [Route("changeQuantity")]
        public async Task<IActionResult> ChangeQuantiy(int BookId,bool increase)
        {
            try
            {
                var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
                var response = await manager.Increase_Decrease(userId, BookId,increase);
                if (response == false)
                {
                    return BadRequest(new ResModel<bool> { Success = false, Message = "Not able to change quantity", Data = false });
                }
                return Ok(new ResModel<bool> { Success = true, Message = "successfully changed quantity to the cart", Data = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<bool> { Success = false, Message = ex.Message, Data = false });
            }
        }

        [Authorize]
        [HttpGet]
        [Route("getAllItems")]
        public async Task<IActionResult> GetAllItems()
        {
            try
            {
                var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
                var response = await manager.GetAllItems(userId);
                if (response==null)
                {
                    return BadRequest(new ResModel<List<CartEntity>> { Success = false, Message = "Not able to display the items of cart", Data = null });
                }
                return Ok(new ResModel<List<CartEntity>> { Success = true, Message = "successfully displayed list of items of cart", Data = response });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<List<CartEntity>> { Success = false, Message = ex.Message, Data = null });
            }
        }

        [Authorize]
        [HttpGet]
        [Route("getSubtotal")]
        public async Task<IActionResult> GetSubtotalPrice()
        {
            try
            {
                var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
                var response = await manager.GetSubTotal(userId);
                return Ok(new ResModel<int> { Success = true, Message = "successfully displayed subtoatal price of items of cart", Data = response });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<int> { Success = false, Message = ex.Message, Data = 0 });
            }
        }

        [Authorize]
        [HttpPut]
        [Route("purchase")]
        public async Task<IActionResult> PurchaseItems(bool paymentdone)
        {
            try
            {
                var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
                var response = await manager.PurchaseItems(userId,paymentdone);
                return Ok(new ResModel<bool> { Success = true, Message = "Order placed successfully", Data = response });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<bool> { Success = false, Message = ex.Message, Data = false });
            }
        }
    }
}

