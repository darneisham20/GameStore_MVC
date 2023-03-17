using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore_MVC.Data.Entities
{
	public class Order
	{
		[Key]
		public int Id { get; set; }
		public string AppUserId { get; set; }
		[ForeignKey(nameof(AppUserId))]

		public DateTime CreateDate { get; set; } = DateTime.UtcNow;
	}
}
