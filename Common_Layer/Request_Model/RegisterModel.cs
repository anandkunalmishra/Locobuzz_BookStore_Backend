using System;
namespace Common_Layer.Request_Model
{
	public class RegisterModel
	{
        public string FullName { get; set; }
        public string Email_Id { get; set; }
        public string Password { get; set; }
        public long Mobile_Number { get; set; }
        public string UserRole { get; set; }
    }
}

