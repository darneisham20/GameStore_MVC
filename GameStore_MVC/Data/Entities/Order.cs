using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore_MVC.Data.Entities
{
	public class Order
	{
		[Key]
		public int Id { get; set; }
		public DateTime CreateDate { get; set; } = DateTime.UtcNow;

		public int? GameId { get; set; }
		[ForeignKey(nameof(GameId))]
		public Game? Games { get; set; }
	}
}
