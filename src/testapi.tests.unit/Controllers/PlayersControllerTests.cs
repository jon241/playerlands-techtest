using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using testapi.Controllers;
using System.Linq;
using System;

namespace testapi.tests.unit.Controllers
{
    [TestClass]
    [TestCategory("Unit")]
    public class PlayersControllerTests
    {
        private PlayersController _controller;

        [TestInitialize]
        public void Initialise()
        {
            List<Player> players = new List<Player>();
            players.Add(new Player() { UserName = "player1", DateJoined = "2020-10-22", Email = "player1@email.com" });
            IPlayersSource dataSource = new PlayersSourceFake(players);

            _controller = new PlayersController(dataSource);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenControllerHasNullPlayersSourceThenThrowArgumentNullException()
        {
            try
            {
                new PlayersController(null);
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("Value cannot be null. (Parameter 'playersSource')", exception.Message, "Message");
                throw;
            }
        }

        [TestMethod]
        public void WhenPlayersAreAvailableThenReturnPlayers()
        {
            ActionResult<IEnumerable<Player>> players = _controller.Get();

            Assert.AreEqual(1, players.Value.Count(), "Players count");

            foreach(var player in players.Value)
            {
                Assert.AreEqual("player1", player.UserName, "PlayerUserName");
                Assert.AreEqual("2020-10-22", player.DateJoined, "PlayerDateJoined");
                Assert.AreEqual("player1@email.com", player.Email, "PlayerEmail");
            }
        }
    }
}
