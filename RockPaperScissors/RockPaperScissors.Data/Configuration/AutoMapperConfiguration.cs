using AutoMapper;
using RockPaperScissors.Dto.Query;
using RockPaperScissors.Model;
using System.Text;

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
                .ForMember(dto => dto.PlayerOneId, opt => opt.MapFrom(m => m.PlayerOne.Id))
                .ForMember(dto => dto.PlayerTwoId, opt => opt.MapFrom(m => m.PlayerTwo.Id))
                .ForMember(dto => dto.PlayerOneType, opt => opt.MapFrom(m => AddSpacesToSentence(m.PlayerOne.GetType().Name)))
                .ForMember(dto => dto.PlayerTwoType, opt => opt.MapFrom(m => AddSpacesToSentence(m.PlayerTwo.GetType().Name)))
                .ForMember(dto => dto.Result, opt => opt.MapFrom(m => m.Result.Text));

                cfg.CreateMap<Game, GameDto>()
                .ForMember(dto => dto.PlayerOneChoice, opt => opt.MapFrom(g => g.PlayerOneChoice.Name))
                .ForMember(dto => dto.PlayerTwoChoice, opt => opt.MapFrom(g => g.PlayerTwoChoice.Name))
                .ForMember(dto => dto.ResultId, opt => opt.MapFrom(g => g.Result.Id))
                .ForMember(dto => dto.Result, opt => opt.MapFrom(g => g.Result.Text));

                cfg.CreateMap<GameItem, GameItemDto>();
            });
        }

        /// <summary>
        /// Method to add spaces between Camel/Pascal case styled text
        /// </summary>
        /// <param name="text"></param>
        /// <returns>string</returns>
        public static string AddSpacesToSentence(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "";
            var newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]) && text[i - 1] != ' ')
                    newText.Append(' ');
                newText.Append(text[i]);
            }
            return newText.ToString();
        }
    }
}
