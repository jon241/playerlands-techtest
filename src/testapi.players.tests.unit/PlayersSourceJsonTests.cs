using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace testapi.players.tests.unit
{
    [TestClass]
    [TestCategory("Unit")]
    public class PlayersSourceJsonTests
    {
        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenConstructorHasInvalidFileSourceThenThrowArgumentException(string fileSource)
        {
            try
            {
                new PlayersSourceJson(fileSource);
            }
            catch (ArgumentException exception)
            {
                Assert.AreEqual("Value cannot be null or empty. (Parameter 'fileSource')", exception.Message, "Message");
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void WhenConstructorHasUnknownFileSourceThenThrowFileNotFoundException()
        {
            try
            {
                new PlayersSourceJson(".\\unknown.json");
            }
            catch (FileNotFoundException exception)
            {
                Assert.AreEqual("File not found: .\\unknown.json", exception.Message, "Message");
                throw;
            }
        }

        // Normally I would put this test would be in an integrations tests project but
        // easier for this example to remain here
        [TestMethod]
        public void WhenGetHasFileThenReturnPlayers()
        {
            var source = new PlayersSourceJson(".\\goodplayers.json");

            var players = source.GetPlayers();

            Assert.AreEqual(2, players.Count(), "Players count");

            int i = 1;
            foreach (var player in players)
            {
                Assert.AreEqual($"player{i}", player.UserName, "UserName");
                Assert.AreEqual($"2020-10-0{i}", player.DateJoined, "DateJoined");
                Assert.AreEqual($"player{i}@email.com", player.Email, "Email");
                i++;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(JsonSerializationException))]
        public void WhenGetHasBadJsonDataThenThrowJsonException()
        {
            try
            {
                new PlayersSourceJson(".\\badplayers.json").GetPlayers();
            }
            catch (JsonSerializationException exception)
            {
                Assert.IsTrue(exception.Message.StartsWith("Unexpected end"), "Message");
                Assert.AreEqual(exception.Data["FileSource"], ".\\badplayers.json", "DataFileSource");
                throw;
            }
        }
    }
}
