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
    }
}

