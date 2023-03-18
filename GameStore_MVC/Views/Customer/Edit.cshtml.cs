using GameStore_MVC.Data;
using GameStore_MVC.Models.GameStoreViewModels.CustomerVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GameStore_MVC.Views.Customer
{
    public class EditModel : PageModel
    {
        private readonly GameStore_MVC.Data.ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CustomerEdit CustomerEdit { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CustomerEdit == null)
            {
                return NotFound();
            }

            var customerEdit = await _context.CustomerEdit.FirstOrDefaultAsync(m => m.Id == id);
            if (customerEdit == null)
            {
                return NotFound();
            }
            CustomerEdit = customerEdit;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CustomerEdit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerEditExists(CustomerEdit.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CustomerEditExists(int id)
        {
            return (_context.CustomerEdit?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
