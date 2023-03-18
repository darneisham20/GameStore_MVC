using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore_MVC.Data.Entities
{
	public partial class Order
	{
		[Key]
		public int Id { get; set; }

        [DisplayName("Game Id")]
        public int GameId { get; set; }

        [DisplayName("Customer Id")]
        public int CustomerId { get; set; }
		public int Quantity { get; set; }

        [DisplayName("Date of Order")]
        public DateTime DateOfOrder { get; set; }
		public virtual Customer Customer { get; set; } = null!;
		public virtual Game Game { get; set; } = null!;

	}
}
