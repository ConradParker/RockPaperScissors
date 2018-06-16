using AutoMapper;
using RockPaperScissors.Dto;
using RockPaperScissors.Model;

namespace RockPaperScissors.Data
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            ConfigurePropertyMappings();
        }


        private static void ConfigurePropertyMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Game, GameDto>()
                .ForMember(dto => dto.PlayerOneType, opt => opt.MapFrom(g => g.PlayerOneType.Name))
                .ForMember(dto => dto.PlayerTwoType, opt => opt.MapFrom(g => g.PlayerTwoType.Name));

                cfg.CreateMap<GamePlay, GamePlayDto>()
                .ForMember(dto => dto.PlayerOneChoice, opt => opt.MapFrom(gp => gp.PlayerOneChoice.Name))
                .ForMember(dto => dto.PlayerTwoChoice, opt => opt.MapFrom(gp => gp.PlayerTwoChoice.Name))
                .ForMember(dto => dto.PlayerTwoChoice, opt => opt.UseValue("TODO: Calculate"));
            });
        }
     }
}
