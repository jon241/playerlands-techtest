using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using testapi.framework;

namespace testapi.players
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

            // Checking the file exists here because if the file is not found
            // I want to know ASAP and during startup is the earliest time.
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
            try
            {
                PlayersCollection collection = JsonConvert.DeserializeObject<PlayersCollection>(File.ReadAllText(_fileSource));

                return collection.players.ToList();
            } 
            catch (Exception exception)
            {
                exception.Data.Add("FileSource", _fileSource);
                throw;
            }
        }
    }
}
