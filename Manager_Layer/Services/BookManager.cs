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

    }
}

