using AutoMapper;
using GameStore_MVC.Data.Entities;
using GameStore_MVC.Data;
using GameStore_MVC.Models.GameStoreViewModels.GameDevVM;
using GameStore_MVC.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GameStore_MVC.Services
{
	public class GameDevServices :IGameDevService
	{
		private ApplicationDbContext _context;
		private IMapper _mapper;

		public GameDevServices(ApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<bool> AddGameDev(GameDevCreate model)
		{
			if (model is null) return false;

			var gameDev = _mapper.Map<GameDev>(model);
			await _context.GameDevs.AddAsync(gameDev);
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<bool> DeleteGameDev(int id)
		{
			var gameDev = await _context.GameDevs.FindAsync(id);
			if (gameDev == null) return false;
			_context.GameDevs.Remove(gameDev);
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<GameDevDetail> GetGameDev(int id)
		{
			var gameDev = await _context.GameDevs.FindAsync(id);
			if (gameDev == null) return null!;
			return _mapper.Map<GameDevDetail>(gameDev);
		}

		public async Task<List<GameDevListItem>> GetGameDevs()
		{
			return await _context.GameDevs.Select(m => _mapper.Map<GameDevListItem>(m)).ToListAsync();
		}

		public async Task<bool> UpdateGameDev(int id, GameDevEdit model)
		{
			var gameDev = await _context.GameDevs.FindAsync(id);
			if (gameDev == null) return false;

			gameDev.Developer = model.Developer;
			gameDev.City = model.City;
			gameDev.Country = model.Country;
			gameDev.Est = model.Est;

			return await _context.SaveChangesAsync() > 0;
		}
	}
}
