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
            // 1. return a table
            IEnumerable<Person> people = repo.GetPeople();

            //first and second person ID
            int firstID = 0, secondID = 0;

            Person[] peopleArray = people.ToArray();
            if (peopleArray.Length > 0)
            {
                firstID = peopleArray[0].PersonID;
                secondID = peopleArray[1].PersonID;
            }


            // 2. return one person
            IEnumerable<Person> iePerson = repo.GetPerson(firstID);

            // 3. return two persons
            Tuple<IEnumerable<Person>, IEnumerable<Person>> persons = repo.Get2Person(firstID, secondID);

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