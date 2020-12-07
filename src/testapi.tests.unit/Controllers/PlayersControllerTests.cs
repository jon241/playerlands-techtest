using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using testapi.Controllers;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using testapi.framework;
using Moq;

namespace testapi.tests.unit.Controllers
{
    [TestClass]
    [TestCategory("Unit")]
    public class PlayersControllerTests
    {
        private Mock<IPlayersSource> _dataSource;
        private LoggerMock<PlayersController> _logger;
        private PlayersController _controller;
        private IEnumerable<Player> _players;

        [TestInitialize]
        public void Initialise()
        {
            _players = new List<Player>() {
                new Player() {
                    UserName = "player1",
                    DateJoined = "2020-10-22",
                    Email = "player1@email.com"
                }
            };
            // a bit over the top to use a mocking library for just one simple class but
            // it shows what I know.
            _dataSource = new Mock<IPlayersSource>();
            //_dataSource = new PlayersSourceFake(players);
            _logger = new LoggerMock<PlayersController>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenControllerHasNullLoggerThenThrowArgumentNullException()
        {
            try
            {
                _logger = null;
                CreateController();
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("Value cannot be null.\r\nParameter name: logger", exception.Message, "Message");
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenControllerHasNullPlayersSourceThenThrowArgumentNullException()
        {
            try
            {
                _dataSource = null;
                CreateController();
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("Value cannot be null.\r\nParameter name: playersSource", exception.Message, "Message");
                throw;
            }
        }

        [TestMethod]
        public void WhenPlayersAreAvailableThenReturnPlayers()
        {
            _dataSource.Setup(source => source.GetPlayers()).Returns(_players);
            CreateController();

            ActionResult<IEnumerable<Player>> response = _controller.Get();

            Assert.AreEqual(typeof(OkObjectResult), response.Result.GetType(), "StatusCode");
            _dataSource.Verify(source => source.GetPlayers(), Times.Once(), "Get players count");
            var players = (response.Result as OkObjectResult).Value as List<Player>;
            Assert.AreEqual(1, players.Count(), "Players count");

            foreach (var player in players)
            {
                Assert.AreEqual("player1", player.UserName, "PlayerUserName");
                Assert.AreEqual("2020-10-22", player.DateJoined, "PlayerDateJoined");
                Assert.AreEqual("player1@email.com", player.Email, "PlayerEmail");
            }
        }

        [TestMethod]
        public void WhenGettingPlayersErrorsThenReturnCode()
        {
            _dataSource.Setup(source => source.GetPlayers()).Throws(new ApplicationException("Failure"));
            CreateController();

            ActionResult<IEnumerable<Player>> response = _controller.Get();

            // this technique would need changing once more status codes are tested for
            Assert.AreEqual(typeof(StatusCodeResult), response.Result.GetType(), "StatusCode");
            _dataSource.Verify(source => source.GetPlayers(), Times.Once(), "Get players count");
            Assert.AreEqual("Failure", _logger.StateReceived.ToString(), "Exception");
        }

        private void CreateController()
        {
            // putting the controller creation here means I can easily add a new parameter
            // without changing loads of tests
            _controller = new PlayersController(_logger, _dataSource == null ? null : _dataSource.Object);
        }
    }
}
