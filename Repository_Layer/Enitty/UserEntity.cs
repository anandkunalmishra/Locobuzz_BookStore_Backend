using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository_Layer.Enitty
{
	public class UserEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int UserId { get; set; }
		public string FullName { get; set; }
		public string Email_Id { get; set; }
		public string Password { get; set; }
		public long Mobile_Number { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }

		//User Role
		public string UserRole { get; set; }

	}
}

