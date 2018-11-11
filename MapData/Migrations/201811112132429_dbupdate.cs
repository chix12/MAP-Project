namespace MapData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbupdate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RessourceProjects", newName: "ProjectRessources");
            DropForeignKey("dbo.ClientRequestForms", "IdProject", "dbo.Projects");
            DropIndex("dbo.ClientRequestForms", new[] { "IdProject" });
            RenameColumn(table: "dbo.AspNetUsers", name: "Name", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.AspNetUsers", name: "Name1", newName: "Name");
            RenameColumn(table: "dbo.AspNetUsers", name: "__mig_tmp__0", newName: "Name1");
            DropPrimaryKey("dbo.ProjectRessources");
            AddColumn("dbo.ClientRequestForms", "Fees", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ProjectRessources", new[] { "Project_IdProject", "Ressource_Id" });
            DropColumn("dbo.ClientRequestForms", "Duration");
            DropColumn("dbo.ClientRequestForms", "Experience");
            DropColumn("dbo.ClientRequestForms", "IdProject");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClientRequestForms", "IdProject", c => c.Int());
            AddColumn("dbo.ClientRequestForms", "Experience", c => c.String());
            AddColumn("dbo.ClientRequestForms", "Duration", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.ProjectRessources");
            DropColumn("dbo.ClientRequestForms", "Fees");
            AddPrimaryKey("dbo.ProjectRessources", new[] { "Ressource_Id", "Project_IdProject" });
            RenameColumn(table: "dbo.AspNetUsers", name: "Name1", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.AspNetUsers", name: "Name", newName: "Name1");
            RenameColumn(table: "dbo.AspNetUsers", name: "__mig_tmp__0", newName: "Name");
            CreateIndex("dbo.ClientRequestForms", "IdProject");
            AddForeignKey("dbo.ClientRequestForms", "IdProject", "dbo.Projects", "IdProject");
            RenameTable(name: "dbo.ProjectRessources", newName: "RessourceProjects");
        }
    }
}
