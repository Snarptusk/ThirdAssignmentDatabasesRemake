namespace WindowsFormsApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adresses",
                c => new
                    {
                        AdressID = c.Int(nullable: false, identity: true),
                        Home = c.String(),
                        Work = c.String(),
                        Other = c.String(),
                        City = c.String(),
                        person_PersonID = c.Int(),
                    })
                .PrimaryKey(t => t.AdressID)
                .ForeignKey("dbo.People", t => t.person_PersonID)
                .Index(t => t.person_PersonID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.PersonID);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        PhoneID = c.Int(nullable: false, identity: true),
                        Home = c.String(),
                        Cellphone = c.String(),
                        Other = c.String(),
                        person_PersonID = c.Int(),
                    })
                .PrimaryKey(t => t.PhoneID)
                .ForeignKey("dbo.People", t => t.person_PersonID)
                .Index(t => t.person_PersonID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phones", "person_PersonID", "dbo.People");
            DropForeignKey("dbo.Adresses", "person_PersonID", "dbo.People");
            DropIndex("dbo.Phones", new[] { "person_PersonID" });
            DropIndex("dbo.Adresses", new[] { "person_PersonID" });
            DropTable("dbo.Phones");
            DropTable("dbo.People");
            DropTable("dbo.Adresses");
        }
    }
}
