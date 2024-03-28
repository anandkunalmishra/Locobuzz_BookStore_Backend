using System;
using Common_Layer.Request_Model;
using Microsoft.EntityFrameworkCore;
using Repository_Layer.Context;
using Repository_Layer.Enitty;
using Repository_Layer.Interfaces;

namespace Repository_Layer.Services
{
	public class BookRepository:IBookRepository
	{
		private readonly BookStoreContext context;
		public BookRepository(BookStoreContext context)
		{
			this.context = context;
		}
		public async Task<BookEntity> AddBook(int UserId,AddBookModel model)
		{
			var user = await context.UserTable.FirstOrDefaultAsync(x=>x.UserId==UserId);
			if (user != null)
			{
                if (user.UserRole == "Admin")
                {
					BookEntity book = new BookEntity();
					book.AddedBy = user;
					book.UserId = user.UserId;
					book.Book_author = model.Book_author;
					book.Book_description = model.Book_description;
					book.Book_image = model.Book_image;
					book.Book_Name = model.Book_Name;
					book.Book_price = model.Book_price;
					book.Book_quantity = model.Book_quantity;
					book.Book_discountprice = model.Book_discountprice;

					context.BookTable.Add(book);
					await context.SaveChangesAsync();
					return book;
                }
				throw new Exception("User is not an Admin");
            }
			throw new Exception("User doesn't exist");
			
			
		}
        public async Task<bool> UpdateBook(int UserId, int BookId,UpdateBookModel model)
        {
            var user = await context.UserTable.FirstOrDefaultAsync(x => x.UserId == UserId);
            if (user != null)
            {
                if (user.UserRole == "Admin")
                {
                    var book = await context.BookTable.FirstOrDefaultAsync(x => x.Book_Id == BookId);
					if (book!=null)
					{
                    
						book.Book_author = model.Book_author;
						book.Book_description = model.Book_description;
						book.Book_Name = model.Book_Name;
						context.BookTable.Update(book);
						await context.SaveChangesAsync();
						return true;
					}
					throw new Exception($"Book with Book id {BookId} doesn't exist");
                }
                throw new Exception("User is not an Admin");
            }
            throw new Exception("User doesn't exist");
        }

		public async Task<bool> UpdatePrice(int UserId,int BookId,int Price)
		{
            var user = await context.UserTable.FirstOrDefaultAsync(x => x.UserId == UserId);
            if (user != null)
            {
                if (user.UserRole == "Admin")
                {
                    var book = await context.BookTable.FirstOrDefaultAsync(x => x.Book_Id == BookId);
                    if (book != null)
                    {
						book.Book_price = Price;
                        context.BookTable.Update(book);
                        await context.SaveChangesAsync();
                        return true;
                    }
                    throw new Exception($"Book with Book id {BookId} doesn't exist");
                }
                throw new Exception("User is not an Admin");
            }
            throw new Exception("User doesn't exist");
        }
    }
}

