using System.Collections.Generic;
using testapi.framework;

namespace testapi.tests.unit.Controllers
{
    internal class PlayersSourceFake : IPlayersSource
    {
        private IEnumerable<Player> _players;

        public PlayersSourceFake(IEnumerable<Player> players)
        {
            _players = players;
        }

        public IEnumerable<Player> GetPlayers()
        {
            return _players;
        }
    }
}
