namespace AutofacGenericRepositoryMvc.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Languages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonLanguages",
                c => new
                    {
                        Person_Id = c.Long(nullable: false),
                        Language_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_Id, t.Language_Id })
                .ForeignKey("dbo.People", t => t.Person_Id, cascadeDelete: true)
                .ForeignKey("dbo.Languages", t => t.Language_Id, cascadeDelete: true)
                .Index(t => t.Person_Id)
                .Index(t => t.Language_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonLanguages", "Language_Id", "dbo.Languages");
            DropForeignKey("dbo.PersonLanguages", "Person_Id", "dbo.People");
            DropIndex("dbo.PersonLanguages", new[] { "Language_Id" });
            DropIndex("dbo.PersonLanguages", new[] { "Person_Id" });
            DropTable("dbo.PersonLanguages");
            DropTable("dbo.Languages");
        }
    }
}
