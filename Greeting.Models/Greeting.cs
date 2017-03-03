using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting.Models
{
    public abstract class Greeting : IGreeting 
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
