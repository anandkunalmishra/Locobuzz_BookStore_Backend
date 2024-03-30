using System;
using Repository_Layer.Enitty;

namespace Repository_Layer.Interfaces
{
	public interface ICartRepository
	{
        Task<CartEntity> AddToCart(int UserId, int BookId);

    }
}

