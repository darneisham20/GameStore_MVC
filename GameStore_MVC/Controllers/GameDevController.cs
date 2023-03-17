using GameStore_MVC.Models.GameStoreViewModels.GameDevVM;
using GameStore_MVC.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GameStore_MVC.Controllers
{
	public class GameDevController : Controller
	{
		private IGameDevService _service;
		private IGameService _gameService;

		public GameDevController(IGameDevService service, IGameService gameService)
		{
			_service = service;
			_gameService = gameService;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			return View(await _service.GetGameDevs());
		}

		// GET: GameDev/Create
		[HttpGet]
		public async Task<IActionResult> Create()
		{
			var gameDevVM = new GameDevCreate();

			return View(gameDevVM);
		}

		// POST: GameDev/Create
		[HttpPost]
		[ActionName("Create")]
		public async Task<IActionResult> CreateGameDev(GameDevCreate model)
		{
			if (ModelState.IsValid)
			{
				if (await _service.AddGameDev(model))
				{
					return RedirectToAction(nameof(Index));
				}
			}

			return View(model);
		}

		// GET: GameDev/Details
		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			return View(await _service.GetGameDev(id));
		}

		// GET: GameDev/Edit
		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var gameDev = await _service.GetGameDev(id);
			var gameDevEdit = new GameDevEdit
			{
				Id = gameDev.Id,
				Developer = gameDev.Developer,
				City = gameDev.City,
				Country = gameDev.Country,
				Est = gameDev.Est,

			};

			return View(gameDevEdit);
		}

		// POST: GameDev/Edit
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, GameDevEdit model)
		{
			if (id != model.Id) return BadRequest("Invalid Id");
			if (!ModelState.IsValid) return BadRequest(ModelState);
			if (await _service.UpdateGameDev(id, model))
				return RedirectToAction(nameof(Index));
			else
			{
				return View(model);
			}
		}

		// GET: GameDev/Delete
		[HttpGet]
		public async Task<IActionResult> Delete(int? id)
		{
			var gameDev = await _service.GetGameDev(id.Value);
			return View(gameDev);
		}

		// POST: GameDev/Delete
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(int id)
		{
			var isSuccessful = await _service.DeleteGameDev(id);
			if (isSuccessful)
				return RedirectToAction(nameof(Index));
			else
				return UnprocessableEntity();
		}
	}
}
