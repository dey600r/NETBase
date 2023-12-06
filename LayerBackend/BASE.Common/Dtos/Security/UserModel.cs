namespace BASE.Common.Dtos.Security
{
	public class UserModel
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Country { get; set; }
		public string Token { get; set; }

		public List<string> Role { get; set; }
	}
}
