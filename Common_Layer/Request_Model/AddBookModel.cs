using System;
namespace Common_Layer.Request_Model
{
	public class AddBookModel
	{
        public string Book_Name { get; set; }
        public string Book_description { get; set; }
        public string Book_author { get; set; }
        public string Book_image { get; set; }
        public int Book_price { get; set; }
        public int Book_discountprice { get; set; }
        public int Book_quantity { get; set; }
    }
}

