using System;
using Repository_Layer.Enitty;

namespace Manager_Layer.Interfaces
{
	public interface ICartManager
	{
        Task<CartEntity> AddToCart(int UserId, int BookId);
        Task<bool> RemoveBook(int UserId, int BookId);
        Task<bool> Increase_Decrease(int UserId, int BookId, bool increase);

    }
}

