using System;
using Common_Layer.Request_Model;
using Repository_Layer.Enitty;

namespace Manager_Layer.Interfaces
{
	public interface IBookManager
	{
        Task<BookEntity> AddBook(int UserId, AddBookModel model);
    }
}

