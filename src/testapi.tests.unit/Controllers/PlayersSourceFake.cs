using System.Collections.Generic;
using testapi.Controllers;

namespace testapi.tests.unit.Controllers
{
    internal class PlayersSourceFake : IPlayersSource
    {
        private IEnumerable<Player> _players;

        public PlayersSourceFake(IEnumerable<Player> players)
        {
            _players = players;
        }

        public IEnumerable<Player> Get()
        {
            return _players;
        }
    }
}
