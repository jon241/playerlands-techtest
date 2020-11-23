using System.Collections.Generic;

namespace testapi.Controllers
{
    public interface IPlayersSource
    {
        IEnumerable<Player> Get();
    }
}
