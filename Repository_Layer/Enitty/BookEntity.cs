using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Repository_Layer.Enitty
{
	public class BookEntity
	{
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Book_Id { get; set; }
		public string Book_Name { get; set; }
		public string Book_description { get; set; }
		public string Book_author { get; set; }
		public string Book_image { get; set; }
		public int Book_price { get; set; }
		public int Book_discountprice { get; set; }
		public int Book_quantity { get; set; }
		public DateTime CreatedAt { get; set; }
		public  DateTime UpdatedAt { get; set; }

		[ForeignKey("AddedBy")]
		public int UserId { get; set; }

		[JsonIgnore]
		public virtual UserEntity AddedBy { get; set; }
    }
}

