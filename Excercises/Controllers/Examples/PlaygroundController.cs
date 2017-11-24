using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Excercises.Models;
using System.Threading.Tasks;
using System.Collections;

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
            //view model
            PlaygroundViewModels viewModels = new PlaygroundViewModels();

            // 1. return a table
            IEnumerable<Person> people = repo.GetPeople();
            int count = people.Count();

            Person[] peopleArray = people.ToArray();
            if (count > 0)
            {
                viewModels.people = people;

                int firstID = peopleArray[0].PersonID;

                // 2. return one person
                IEnumerable<Person> iePerson = repo.GetPerson(firstID);
                viewModels.person = iePerson.First();

                if (count > 1)
                {
                    int secondID = peopleArray[1].PersonID;
                    // 3. return two persons
                    Tuple<IEnumerable<Person>, IEnumerable<Person>> persons = repo.Get2Person(firstID, secondID);
                    viewModels.persons = persons;
                }

            }

            return View(viewModels);
        }
    }
}