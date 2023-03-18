using GameStore_MVC.Data;
using GameStore_MVC.Models.GameStoreViewModels.CustomerVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GameStore_MVC.Views.Customer
{
    public class DeleteModel : PageModel
    {
        private readonly GameStore_MVC.Data.ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.CustomerDetail == null)
            {
                return NotFound();
            }
            var customerDetail = await _context.CustomerDetail.FindAsync(id);

            if (customerDetail != null)
            {
                CustomerDetail = customerDetail;
                _context.CustomerDetail.Remove(CustomerDetail);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
