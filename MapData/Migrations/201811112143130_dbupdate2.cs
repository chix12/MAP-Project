namespace MapData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbupdate2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProjectRessources", newName: "RessourceProjects");
            RenameColumn(table: "dbo.AspNetUsers", name: "Name", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.AspNetUsers", name: "Name1", newName: "Name");
            RenameColumn(table: "dbo.AspNetUsers", name: "__mig_tmp__0", newName: "Name1");
            DropPrimaryKey("dbo.RessourceProjects");
            AddColumn("dbo.ClientRequestForms", "IdProject", c => c.Int());
            AddPrimaryKey("dbo.RessourceProjects", new[] { "Ressource_Id", "Project_IdProject" });
            CreateIndex("dbo.ClientRequestForms", "IdProject");
            AddForeignKey("dbo.ClientRequestForms", "IdProject", "dbo.Projects", "IdProject");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientRequestForms", "IdProject", "dbo.Projects");
            DropIndex("dbo.ClientRequestForms", new[] { "IdProject" });
            DropPrimaryKey("dbo.RessourceProjects");
            DropColumn("dbo.ClientRequestForms", "IdProject");
            AddPrimaryKey("dbo.RessourceProjects", new[] { "Project_IdProject", "Ressource_Id" });
            RenameColumn(table: "dbo.AspNetUsers", name: "Name1", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.AspNetUsers", name: "Name", newName: "Name1");
            RenameColumn(table: "dbo.AspNetUsers", name: "__mig_tmp__0", newName: "Name");
            RenameTable(name: "dbo.RessourceProjects", newName: "ProjectRessources");
        }
    }
}
