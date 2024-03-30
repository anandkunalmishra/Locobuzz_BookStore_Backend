using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Repository_Layer.Enitty
{
	public class CartEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CartId { get; set; }

		[ForeignKey("AddedBy")]
		public int UserId { get; set; }

        [JsonIgnore]
        public virtual UserEntity AddedBy { get; set; }

        [ForeignKey("AddedFor")]
		public int Book_Id { get; set; }

		[JsonIgnore]
		public virtual BookEntity AddedFor { get; set; }

		public int Quantity { get; set; }

		public bool isPurchaged { get; set; }

		public DateTime? OrderAt { get; set; }
	}
}

