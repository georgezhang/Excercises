using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Excercises.Models
{
    public class PlaygroundViewModels
    {
        public IEnumerable<Person> people { get; set; }
        public Person person { get; set; }
        public Tuple<IEnumerable<Person>, IEnumerable<Person>> persons { get; set; }
    }
}