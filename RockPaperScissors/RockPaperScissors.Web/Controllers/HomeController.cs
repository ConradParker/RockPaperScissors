using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RockPaperScissors.Data;
using RockPaperScissors.Web.Models;

namespace RockPaperScissors.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly RockPaperScissorsContext _context;

        public HomeController(RockPaperScissorsContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index()
        {
            var gameItems = await _context.GameItems.ToListAsync();
            return View(gameItems);
        }

        // GET: GameItems/Select/5
        public async Task<IActionResult> Play(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameItem = await _context.GameItems.SingleOrDefaultAsync(m => m.Id == id);
            if (gameItem == null)
            {
                return NotFound();
            }
            return View(gameItem);
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

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
