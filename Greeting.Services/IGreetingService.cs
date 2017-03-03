using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greeting.Models;
namespace Greeting.Services
{
    public interface IGreetingService
    {
        IEnumerable<IGreeting> Fetch();
        IGreeting Fetch(int Id);
        void Insert(IGreeting greeting);
        void Update(IGreeting greeting);
        void Delete(int Id);
    }
}
