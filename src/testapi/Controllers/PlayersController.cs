using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace testapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayersSource _playersSource;

        public PlayersController(IPlayersSource playersSource)
        {
            if (playersSource == null)
                throw new ArgumentNullException(nameof(playersSource));

            _playersSource = playersSource;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Player>> Get()
        {
            return new List<Player>(_playersSource.Get());
        }
    }
}
