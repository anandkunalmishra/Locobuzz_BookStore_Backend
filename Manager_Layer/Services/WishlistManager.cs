using System;
using Manager_Layer.Interfaces;
using Repository_Layer.Enitty;
using Repository_Layer.Interfaces;

namespace Manager_Layer.Services
{
	public class WishlistManager:IWishlistManager
	{
		private readonly IWishlistRepository wishlist;
		public WishlistManager(IWishlistRepository wishlist)
		{
			this.wishlist = wishlist;
		}
        public async Task<WishlistEntity> AddToWishList(int userId, int bookId)
		{
			return await wishlist.AddToWishList(userId, bookId);
		}
		public async Task<WishlistEntity> RemoveBookFromWishlist(int userId, int wishlistId)
		{
			return await wishlist.RemoveBookFromWishlist(userId, wishlistId);
		}
    }
}

