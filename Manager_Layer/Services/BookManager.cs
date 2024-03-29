using System;
using Common_Layer.Request_Model;
using Manager_Layer.Interfaces;
using Repository_Layer.Enitty;
using Repository_Layer.Interfaces;

namespace Manager_Layer.Services
{
	public class BookManager:IBookManager
	{
		private readonly IBookRepository book;
		public BookManager(IBookRepository book)
		{
			this.book = book;
		}
        public async Task<BookEntity> AddBook(int UserId, AddBookModel model)
		{
			return await book.AddBook(UserId, model);
		}
        public async Task<bool> UpdateBook(int UserId, int BookId, UpdateBookModel model)
		{
			return await book.UpdateBook(UserId, BookId, model);
		}

        public async Task<bool> UpdatePrice(int UserId, int BookId, int Price)
		{
			return await book.UpdatePrice(UserId, BookId, Price);
		}
        public async Task<bool> UpdatediscountPrice(int UserId, int BookId, int DiscountPrice)
		{
			return await book.UpdatediscountPrice(UserId, BookId, DiscountPrice);
		}
        public async Task<bool> UpdateImage(int UserId, int BookId, string imagepath)
		{
			return await book.UpdateImage(UserId, BookId, imagepath);
		}
        public async Task<bool> UpdateQuantity(int UserId, int BookId, int Quantity)
		{
			return await book.UpdateQuantity(UserId, BookId, Quantity);
		}
        public async Task<bool> DeleteBook(int UserId, int BookId)
		{
			return await book.DeleteBook(UserId, BookId);
		}
        public async Task<List<BookEntity>> GetAllBook(int UserId)
		{
			return await book.GetAllBook(UserId);
		}
		public async Task<List<BookEntity>> GetAllBook()
		{
			return await book.GetAllBook();
		}
    }
}

