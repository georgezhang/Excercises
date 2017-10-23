using System;
using System.Data.Entity;

namespace Excercises.Models
{
    public class Person
    {
        public int PersonID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }

    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() : base("ExcercisesDB")
        {
            //Disable initializer
            Database.SetInitializer<ApplicationDBContext>(null);
        }
        /* !!!
         * You can define your data sets here directly which is
         * the way to go for most web application. But as for
         * the training on SQL, we will use store procedure instead!!!
         * 
         * We use a library CodeOnlyStoredProcedures
         *  https://github.com/abe545/CodeOnlyStoredProcedures
         *  
         *  Install-Package CodeOnlyStoredProcedures
         *  
         */
        //public DbSet<Student> Students { get; set; }
    }
}