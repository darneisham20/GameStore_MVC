using AutoMapper;
using GameStore_MVC.Data.Entities;
using GameStore_MVC.Data;
using GameStore_MVC.Models.GameStoreViewModels.GameVM;
using GameStore_MVC.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GameStore_MVC.Services
{
	public class GameServices : IGameService
	{
		private ApplicationDbContext _context;
		private IMapper _mapper;

		public GameServices(ApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<bool> AddGame(GameCreate model)
		{
			if (model is null) return false;

			var game = _mapper.Map<Game>(model);
			await _context.Games.AddAsync(game);
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<bool> DeleteGame(int id)
		{
			var game = await _context.Games.FindAsync(id);
			if (game == null) return false;
			_context.Games.Remove(game);
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<GameDetail> GetGame(int id)
		{
			var game = await _context.Games
				.Include(g => g.GameDevs)
				.FirstOrDefaultAsync(g => g.Id == id);
			if (game == null) return null;

			return _mapper.Map<GameDetail>(game);

		}

		public async Task<List<GameListItem>> GetGames()
		{
			return await _context.Games.Select(m => _mapper.Map<GameListItem>(m)).ToListAsync();
		}

		public async Task<bool> UpdateGame(int id, GameEdit model)
		{
			var game = await _context.Games.FindAsync(id);
			if (game == null) return false;

			game.AgeRating = model.AgeRating;
			game.QuantityInStock = model.QuantityInStock;
			game.Price = model.Price;
			game.Title = model.Title;
			game.Description = model.Description;
			game.ImageURL = model.ImageURL;
			game.Platform = model.Platform;
			game.GameDevId = model.GameDevId;

			return await _context.SaveChangesAsync() > 0;
		}
	}
}
