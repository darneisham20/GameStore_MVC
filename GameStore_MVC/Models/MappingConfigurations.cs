using AutoMapper;
using GameStore_MVC.Data.Entities;
using GameStore_MVC.Models.GameStoreViewModels.GameDevVM;
using GameStore_MVC.Models.GameStoreViewModels.GameVM;

namespace GameStore_MVC.Models
{
	public class MappingConfigurations : Profile
	{
		public MappingConfigurations()
		{
			CreateMap<Game, GameCreate>().ReverseMap();
			CreateMap<Game, GameDetail>().ReverseMap();
			CreateMap<Game, GameEdit>().ReverseMap();
			CreateMap<Game, GameListItem>().ReverseMap();

			CreateMap<GameDev, GameDevCreate>().ReverseMap();
			CreateMap<GameDev, GameDevDetail>().ReverseMap();
			CreateMap<GameDev, GameDevEdit>().ReverseMap();
			CreateMap<GameDev, GameDevListItem>().ReverseMap();

		}
	}
}
