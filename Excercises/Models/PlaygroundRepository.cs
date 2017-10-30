using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Excercises.Models;
using System.Data;
using CodeOnlyStoredProcedure;
using System.Threading.Tasks;
using System.Threading;
using NLog;

namespace Excercises.Models
{
    public class PlaygroundRepository
    {

        /* !!!
         *  This is not DBContext, it is IDbConnection. 
         */
        public const int timeout = 5000; // 5 seconds

        private IDbConnection db = (new ApplicationDBContext()).Database.Connection;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        internal IEnumerable<Person> GetPeople()
        {
            try
            {
                return db.Execute(timeout).usp_GetPeople();
            } catch (Exception e)
            {
                logger.Error(e);
                throw new Exception(@"Error in calling store procedure usp_GetPeople.");
            }
        }

        internal IEnumerable<Person> GetPerson(int personID)
        {
            try
            {
                return db.Execute(timeout).usp_GetPerson(PersonID: personID);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw new Exception(@"Error in calling store procedure usp_GetPerson.");
            }
        }


        internal Tuple<IEnumerable<Person>, IEnumerable<Person>> Get2Person(int personID1, int personID2)
        {
            try
            {
                return db.Execute().usp_Get2Person(PersonID1: personID1, PersonID2: personID2);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw new Exception(@"Error in calling store procedure usp_Get2Person.");
            }
        }

    }
}