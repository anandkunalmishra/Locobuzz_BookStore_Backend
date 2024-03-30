using System;
using Repository_Layer.Enitty;

namespace Repository_Layer.Interfaces
{
	public interface IWishlistRepository
	{
        Task<WishlistEntity> AddToWishList(int userId, int bookId);
        Task<WishlistEntity> RemoveBookFromWishlist(int userId, int wishlistId);
        Task<List<WishlistEntity>> GetAllBookFromWishlist(int userId);
    }
}

