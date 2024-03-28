﻿using System;
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

                    if (model.Book_price < 0) throw new ArithmeticException("Book price cannot be less than 0");
					book.Book_price = model.Book_price;

                    if (model.Book_quantity < 0) throw new ArithmeticException("Book quantity cannot be less than 0");
                    book.Book_quantity = model.Book_quantity;

                    if (model.Book_discountprice < 0) throw new ArithmeticException("Book discount_price cannot be less than 0");
                    book.Book_discountprice = model.Book_discountprice;

                    book.CreatedAt = DateTime.Now;
                    book.UpdatedAt = DateTime.Now;
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
                        book.UpdatedAt = DateTime.Now;
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
                        if (Price < 0)
                        {
                            throw new ArithmeticException("Price can't be less than zero");
                        }
						book.Book_price = Price;
                        book.UpdatedAt = DateTime.Now;
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



        public async Task<bool> UpdatediscountPrice(int UserId, int BookId, int DiscountPrice)
        {
            //this is better way to write the code if should handle one case ... 
            var user = await context.UserTable.FirstOrDefaultAsync(x => x.UserId == UserId);
            if (user == null)
            {
                throw new Exception("User doesn't exist");
            }

            if (user.UserRole != "Admin")
            {
                throw new Exception("User is not an Admin");
            }

            var book = await context.BookTable.FirstOrDefaultAsync(x => x.Book_Id == BookId);
            if (book == null)
            {
                throw new Exception($"Book with Book id {BookId} doesn't exist");
            }

            if (DiscountPrice < 0)
            {
                throw new ArithmeticException("Book discount_price cannot be less than 0");
            }

            if (book.Book_price<DiscountPrice)
            {
                throw new Exception("The discount price is higher than the original");
            }

            book.Book_discountprice = DiscountPrice;
            book.UpdatedAt = DateTime.Now;
            context.BookTable.Update(book);
            await context.SaveChangesAsync();
            return true;
        }
    }
}

