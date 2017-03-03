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
using System.Net.Http;
using System.Web.Http;
using Greeting.API.Controllers;
using Newtonsoft.Json;
namespace Greeting.Tests
{
    [TestFixture]
    public class GreetingControllerTest
    {
        private IGreetingService _greetingService;
        private IRepository _dbRepository;
        private List<IGreeting> _greetings;
        private HttpClient _client;
        private IHttpActionResult _response;
        private const string serviceURL = "http://localhost:55555/api/Greeting";

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
            _client = new HttpClient { BaseAddress = new Uri(serviceURL) };
        }
        public IRepository SetupDBRepository()
        {
            var repo = new Mock<IRepository>();
            repo.Setup(r => r.Get()).Returns(_greetings);
            return repo.Object;
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            _greetingService = null;
            _dbRepository = null;
            _greetings = null;
            _response = null;
            _client = null;
        }

        [Test]
        public void GreetingOkStatus()
        {      
            var greetingController = new GreetingController();
            _response = greetingController.Get();
            Assert.IsInstanceOf<System.Web.Http.Results.OkNegotiatedContentResult<IEnumerable<IGreeting>>>(_response);            
        }
        [Test]
        public void GreetingNotNull()
        {
            var greetingController = new GreetingController();
            _response = greetingController.Get();
            Assert.NotNull(_response);
        }

        [Test]
        public void GreetingCount()
        {
            var greetingController = new GreetingController();
            _response = greetingController.Get();
            var response = _response as System.Web.Http.Results.OkNegotiatedContentResult<IEnumerable<IGreeting>>;  
            var greetings = response.Content;
            Assert.AreEqual(1, greetings.Count());
        }

        [Test]
        public void GreetingCheckName()
        {
            var greetingController = new GreetingController();
            _response = greetingController.Get();
            var response = _response as System.Web.Http.Results.OkNegotiatedContentResult<IEnumerable<IGreeting>>;
            var greetings = response.Content;
            Assert.AreEqual("Hello World", greetings.FirstOrDefault().Name);
        }
    }    
}
