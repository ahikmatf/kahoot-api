using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using kahoot_api.Models;

namespace kahoot_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameInfoController : ControllerBase
    {
        private readonly GameContext _context;

        public GameInfoController(GameContext context)
        {
            _context = context;

            if (_context.GameInfos.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.GameInfos.Add(new GameInfo { ClanName = "Item1" });
                _context.SaveChanges();
            }
        }
    }
}