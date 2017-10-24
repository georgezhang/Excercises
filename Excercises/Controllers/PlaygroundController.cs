using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Excercises.Models;
using System.Threading.Tasks;


namespace Excercises.Controllers
{
    public class PlaygroundController : Controller
    {
        private PlaygroundRepository repo = new PlaygroundRepository();

        // GET: Playground
        public ActionResult Index()
        {
            return View();
        }

        // GET: Example of Store procedure
        public ActionResult StoredProcedure()
        {
            // 1. return a table
            IEnumerable<Person> people = repo.GetPeople();

            // 2. return one person
            IEnumerable<Person> iePerson = repo.GetPerson(1);

            // 3. return two persons
            Tuple<IEnumerable<Person>, IEnumerable<Person>> persons = repo.Get2Person(1, 2);

            PlaygroundViewModels playgroundViewModels = new PlaygroundViewModels
            {
                people = people,
                person = iePerson.First(),
                persons = persons
            };

            return View(playgroundViewModels);
        }
    }
}