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
                // Create a new GameInfo if collection is empty,
                // which means you can't delete all GameInfos.
                _context.GameInfos.Add(new GameInfo { ClanName = "Makers Institute" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<GameInfo>> GetAll()
        {
            return _context.GameInfos.ToList();
        }

        [HttpGet("{gameId}", Name = "GetGameInfo")]
        public ActionResult<GameInfo> GetByGameId(int gameId)
        {
            var item = _context.GameInfos.Find(gameId);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(GameInfo item)
        {
            _context.GameInfos.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetGameInfo", new { gameId = item.Id }, item);
            // return "wow";
        }
    }
}