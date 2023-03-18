using GameStore_MVC.Data;
using GameStore_MVC.Data.Entities;
using GameStore_MVC.Models.GameStoreViewModels.CustomerVM;
using Microsoft.AspNetCore.Mvc;

namespace GameStore_MVC.Controllers
{
	public class CustomerController : Controller
	{
		private readonly ApplicationDbContext _context;

		public CustomerController(ApplicationDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var customers = _context.Customers.Select(customer => new CustomerIndex
			{
				Id = customer.Id,
				Name = customer.Name,
				Email = customer.Email,
			});
			return View(customers);
		}

		// GET: Customer/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Customer/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(CustomerCreate model)
		{
			if (!ModelState.IsValid)
			{
				TempData["ErrorMsg"] = "Model State is invalid";
				return View(model);
			}
			_context.Customers.Add(new Customer
			{
				Name = model.Name,
				Email = model.Email
			});
			if (_context.SaveChanges() == 1)
			{
				return Redirect("/Customer");
			}
			TempData["ErrorMsg"] = "Unable to save to the database.Please try again later.";
			return View(model);
		}
		// GET: Customer/Details
		public IActionResult Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var customer = _context.Customers.Find(id);
			if (customer == null)
			{
				return NotFound();
			}
			var model = new CustomerDetail
			{
				Id = customer.Id,
				Name = customer.Name,
				Email = customer.Email
			};
			return View(model);
		}

		// GET: Customer/Edit
		[HttpGet]
		public IActionResult Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var customer = _context.Customers.Find(id);
			if (customer == null)
			{
				return NotFound();
			}
			var model = new CustomerEdit
			{
				Id = customer.Id,
				Name = customer.Name,
				Email = customer.Email
			};
			return View(model);
		}

		// POST: Customer/Edit
		[HttpPost]
		public IActionResult Edit(int id, CustomerEdit model)
		{
			var customer = _context.Customers.Find(id);
			if (customer == null)
			{
				return NotFound();
			}
			customer.Name = model.Name;
			customer.Email = model.Email;

			if (_context.SaveChanges() == 1)
			{
				return Redirect("/customer");
			}

			ViewData["ErrorMsg"] = "Unable to save to the database. Please try again.";
			return View(model);
		}

		// GET: Customer/Delete
		[HttpGet]
		public IActionResult Delete(int id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var customer = _context.Customers.Find(id);
			if (customer == null)
			{
				return NotFound();
			}
			var model = new CustomerDetail
			{
				Id = customer.Id,
				Name = customer.Name,
				Email = customer.Email
			};
			return View(model);
		}

		// POST: Customer/Delete
		[HttpPost]
		public IActionResult Delete(int? id, CustomerDetail model)
		{
			var customer = _context.Customers.Find(id);
			if (customer == null)
			{
				return NotFound();
			}
			_context.Customers.Remove(customer);
			_context.SaveChanges();
			return Redirect("/Customer");
		}
	}
}
