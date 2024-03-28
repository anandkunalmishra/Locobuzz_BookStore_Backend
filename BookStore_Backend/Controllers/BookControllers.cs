using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common_Layer.Request_Model;
using Common_Layer.Response_Model;
using Manager_Layer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository_Layer.Enitty;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookControllers : ControllerBase
    {
        private IBookManager manager;
        public BookControllers(IBookManager manager)
        {
            this.manager = manager;
        }

        [HttpPost]
        [Authorize]
        [Route("addbook")]
        public async Task<IActionResult> AddBook(AddBookModel model)
        {
            try
            {
                var userId = Convert.ToInt32(User.FindFirst("UserId").Value);
                var response = await manager.AddBook(userId, model);
                if (response != null)
                {
                    return Ok(new ResModel<BookEntity> { Success = true, Message = "Book Added successfully", Data = response });
                }
                else
                {
                    return BadRequest(new ResModel<BookEntity> { Success = false, Message = "Book Addition unsuccessful", Data = null });
                }
            }
            catch(Exception ex)
            {
                return BadRequest(new ResModel<BookEntity> { Success = false, Message = ex.Message,Data=null});
            }
        }

        [HttpPut]
        [Authorize]
        [Route("updatebookdetails")]
        public async Task<IActionResult> UpdateBook(int BookId,UpdateBookModel model)
        {
            try
            {
                var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
                var response = await manager.UpdateBook(userId, BookId,model);
                if (response)
                {
                    return Ok(new ResModel<bool> { Success = true, Message = "Book Updated successfully", Data = true });
                }
                else
                {
                    return BadRequest(new ResModel<bool> { Success = false, Message = "Book Updation unsuccessful", Data = false });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<bool> { Success = false, Message = ex.Message, Data = false });
            }
        }

        [HttpPut]
        [Authorize]
        [Route("updatebookprice")]
        public async Task<IActionResult> UpdateBookPrice(int BookId, int Price)
        {
            try
            {
                var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
                var response = await manager.UpdatePrice(userId, BookId, Price);
                if (response)
                {
                    return Ok(new ResModel<bool> { Success = true, Message = "Book Price Updated successfully", Data = true });
                }
                else
                {
                    return BadRequest(new ResModel<bool> { Success = false, Message = "Book Price Updation unsuccessful", Data = false });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<bool> { Success = false, Message = ex.Message, Data = false });
            }
        }

        [HttpPut]
        [Authorize]
        [Route("updatediscountprice")]
        public async Task<IActionResult> UpdateDiscountBookPrice(int BookId, int DiscountPrice)
        {
            try
            {
                var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
                var response = await manager.UpdatediscountPrice(userId, BookId, DiscountPrice);
                if (response)
                {
                    return Ok(new ResModel<bool> { Success = true, Message = "Book Discount Price Updated successfully", Data = true });
                }
                else
                {
                    return BadRequest(new ResModel<bool> { Success = false, Message = "Book Discount Price Updation unsuccessful", Data = false });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<bool> { Success = false, Message = ex.Message, Data = false });
            }
        }
    }
}

