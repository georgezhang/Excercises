using System;
using System.Data.Entity;

namespace Excercises.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() : base("ExcercisesDB")
        {
            //Disable initializer
            //Database.SetInitializer<ApplicationDBContext>(null);
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
        public virtual DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}