using System;
using Repository_Layer.Enitty;

namespace Manager_Layer.Interfaces
{
	public interface IWishlistManager
	{
        Task<WishlistEntity> AddToWishList(int userId, int bookId);
        Task<WishlistEntity> RemoveBookFromWishlist(int userId, int wishlistId);
    }
}

