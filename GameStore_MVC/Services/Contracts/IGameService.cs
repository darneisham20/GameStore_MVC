using GameStore_MVC.Models.GameStoreViewModels.GameVM;

namespace GameStore_MVC.Services.Contracts
{
	public interface IGameService
	{
		Task<bool> AddGame(GameCreate model);
		Task<bool> UpdateGame(int id, GameEdit model);
		Task<bool> DeleteGame(int id);
		Task<GameDetail> GetGame(int id);
		Task<List<GameListItem>> GetGames();
	}
}
