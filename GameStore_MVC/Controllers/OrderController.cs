using GameStore_MVC.Data;
using GameStore_MVC.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameStore_MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

		public OrderController(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
        {
			var applicationDbContext = _context.Orders.Include(t => t.Customer).Include(t => t.Game);
			return View(await applicationDbContext.ToListAsync());
		}

		// GET: Order/Details
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var order = await _context.Orders
				.Include(t => t.Customer)
				.Include(t => t.Game)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (order == null)
			{
				return NotFound();
			}

			return View(order);
		}

		// GET: Order/Create
		public IActionResult Create()
		{
			ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id");
			ViewData["GameId"] = new SelectList(_context.Games, "Id", "Id");
			return View();
		}

		// POST: Order/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,GameId,CustomerId,Quantity,DateOfOrder")] Order order)
		{
			if (ModelState.IsValid)
			{
				_context.Add(order);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", order.CustomerId);
			ViewData["GameId"] = new SelectList(_context.Games, "Id", "Id", order.GameId);
			return View(order);
		}

		// GET: Order/Edit
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Orders == null)
			{
				return NotFound();
			}

			var order = await _context.Orders.FindAsync(id);
			if (order == null)
			{
				return NotFound();
			}
			ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", order.CustomerId);
			ViewData["GameId"] = new SelectList(_context.Games, "Id", "Id", order.GameId);
			return View(order);
		}

		// POST: Order/Edit/
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,GameId,CustomerId,Quantity,DateOfOrder")] Order order)
		{
			if (id != order.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(order);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!TransactionExists(order.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", order.CustomerId);
			ViewData["GameId"] = new SelectList(_context.Games, "Id", "Id", order.GameId);
			return View(order);
		}

		// GET: Order/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Orders == null)
			{
				return NotFound();
			}

			var order = await _context.Orders
				.Include(t => t.Customer)
				.Include(t => t.Game)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (order == null)
			{
				return NotFound();
			}

			return View(order);
		}

		// POST: Order/Delete
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Orders == null)
			{
				return Problem("Entity set 'ApplicationDbContext.Orders'  is null.");
			}
			var order = await _context.Orders.FindAsync(id);
			if (order != null)
			{
				_context.Orders.Remove(order);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool TransactionExists(int id)
		{
			return (_context.Orders?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
