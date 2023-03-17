using Microsoft.AspNetCore.Identity;

namespace GameStore_MVC.Data.Entities
{
	public class AppUser : IdentityUser
	{
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string? Address { get; set; }
		public DateTime SignUp { get; set; }
		public List<Order> Orders { get; set; }
	}
}
