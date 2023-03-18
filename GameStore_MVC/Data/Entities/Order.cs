using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore_MVC.Data.Entities
{
	public partial class Order
	{
		[Key]
		public int Id { get; set; }
		public int GameId { get; set; }
		public int CustomerId { get; set; }
		public int Quantity { get; set; }
		public DateTime DateOfOrder { get; set; }
		public virtual Customer Customer { get; set; } = null!;
		public virtual Game Game { get; set; } = null!;

	}
}
