using GameStore_MVC.Data;
using GameStore_MVC.Models.GameStoreViewModels.CustomerVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GameStore_MVC.Views.Customer
{
    public class DetailsModel : PageModel
    {
        private readonly GameStore_MVC.Data.ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public CustomerDetail CustomerDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CustomerDetail == null)
            {
                return NotFound();
            }

            var customerDetail = await _context.CustomerDetail.FirstOrDefaultAsync(m => m.Id == id);
            if (customerDetail == null)
            {
                return NotFound();
            }
            else
            {
                CustomerDetail = customerDetail;
            }
            return Page();
        }
    }
}
