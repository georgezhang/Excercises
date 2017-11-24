using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Excercises.Models
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext() : base("ExcercisesDB", throwIfV1Schema: false)
        {
            //Disable initializer
            //Database.SetInitializer<ApplicationDBContext>(null);
        }
        /* !!!
         * You can define your data sets here directly which is
         * the way to go for most web application. As for
         * the training on SQL, we also use store procedure.
         * 
         * We use a library CodeOnlyStoredProcedures
         *  https://github.com/abe545/CodeOnlyStoredProcedures
         *  
         *  Install-Package CodeOnlyStoredProcedures
         *  
         */

        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }

        public static ApplicationDBContext Create()
        {
            return new ApplicationDBContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // one-to-zero or one relationship between ApplicationUser and Exam
            // OwnerId column in Exam table will be foreign key
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(m => m.Exams)
                .WithRequired(m => m.ApplicationUser)
                .Map(p => p.MapKey("OwnerId"));
        }
    }
}