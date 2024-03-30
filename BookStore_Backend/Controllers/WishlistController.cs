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
    public class WishlistController : ControllerBase
    {
        private readonly IWishlistManager wishlistManager;
        public WishlistController(IWishlistManager wishlistManager)
        {
            this.wishlistManager = wishlistManager;
        }
        [Authorize]
        [HttpPost]
        [Route("AddToWishList")]
        public async Task<IActionResult> AddtoWishList(int bookId)
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
                var response = await wishlistManager.AddToWishList(userId, bookId);
                if (response != null)
                {
                    return Ok(new ResModel<WishlistEntity> { Success = true, Message = "Book Added to Wishlist!", Data = response });
                }
                return BadRequest(new ResModel<WishlistEntity> { Success = false, Message = "Book not Added to Wishlist", Data = null });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<bool> { Success = false, Message = ex.Message, Data = false });
            }
        }
    }
}

