using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greeting.Models;
namespace Greeting.Data
{
    //Implementation of DB Repository
    public class DBRepository : IRepository
    {
        //Faked Implementation of Get
        public virtual IEnumerable<IGreeting> Get()
        {
            try
            {
                List<IGreeting> greetingList = new List<IGreeting>();
                HelloGreeting Hey = new HelloGreeting {
                                        Id = 0,
                                        Name = "Hello World",
                                        IsNice = true
                                    };
                greetingList.Add(Hey);                
                return greetingList;
            }
            catch (Exception e)
            {
                //Catch Exception
            }
            return new List<IGreeting>();
        }
        //Implementation of Get By Id
        public virtual IGreeting GetById(int id) { IGreeting greeting = new HelloGreeting(); return greeting; }

        //Implementation of Delete By Id
        public virtual void Delete(int id) { }

        //Implementation of Delete By Greeting Entity
        public virtual void Delete(IGreeting entity) { }

        //Implementation of Insert
        public virtual IGreeting Insert(IGreeting entity) { IGreeting greeting = new HelloGreeting(); return greeting; }

        //Implementation of Insert
        public virtual void Update(IGreeting entity) { }

      
    }
}
