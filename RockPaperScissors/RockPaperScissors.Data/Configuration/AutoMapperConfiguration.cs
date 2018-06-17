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
                cfg.CreateMap<Match, MatchDto>()
                .ForMember(dto => dto.PlayerOneId, opt => opt.MapFrom(g => g.PlayerOne.Id))
                .ForMember(dto => dto.PlayerTwoId, opt => opt.MapFrom(g => g.PlayerTwo.Id));

                cfg.CreateMap<Game, GameDto>()
                .ForMember(dto => dto.PlayerOneChoice, opt => opt.MapFrom(gp => gp.PlayerOneChoice.Name))
                .ForMember(dto => dto.PlayerTwoChoice, opt => opt.MapFrom(gp => gp.PlayerTwoChoice.Name))
                .ForMember(dto => dto.Result, opt => opt.UseValue("TODO: Calculate"));
            });
        }
    }
}
