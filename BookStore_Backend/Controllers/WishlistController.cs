﻿using System;
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
        [Authorize]
        [HttpDelete]
        [Route("RemoveBookFromWishlist")]
        public async Task<IActionResult> RemoveBookFromWishlist(int wishlistId)
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
                var response = await wishlistManager.RemoveBookFromWishlist(userId, wishlistId);
                if (response != null)
                {
                    return Ok(new ResModel<WishlistEntity> { Success = true, Message = "Book removed from Wishlist!", Data = response });
                }
                return BadRequest(new ResModel<WishlistEntity> { Success = false, Message = "Something went wrong", Data = null });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<bool> { Success = false, Message = ex.Message, Data = false });
            }
        }
        [Authorize]
        [HttpGet]
        [Route("GetAllBookWishlist")]
        public async Task<IActionResult> GetAllBookFromWishlist()
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
                var response = await wishlistManager.GetAllBookFromWishlist(userId);
                if (response != null)
                {
                    return Ok(new ResModel<List<WishlistEntity>> { Success = true, Message = "Display items present in wishlist Successfully!", Data = response });
                }
                return BadRequest(new ResModel<List<WishlistEntity>> { Success = false, Message = "Something went wrong", Data = null });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<bool> { Success = false, Message = ex.Message, Data = false });
            }
        }
    }
}

