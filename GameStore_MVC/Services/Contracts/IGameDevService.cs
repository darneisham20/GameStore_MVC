using GameStore_MVC.Models.GameStoreViewModels.GameDevVM;

namespace GameStore_MVC.Services.Contracts
{
	public interface IGameDevService
	{
		Task<bool> AddGameDev(GameDevCreate model);
		Task<bool> UpdateGameDev(int id, GameDevEdit model);
		Task<bool> DeleteGameDev(int id);
		Task<GameDevDetail> GetGameDev(int id);
		Task<List<GameDevListItem>> GetGameDevs();
	}
}
