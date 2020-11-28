using System.Collections.Generic;

namespace testapi.framework
{
    public interface IPlayersSource
    {
        IEnumerable<Player> GetPlayers();
    }
}
