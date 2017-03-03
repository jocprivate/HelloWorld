using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greeting.Models;
namespace Greeting.Data
{
    public class FileRepository: IRepository
    {
        //Implementation of File Repository
        public virtual IEnumerable<IGreeting> Get() { return new List<IGreeting>(); }
        public virtual IGreeting GetById(int id) { IGreeting greeting = new HelloGreeting(); return greeting; }
        public virtual void Delete(int id) { }
        public virtual void Delete(IGreeting entity) { }
        public virtual IGreeting Insert(IGreeting entity) { IGreeting greeting = new HelloGreeting(); return greeting; }
        public virtual void Update(IGreeting entity) { }
    }
}
