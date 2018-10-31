namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenerateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientRequestForms",
                c => new
                    {
                        IdForm = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Duration = c.Int(nullable: false),
                        Description = c.String(),
                        Requirements = c.String(),
                        ProfileNeeded = c.String(),
                        YearsOfExperience = c.Int(nullable: false),
                        Experience = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Client_IdClient = c.Int(),
                    })
                .PrimaryKey(t => t.IdForm)
                .ForeignKey("dbo.Clients", t => t.Client_IdClient)
                .Index(t => t.Client_IdClient);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        IdClient = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Category = c.String(),
                        Name = c.String(),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.IdClient);
            
            CreateTable(
                "dbo.Meetings",
                c => new
                    {
                        IdMeeting = c.Int(nullable: false, identity: true),
                        MeetingDate = c.DateTime(nullable: false),
                        Client_IdClient = c.Int(),
                        Ressource_IdRessource = c.Int(),
                        RecruitementManager_idManager = c.Int(),
                    })
                .PrimaryKey(t => t.IdMeeting)
                .ForeignKey("dbo.Clients", t => t.Client_IdClient)
                .ForeignKey("dbo.Ressources", t => t.Ressource_IdRessource)
                .ForeignKey("dbo.RecruitementManagers", t => t.RecruitementManager_idManager)
                .Index(t => t.Client_IdClient)
                .Index(t => t.Ressource_IdRessource)
                .Index(t => t.RecruitementManager_idManager);
            
            CreateTable(
                "dbo.Ressources",
                c => new
                    {
                        IdRessource = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Seniority = c.String(),
                        Status = c.String(),
                        Name = c.String(),
                        Specialty = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Profile_IdProfile = c.Int(),
                        Project_IdProject = c.Int(),
                        JobRequest_IdRequest = c.Int(),
                    })
                .PrimaryKey(t => t.IdRessource)
                .ForeignKey("dbo.Profiles", t => t.Profile_IdProfile)
                .ForeignKey("dbo.Projects", t => t.Project_IdProject)
                .ForeignKey("dbo.JobRequests", t => t.JobRequest_IdRequest)
                .Index(t => t.Profile_IdProfile)
                .Index(t => t.Project_IdProject)
                .Index(t => t.JobRequest_IdRequest);
            
            CreateTable(
                "dbo.Competences",
                c => new
                    {
                        IdCompetence = c.Int(nullable: false, identity: true),
                        CompetenceName = c.String(),
                        Rank = c.Int(nullable: false),
                        Ressource_IdRessource = c.Int(),
                        RessourceForm_IdForm = c.Int(),
                    })
                .PrimaryKey(t => t.IdCompetence)
                .ForeignKey("dbo.Ressources", t => t.Ressource_IdRessource)
                .ForeignKey("dbo.RessourceForms", t => t.RessourceForm_IdForm)
                .Index(t => t.Ressource_IdRessource)
                .Index(t => t.RessourceForm_IdForm);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        IdProfile = c.Int(nullable: false, identity: true),
                        ProfileName = c.String(),
                    })
                .PrimaryKey(t => t.IdProfile);
            
            CreateTable(
                "dbo.Vaccations",
                c => new
                    {
                        IdVaccation = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdVaccation);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        IdMessage = c.Int(nullable: false, identity: true),
                        Sender = c.String(),
                        Reciever = c.String(),
                        Type = c.String(),
                        Content = c.String(),
                        Client_IdClient = c.Int(),
                    })
                .PrimaryKey(t => t.IdMessage)
                .ForeignKey("dbo.Clients", t => t.Client_IdClient)
                .Index(t => t.Client_IdClient);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        IdProject = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Logo = c.String(),
                        Address = c.String(),
                        Client_IdClient = c.Int(),
                    })
                .PrimaryKey(t => t.IdProject)
                .ForeignKey("dbo.Clients", t => t.Client_IdClient)
                .Index(t => t.Client_IdClient);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        IdFile = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.IdFile);
            
            CreateTable(
                "dbo.JobRequests",
                c => new
                    {
                        IdRequest = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        RequestDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdRequest);
            
            CreateTable(
                "dbo.Mandats",
                c => new
                    {
                        MandatId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Ressource_IdRessource = c.Int(),
                    })
                .PrimaryKey(t => t.MandatId)
                .ForeignKey("dbo.Ressources", t => t.Ressource_IdRessource)
                .Index(t => t.Ressource_IdRessource);
            
            CreateTable(
                "dbo.OrganizationalCharts",
                c => new
                    {
                        IdChart = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.IdChart);
            
            CreateTable(
                "dbo.RecruitementManagers",
                c => new
                    {
                        idManager = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.idManager);
            
            CreateTable(
                "dbo.RessourceForms",
                c => new
                    {
                        IdForm = c.Int(nullable: false, identity: true),
                        RessourceFirstName = c.String(),
                        RessourceLastName = c.String(),
                    })
                .PrimaryKey(t => t.IdForm);
            
            CreateTable(
                "dbo.VaccationsRessources",
                c => new
                    {
                        Vaccations_IdVaccation = c.Int(nullable: false),
                        Ressource_IdRessource = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Vaccations_IdVaccation, t.Ressource_IdRessource })
                .ForeignKey("dbo.Vaccations", t => t.Vaccations_IdVaccation, cascadeDelete: true)
                .ForeignKey("dbo.Ressources", t => t.Ressource_IdRessource, cascadeDelete: true)
                .Index(t => t.Vaccations_IdVaccation)
                .Index(t => t.Ressource_IdRessource);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Competences", "RessourceForm_IdForm", "dbo.RessourceForms");
            DropForeignKey("dbo.Meetings", "RecruitementManager_idManager", "dbo.RecruitementManagers");
            DropForeignKey("dbo.Mandats", "Ressource_IdRessource", "dbo.Ressources");
            DropForeignKey("dbo.Ressources", "JobRequest_IdRequest", "dbo.JobRequests");
            DropForeignKey("dbo.Projects", "Client_IdClient", "dbo.Clients");
            DropForeignKey("dbo.Ressources", "Project_IdProject", "dbo.Projects");
            DropForeignKey("dbo.Messages", "Client_IdClient", "dbo.Clients");
            DropForeignKey("dbo.Meetings", "Ressource_IdRessource", "dbo.Ressources");
            DropForeignKey("dbo.VaccationsRessources", "Ressource_IdRessource", "dbo.Ressources");
            DropForeignKey("dbo.VaccationsRessources", "Vaccations_IdVaccation", "dbo.Vaccations");
            DropForeignKey("dbo.Ressources", "Profile_IdProfile", "dbo.Profiles");
            DropForeignKey("dbo.Competences", "Ressource_IdRessource", "dbo.Ressources");
            DropForeignKey("dbo.Meetings", "Client_IdClient", "dbo.Clients");
            DropForeignKey("dbo.ClientRequestForms", "Client_IdClient", "dbo.Clients");
            DropIndex("dbo.VaccationsRessources", new[] { "Ressource_IdRessource" });
            DropIndex("dbo.VaccationsRessources", new[] { "Vaccations_IdVaccation" });
            DropIndex("dbo.Mandats", new[] { "Ressource_IdRessource" });
            DropIndex("dbo.Projects", new[] { "Client_IdClient" });
            DropIndex("dbo.Messages", new[] { "Client_IdClient" });
            DropIndex("dbo.Competences", new[] { "RessourceForm_IdForm" });
            DropIndex("dbo.Competences", new[] { "Ressource_IdRessource" });
            DropIndex("dbo.Ressources", new[] { "JobRequest_IdRequest" });
            DropIndex("dbo.Ressources", new[] { "Project_IdProject" });
            DropIndex("dbo.Ressources", new[] { "Profile_IdProfile" });
            DropIndex("dbo.Meetings", new[] { "RecruitementManager_idManager" });
            DropIndex("dbo.Meetings", new[] { "Ressource_IdRessource" });
            DropIndex("dbo.Meetings", new[] { "Client_IdClient" });
            DropIndex("dbo.ClientRequestForms", new[] { "Client_IdClient" });
            DropTable("dbo.VaccationsRessources");
            DropTable("dbo.RessourceForms");
            DropTable("dbo.RecruitementManagers");
            DropTable("dbo.OrganizationalCharts");
            DropTable("dbo.Mandats");
            DropTable("dbo.JobRequests");
            DropTable("dbo.Files");
            DropTable("dbo.Projects");
            DropTable("dbo.Messages");
            DropTable("dbo.Vaccations");
            DropTable("dbo.Profiles");
            DropTable("dbo.Competences");
            DropTable("dbo.Ressources");
            DropTable("dbo.Meetings");
            DropTable("dbo.Clients");
            DropTable("dbo.ClientRequestForms");
        }
    }
}
