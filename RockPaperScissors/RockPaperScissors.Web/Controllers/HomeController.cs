using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RockPaperScissors.Data.Repositories;
using RockPaperScissors.Web.Models;

namespace RockPaperScissors.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _gameRepo;
        private IConfiguration _configuration;

        public HomeController(IRepository gameRepo, IConfiguration configuration)
        {
            _gameRepo = gameRepo;
            _configuration = configuration;
        }
        
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Play(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamePlayCount = int.Parse(_configuration["AppSettings:GamePlays"]);
            var humanPlayerType = _gameRepo.GetPlayerType(1);
            var computerPlayerType = _gameRepo.GetPlayerType(id.Value);
            var game = _gameRepo.AddGame(gamePlayCount, humanPlayerType, computerPlayerType);

            return View(game);
        }

        public async Task<IActionResult> Start()
        {
            var computerPlayers = _gameRepo.GetPlayerTypes().Where(p => p.Name != "Human");
            return View(computerPlayers);
        }


        public IActionResult Todo()
        {
            ViewData["Message"] = "Todo List.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
