namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WithForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ressources", "Project_IdProject", "dbo.Projects");
            DropForeignKey("dbo.Competences", "RessourceForm_IdForm", "dbo.RessourceForms");
            DropIndex("dbo.Ressources", new[] { "Project_IdProject" });
            DropIndex("dbo.Competences", new[] { "RessourceForm_IdForm" });
            RenameColumn(table: "dbo.Meetings", name: "Client_IdClient", newName: "IdClient");
            RenameColumn(table: "dbo.Messages", name: "Client_IdClient", newName: "IdClient");
            RenameColumn(table: "dbo.Projects", name: "Client_IdClient", newName: "IdClient");
            RenameColumn(table: "dbo.Meetings", name: "Ressource_IdRessource", newName: "IdRessource");
            RenameColumn(table: "dbo.Ressources", name: "Profile_IdProfile", newName: "IdProfile");
            RenameColumn(table: "dbo.Meetings", name: "RecruitementManager_idManager", newName: "IdManager");
            RenameIndex(table: "dbo.Projects", name: "IX_Client_IdClient", newName: "IX_IdClient");
            RenameIndex(table: "dbo.Meetings", name: "IX_Ressource_IdRessource", newName: "IX_IdRessource");
            RenameIndex(table: "dbo.Meetings", name: "IX_Client_IdClient", newName: "IX_IdClient");
            RenameIndex(table: "dbo.Meetings", name: "IX_RecruitementManager_idManager", newName: "IX_IdManager");
            RenameIndex(table: "dbo.Ressources", name: "IX_Profile_IdProfile", newName: "IX_IdProfile");
            RenameIndex(table: "dbo.Messages", name: "IX_Client_IdClient", newName: "IX_IdClient");
            CreateTable(
                "dbo.RessourceFormCompetences",
                c => new
                    {
                        RessourceForm_IdForm = c.Int(nullable: false),
                        Competence_IdCompetence = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RessourceForm_IdForm, t.Competence_IdCompetence })
                .ForeignKey("dbo.RessourceForms", t => t.RessourceForm_IdForm, cascadeDelete: true)
                .ForeignKey("dbo.Competences", t => t.Competence_IdCompetence, cascadeDelete: true)
                .Index(t => t.RessourceForm_IdForm)
                .Index(t => t.Competence_IdCompetence);
            
            CreateTable(
                "dbo.RessourceProjects",
                c => new
                    {
                        Ressource_IdRessource = c.Int(nullable: false),
                        Project_IdProject = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ressource_IdRessource, t.Project_IdProject })
                .ForeignKey("dbo.Ressources", t => t.Ressource_IdRessource, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.Project_IdProject, cascadeDelete: true)
                .Index(t => t.Ressource_IdRessource)
                .Index(t => t.Project_IdProject);
            
            AddColumn("dbo.ClientRequestForms", "IdProject", c => c.Int());
            AddColumn("dbo.Messages", "IdRessource", c => c.Int());
            AddColumn("dbo.Projects", "IdMandat", c => c.Int());
            AddColumn("dbo.Files", "IdRessource", c => c.Int());
            AddColumn("dbo.OrganizationalCharts", "IdRessource", c => c.Int());
            AddColumn("dbo.OrganizationalCharts", "IdClient", c => c.Int());
            AddColumn("dbo.OrganizationalCharts", "IdProject", c => c.Int());
            CreateIndex("dbo.ClientRequestForms", "IdProject");
            CreateIndex("dbo.Projects", "IdMandat");
            CreateIndex("dbo.Messages", "IdRessource");
            CreateIndex("dbo.Files", "IdRessource");
            CreateIndex("dbo.OrganizationalCharts", "IdRessource");
            CreateIndex("dbo.OrganizationalCharts", "IdClient");
            CreateIndex("dbo.OrganizationalCharts", "IdProject");
            AddForeignKey("dbo.Messages", "IdRessource", "dbo.Ressources", "IdRessource");
            AddForeignKey("dbo.Projects", "IdMandat", "dbo.Mandats", "MandatId");
            AddForeignKey("dbo.ClientRequestForms", "IdProject", "dbo.Projects", "IdProject");
            AddForeignKey("dbo.Files", "IdRessource", "dbo.Ressources", "IdRessource");
            AddForeignKey("dbo.OrganizationalCharts", "IdClient", "dbo.Clients", "IdClient");
            AddForeignKey("dbo.OrganizationalCharts", "IdProject", "dbo.Projects", "IdProject");
            AddForeignKey("dbo.OrganizationalCharts", "IdRessource", "dbo.Ressources", "IdRessource");
            DropColumn("dbo.Ressources", "Project_IdProject");
            DropColumn("dbo.Competences", "RessourceForm_IdForm");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Competences", "RessourceForm_IdForm", c => c.Int());
            AddColumn("dbo.Ressources", "Project_IdProject", c => c.Int());
            DropForeignKey("dbo.OrganizationalCharts", "IdRessource", "dbo.Ressources");
            DropForeignKey("dbo.OrganizationalCharts", "IdProject", "dbo.Projects");
            DropForeignKey("dbo.OrganizationalCharts", "IdClient", "dbo.Clients");
            DropForeignKey("dbo.Files", "IdRessource", "dbo.Ressources");
            DropForeignKey("dbo.ClientRequestForms", "IdProject", "dbo.Projects");
            DropForeignKey("dbo.Projects", "IdMandat", "dbo.Mandats");
            DropForeignKey("dbo.RessourceProjects", "Project_IdProject", "dbo.Projects");
            DropForeignKey("dbo.RessourceProjects", "Ressource_IdRessource", "dbo.Ressources");
            DropForeignKey("dbo.Messages", "IdRessource", "dbo.Ressources");
            DropForeignKey("dbo.RessourceFormCompetences", "Competence_IdCompetence", "dbo.Competences");
            DropForeignKey("dbo.RessourceFormCompetences", "RessourceForm_IdForm", "dbo.RessourceForms");
            DropIndex("dbo.RessourceProjects", new[] { "Project_IdProject" });
            DropIndex("dbo.RessourceProjects", new[] { "Ressource_IdRessource" });
            DropIndex("dbo.RessourceFormCompetences", new[] { "Competence_IdCompetence" });
            DropIndex("dbo.RessourceFormCompetences", new[] { "RessourceForm_IdForm" });
            DropIndex("dbo.OrganizationalCharts", new[] { "IdProject" });
            DropIndex("dbo.OrganizationalCharts", new[] { "IdClient" });
            DropIndex("dbo.OrganizationalCharts", new[] { "IdRessource" });
            DropIndex("dbo.Files", new[] { "IdRessource" });
            DropIndex("dbo.Messages", new[] { "IdRessource" });
            DropIndex("dbo.Projects", new[] { "IdMandat" });
            DropIndex("dbo.ClientRequestForms", new[] { "IdProject" });
            DropColumn("dbo.OrganizationalCharts", "IdProject");
            DropColumn("dbo.OrganizationalCharts", "IdClient");
            DropColumn("dbo.OrganizationalCharts", "IdRessource");
            DropColumn("dbo.Files", "IdRessource");
            DropColumn("dbo.Projects", "IdMandat");
            DropColumn("dbo.Messages", "IdRessource");
            DropColumn("dbo.ClientRequestForms", "IdProject");
            DropTable("dbo.RessourceProjects");
            DropTable("dbo.RessourceFormCompetences");
            RenameIndex(table: "dbo.Messages", name: "IX_IdClient", newName: "IX_Client_IdClient");
            RenameIndex(table: "dbo.Ressources", name: "IX_IdProfile", newName: "IX_Profile_IdProfile");
            RenameIndex(table: "dbo.Meetings", name: "IX_IdManager", newName: "IX_RecruitementManager_idManager");
            RenameIndex(table: "dbo.Meetings", name: "IX_IdClient", newName: "IX_Client_IdClient");
            RenameIndex(table: "dbo.Meetings", name: "IX_IdRessource", newName: "IX_Ressource_IdRessource");
            RenameIndex(table: "dbo.Projects", name: "IX_IdClient", newName: "IX_Client_IdClient");
            RenameColumn(table: "dbo.Meetings", name: "IdManager", newName: "RecruitementManager_idManager");
            RenameColumn(table: "dbo.Ressources", name: "IdProfile", newName: "Profile_IdProfile");
            RenameColumn(table: "dbo.Meetings", name: "IdRessource", newName: "Ressource_IdRessource");
            RenameColumn(table: "dbo.Projects", name: "IdClient", newName: "Client_IdClient");
            RenameColumn(table: "dbo.Messages", name: "IdClient", newName: "Client_IdClient");
            RenameColumn(table: "dbo.Meetings", name: "IdClient", newName: "Client_IdClient");
            CreateIndex("dbo.Competences", "RessourceForm_IdForm");
            CreateIndex("dbo.Ressources", "Project_IdProject");
            AddForeignKey("dbo.Competences", "RessourceForm_IdForm", "dbo.RessourceForms", "IdForm");
            AddForeignKey("dbo.Ressources", "Project_IdProject", "dbo.Projects", "IdProject");
        }
    }
}
