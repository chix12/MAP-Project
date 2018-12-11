namespace MapData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TestQuestions", newName: "QuestionTests");
            RenameTable(name: "dbo.DemandeurTests", newName: "TestDemandeurs");
            DropPrimaryKey("dbo.QuestionTests");
            DropPrimaryKey("dbo.TestDemandeurs");
            AddColumn("dbo.AspNetUsers", "PassPort", c => c.String());
            AddColumn("dbo.AspNetUsers", "Status1", c => c.Int());
            AddColumn("dbo.AspNetUsers", "RequestDate", c => c.DateTime());
            AddPrimaryKey("dbo.QuestionTests", new[] { "Question_QuestionId", "Test_TestId" });
            AddPrimaryKey("dbo.TestDemandeurs", new[] { "Test_TestId", "Demandeur_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.TestDemandeurs");
            DropPrimaryKey("dbo.QuestionTests");
            DropColumn("dbo.AspNetUsers", "RequestDate");
            DropColumn("dbo.AspNetUsers", "Status1");
            DropColumn("dbo.AspNetUsers", "PassPort");
            AddPrimaryKey("dbo.TestDemandeurs", new[] { "Demandeur_Id", "Test_TestId" });
            AddPrimaryKey("dbo.QuestionTests", new[] { "Test_TestId", "Question_QuestionId" });
            RenameTable(name: "dbo.TestDemandeurs", newName: "DemandeurTests");
            RenameTable(name: "dbo.QuestionTests", newName: "TestQuestions");
        }
    }
}
