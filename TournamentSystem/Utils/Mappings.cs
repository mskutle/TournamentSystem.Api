using AutoMapper;
using TournamentSystem.Models;
using TournamentSystem.ViewModels;

namespace TournamentSystem.Utils {

    public static class Mappings {

        public static IMapper GetMapper() {
            
            var config = new AutoMapper.MapperConfiguration(cfg => {
                cfg.CreateMap<PlayerViewModel, Player>();
            });

            return config.CreateMapper();
        }
    }
}