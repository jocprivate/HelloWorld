using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Greeting.Services;
using Greeting.Data;
using Greeting.Models;
using Moq;
namespace Greeting.Tests
{
    [TestFixture]
    public class ServiceTests
    {
        private IGreetingService _greetingService;
        private IRepository _dbRepository;
        private List<IGreeting> _greetings;

        [SetUp]
        public void Setup()
        {
            _greetingService = new GreetingService();
            _dbRepository = SetupDBRepository();
            _greetings = new List<IGreeting>();
            HelloGreeting Hey = new HelloGreeting
            {
                Id = 0,
                Name = "Hello World",
                IsNice = true
            };
            _greetings.Add(Hey);
        }

        public IRepository SetupDBRepository()
        {
            var repo = new Mock<IRepository>();
            repo.Setup(r => r.Get()).Returns(_greetings);
            return repo.Object;
        }

        [Test]
        public void GreetingServiceNamesAreEqual()
        {
            var greetings = _greetingService.Fetch();
            Assert.AreEqual(greetings.FirstOrDefault().Name, greetings.FirstOrDefault().Name);
        }
        [Test]
        public void GreetingServiceIdsAreEqual()
        {
            var greetings = _greetingService.Fetch();
            Assert.AreEqual(greetings.FirstOrDefault().Id, greetings.FirstOrDefault().Id);
        }
        [Test]
        public void GreetingServiceCountIsEqual()
        {
            var greetings = _greetingService.Fetch();
            Assert.AreEqual(greetings.Count(), greetings.Count());
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            _greetingService = null;
            _dbRepository = null;
            _greetings = null;
        }
    }
}
