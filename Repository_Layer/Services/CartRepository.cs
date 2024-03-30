using System;
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
			}

			CartEntity entity = new CartEntity();
			entity.UserId = UserId;
			entity.Book_Id = BookId;
			entity.AddedFor = book;
			entity.AddedBy = user;

			await context.CartTable.AddAsync(entity);
			await context.SaveChangesAsync();
			return entity;
		}

	}
}

