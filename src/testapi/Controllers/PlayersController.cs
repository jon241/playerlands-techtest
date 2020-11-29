using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using testapi.framework;

namespace testapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly ILogger<PlayersController> _logger;
        private readonly IPlayersSource _playersSource;

        public PlayersController(ILogger<PlayersController> logger, IPlayersSource playersSource)
        {
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));

            if (playersSource == null)
                throw new ArgumentNullException(nameof(playersSource));
            
            _logger = logger;
            _playersSource = playersSource;
        }

        // GET api/players
        [HttpGet]
        public ActionResult<IEnumerable<Player>> Get()
        {
            try
            {
                return Ok(new List<Player>(_playersSource.GetPlayers()));
            } 
            catch (Exception exception)
            {
                _logger.LogError(exception.Message, exception);

                return new StatusCodeResult(500);
            }
        }
    }
}
