using GameStore_MVC.Models.GameStoreViewModels.GameVM;
using GameStore_MVC.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameStore_MVC.Controllers
{
	public class GameController : Controller
	{
		private IGameService _service;
		private IGameDevService _devService;

		public GameController(IGameService service, IGameDevService devService)
		{
			_service = service;
			_devService = devService;
		}

		// GET: Game
		public async Task<IActionResult> Index()
		{
			return View(await _service.GetGames());
		}

		// GET: Game/Create
		[HttpGet]
		[Route("Create")]
		public async Task<IActionResult> Create()
		{
			var gameDevVM = new GameCreate
			{
				GameOptions = _devService.GetGameDevs().Result.ToList().Select(g => new SelectListItem
				{
					Text = g.Developer,
					Value = g.Id.ToString(),
				})
			};

			return View(gameDevVM);
		}

		// POST: Game/Create
		[HttpPost]
		[Route("Create")]
		public async Task<IActionResult> Create(GameCreate model)
		{
			if (ModelState.IsValid)
			{
				if (await _service.AddGame(model))
				{
					return RedirectToAction(nameof(Index));
				}
			}

			var GameOptions = _devService.GetGameDevs().Result.ToList().Select(g => new SelectListItem
			{
				Text = g.Developer,
				Value = g.Id.ToString(),
			});
			model.GameOptions = GameOptions;


			return View();
		}

		// GET: Game/Details
		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			return View(await _service.GetGame(id));
		}

		// GET: Game/Edit
		[HttpGet]
		[Route("Edit/{id}")]
		public async Task<IActionResult> Edit(int id)
		{
			var game = await _service.GetGame(id);
			var gameEdit = new GameEdit
			{
				Id = game.Id,
				Title = game.Title,
				Description = game.Description,
				Price = game.Price,
				QuantityInStock = game.QuantityInStock,
				ImageURL = game.ImageURL,
				AgeRating = game.AgeRating,
				Platform = game.Platform
			};

			var gameVM = new GameEdit
			{
				GameOptions = _devService.GetGameDevs().Result.ToList().Select(g => new SelectListItem
				{
					Text = g.Developer,
					Value = g.Id.ToString(),
				})
			};
			gameEdit.GameOptions = gameVM.GameOptions;



			return View(gameEdit);
		}

		// POST: Game/Edit
		[HttpPost]
		[Route("Edit/{id}")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, GameEdit model)
		{
			if (id != model.Id) return BadRequest("Invalid Id");
			if (!ModelState.IsValid) return BadRequest(ModelState);
			if (await _service.UpdateGame(id, model))
				return RedirectToAction(nameof(Index));
			else
			{
				var GameOptions = _devService.GetGameDevs().Result.ToList().Select(g => new SelectListItem
				{
					Text = g.Developer,
					Value = g.Id.ToString(),
				});
				model.GameOptions = GameOptions;
			}
			return View(model);
		}


		// GET: Game/Delete
		[HttpGet]
		[Route("Delete/{id}")]
		public async Task<IActionResult> Delete(int? id)
		{
			var game = await _service.GetGame(id.Value);
			return View(game);
		}

		// POST: Game/Delete
		[HttpPost]
		[Route("Delete/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var isSuccessful = await _service.DeleteGame(id);
			if (isSuccessful)
				return RedirectToAction(nameof(Index));
			else
				return UnprocessableEntity();
		}
	}
}
