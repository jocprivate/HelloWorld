using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greeting.Models;
namespace Greeting.Data
{
    public interface IRepository
    {
        IEnumerable<IGreeting> Get();
        IGreeting GetById(int id);
        void Delete(int id);
        void Delete(IGreeting entity);
        IGreeting Insert(IGreeting entity);
        void Update(IGreeting entity);
    }
}
