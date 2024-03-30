using System;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Repository_Layer.Context;
using Repository_Layer.Enitty;
using Repository_Layer.Interfaces;

namespace Repository_Layer.Services
{
	public class CartRepository:ICartRepository
	{
		private readonly BookStoreContext context;
		public CartRepository(BookStoreContext context)
		{
			this.context = context;
		}

		public async Task<CartEntity> AddToCart(int UserId,int BookId)
		{
			var user = await context.UserTable.FirstOrDefaultAsync(x => x.UserId == UserId);
			if (user == null)
			{
				throw new Exception($"User with userId {UserId} does not exist");
			}
			var book = await context.BookTable.FirstOrDefaultAsync(x => x.Book_Id == BookId);
			if (book == null)
			{
				throw new Exception($"Book with book id {BookId} does not exist");
			}

			var bookInCart = await context.CartTable.FirstOrDefaultAsync(x => x.Book_Id == BookId);
			if(bookInCart != null)
			{
				bookInCart.Quantity++;
				await context.SaveChangesAsync();
				return bookInCart;
			}

			CartEntity entity = new CartEntity();
			entity.UserId = UserId;
			entity.Book_Id = BookId;
			entity.AddedFor = book;
			entity.AddedBy = user;
			entity.Quantity = 1;
			entity.isPurchaged = false;
			entity.OrderAt = null;

			context.CartTable.Add(entity);
			await context.SaveChangesAsync();
			return entity;
		}

		public async Task<bool> RemoveBook(int UserId,int BookId)
		{
            var user = await context.UserTable.FirstOrDefaultAsync(x => x.UserId == UserId);
            if (user == null)
            {
                throw new Exception($"User with userId {UserId} does not exist");
            }
            var book = await context.BookTable.FirstOrDefaultAsync(x => x.Book_Id == BookId);
            if (book == null)
            {
                throw new Exception($"Book with book id {BookId} does not exist");
            }

            var bookInCart = await context.CartTable.FirstOrDefaultAsync(x => x.Book_Id == BookId);
			if (bookInCart == null)
			{
				throw new Exception("Book is not there in the cart");
			}

            context.CartTable.Remove(bookInCart);
            await context.SaveChangesAsync();
            return true;
        }

		public async Task<bool> Increase_Decrease(int UserId,int BookId,bool increase)
		{
            var user = await context.UserTable.FirstOrDefaultAsync(x => x.UserId == UserId);
            if (user == null)
            {
                throw new Exception($"User with userId {UserId} does not exist");
            }
            var book = await context.BookTable.FirstOrDefaultAsync(x => x.Book_Id == BookId);
            if (book == null)
            {
                throw new Exception($"Book with book id {BookId} does not exist");
            }

            var bookInCart = await context.CartTable.FirstOrDefaultAsync(x => x.Book_Id == BookId);
            if (bookInCart == null)
            {
                throw new Exception("Book is not there in the cart");
            }

			if (increase)
			{
				bookInCart.Quantity++;
			}
			else
			{
				if (bookInCart.Quantity == 1)
				{
					throw new Exception("Use the remove option now as quantity is 1");
				}
				bookInCart.Quantity--;
			}
            await context.SaveChangesAsync();
            return true;
        }

		public async Task<List<CartEntity>> GetAllItems(int UserId)
		{
            var user = await context.UserTable.FirstOrDefaultAsync(x => x.UserId == UserId);
            if (user == null)
            {
                throw new Exception($"User with userId {UserId} does not exist");
            }
			var list = await context.CartTable.Where(x => x.UserId == UserId && x.isPurchaged==false).ToListAsync();

			return list;
        }

		public async Task<int> GetSubTotal(int UserId)
		{
			var list = await GetAllItems(UserId);
			int sum = 0;

            foreach (var items in list)
			{
				sum += items.Quantity * items.AddedFor.Book_price;
			}
			return sum;
		}

		public async Task<bool> PurchaseItems(int UserId,bool paymentdone)
		{
			if (!paymentdone)
			{
				throw new Exception("Something went wrong!");
			}
			var list = await GetAllItems(UserId);
			foreach(var items in list)
			{
				items.isPurchaged = true;
			}
			return true;
		}
    }
}

