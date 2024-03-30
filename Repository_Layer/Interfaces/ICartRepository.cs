using System;
using Repository_Layer.Enitty;

namespace Repository_Layer.Interfaces
{
	public interface ICartRepository
	{
        Task<CartEntity> AddToCart(int UserId, int BookId);
        Task<bool> RemoveBook(int UserId, int BookId);
        Task<bool> Increase_Decrease(int UserId, int BookId, bool increase);
        Task<List<CartEntity>> GetAllItems(int UserId);
        Task<bool> PurchaseItems(int UserId, bool paymentdone);
        Task<int> GetSubTotal(int UserId);

    }
}

