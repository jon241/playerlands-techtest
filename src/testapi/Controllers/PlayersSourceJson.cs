using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace testapi.Controllers
{
    /// <summary>
    /// Players source Json
    /// </summary>
    public class PlayersSourceJson : IPlayersSource
    {
        private readonly string _fileSource;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileSource">Location of Json file</param>
        public PlayersSourceJson(string fileSource)
        {
            if (string.IsNullOrEmpty(fileSource))
                throw new ArgumentException("Value cannot be null or empty.", nameof(fileSource));

            if (!File.Exists(fileSource))
                throw new FileNotFoundException($"File not found: {fileSource}");

            _fileSource = fileSource;
        }

        /// <summary>
        /// Get players from configured Json file
        /// </summary>
        /// <returns>List of players</returns>
        public IEnumerable<Player> GetPlayers()
        {
            PlayersCollection collection = JsonConvert.DeserializeObject<PlayersCollection>(File.ReadAllText(_fileSource));

            return collection.players.ToList();
        }
    }
}
