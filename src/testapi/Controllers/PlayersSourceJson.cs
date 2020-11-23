using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testapi.Controllers
{
    public class PlayersSourceJson : IPlayersSource
    {
        public IEnumerable<Player> Get()
        {
            List<Player> players = new List<Player>();
            players.Add(new Player() { UserName = "player1", DateJoined = "2020-10-22", Email = "player1@email.com" });

            return players;
        }
    }
}
