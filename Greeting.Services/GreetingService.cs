using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greeting.Models;
using System.Configuration;
using Greeting.Data;
namespace Greeting.Services
{
    public class GreetingService : IGreetingService
    {
        private IRepository _repository;
        private readonly string source = System.Configuration.ConfigurationManager.AppSettings["source"];
        public GreetingService() { }
             
        public IEnumerable<IGreeting> Fetch()
        {
            try
            {
                IEnumerable<IGreeting> greetingList;
                switch (source)
                {
                    case "1":
                        _repository = new DBRepository();
                        greetingList = _repository.Get();
                        break;
                    case "2":
                        _repository = new FileRepository();
                        greetingList = _repository.Get();
                        break;

                    default:
                        _repository = new DBRepository();
                        greetingList = _repository.Get();
                        break;                        
                }
                return greetingList;
            }
            catch (Exception e) { }
            return new List<IGreeting>();
        }
        public IGreeting Fetch(int id)
        {
            //Implementation of Fetch One
            return new HelloGreeting();
        }
        public void Delete(int id)
        {
            //Implementation of Delete
        }
        public void Insert(IGreeting greeting)
        {
            //Implementation of Insert
        }

        public void Update(IGreeting greeting)
        {
            //Implementation of Update
        }

    }
}
