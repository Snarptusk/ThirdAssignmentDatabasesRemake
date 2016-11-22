namespace WindowsFormsApplication1
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PersonContext : DbContext
    {
        // Your context has been configured to use a 'PersonContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'WindowsFormsApplication1.PersonContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'PersonContext' 
        // connection string in the application configuration file.
        public PersonContext()
            : base("name=PersonContext")
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Phone> Phones { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}