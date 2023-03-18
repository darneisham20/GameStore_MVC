using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GameStore_MVC.Data.Entities
{
	public partial class Customer
	{
		public Customer()
		{
			Orders = new HashSet<Order>();
		}
		[Key]
		public int Id { get; set; }

		[DisplayName("Full Name")]
		public string Name { get; set; } = null!;
		public string Email { get; set; } = null!;
		public virtual ICollection<Order> Orders { get; set; }
	}
}
