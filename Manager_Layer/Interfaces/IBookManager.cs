﻿using System;
using Common_Layer.Request_Model;
using Repository_Layer.Enitty;

namespace Manager_Layer.Interfaces
{
	public interface IBookManager
	{
        Task<BookEntity> AddBook(int UserId, AddBookModel model);
        Task<bool> UpdateBook(int UserId, int BookId, UpdateBookModel model);
        Task<bool> UpdatePrice(int UserId, int BookId, int Price);
        Task<bool> UpdatediscountPrice(int UserId, int BookId, int DiscountPrice);
        Task<bool> UpdateImage(int UserId, int BookId, string imagepath);
        Task<bool> UpdateQuantity(int UserId, int BookId, int Quantity);
    }
}

