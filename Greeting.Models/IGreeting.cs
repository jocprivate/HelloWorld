using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting.Models
{
    public interface IGreeting
    {
       int Id { get; set; }
       string Name { get; set;}
    }
}
