using System;
using Microsoft.EntityFrameworkCore;
using Repository_Layer.Enitty;

namespace Repository_Layer.Context
{
	public class BookStoreContext:DbContext
	{
		public BookStoreContext(DbContextOptions options) : base(options) { }

		public DbSet<UserEntity> UserTable { get; set; }
        public DbSet<BookEntity> BookTable { get; set; }
        public DbSet<CartEntity> CartTable { get; set; }
        public DbSet<WishlistEntity> WishlistTable { get; set; }


    }
}

