using System;
using Repository_Layer.Enitty;

namespace Manager_Layer.Interfaces
{
	public interface ICartManager
	{
        Task<CartEntity> AddToCart(int UserId, int BookId);

    }
}

