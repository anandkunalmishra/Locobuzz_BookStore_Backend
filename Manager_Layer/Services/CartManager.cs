﻿using System;
using Manager_Layer.Interfaces;
using Repository_Layer.Enitty;
using Repository_Layer.Interfaces;

namespace Manager_Layer.Services
{
	public class CartManager : ICartManager
	{
		private readonly ICartRepository cart;
		public CartManager(ICartRepository cart)
		{
			this.cart = cart;
		}
		public async Task<CartEntity> AddToCart(int UserId, int BookId)
		{
			return await cart.AddToCart(UserId, BookId);
		}
		public async Task<bool> RemoveBook(int UserId, int BookId)
		{
			return await cart.RemoveBook(UserId, BookId);
		}
		public async Task<bool> Increase_Decrease(int UserId, int BookId, bool increase)
		{
			return await cart.Increase_Decrease(UserId, BookId, increase);
		}
		public async Task<List<CartEntity>> GetAllItems(int UserId)
		{
			return await cart.GetAllItems(UserId);
		}
        public async Task<bool> PurchaseItems(int UserId, bool paymentdone)
		{
			return await cart.PurchaseItems(UserId, paymentdone);
		}
        public async Task<int> GetSubTotal(int UserId)
		{
			return await cart.GetSubTotal(UserId);
		}
    }
}

