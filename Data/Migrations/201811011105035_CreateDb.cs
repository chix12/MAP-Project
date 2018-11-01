namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDb : DbMigration
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
                        IdProject = c.Int(),
                        Client_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.IdForm)
                .ForeignKey("dbo.Users", t => t.Client_UserId)
                .ForeignKey("dbo.Projects", t => t.IdProject)
                .Index(t => t.IdProject)
                .Index(t => t.Client_UserId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        IdProject = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Logo = c.String(),
                        Address = c.String(),
                        IdMandat = c.Int(),
                        IdClient = c.Int(),
                    })
                .PrimaryKey(t => t.IdProject)
                .ForeignKey("dbo.Users", t => t.IdClient)
                .ForeignKey("dbo.Mandats", t => t.IdMandat)
                .Index(t => t.IdMandat)
                .Index(t => t.IdClient);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        Id = c.String(),
                        UserName = c.String(),
                        IdClient = c.Int(),
                        Type = c.String(),
                        Category = c.String(),
                        Name = c.String(),
                        Photo = c.String(),
                        IdManager = c.Int(),
                        IdRessource = c.Int(),
                        Rating = c.Int(),
                        Seniority = c.String(),
                        Status = c.String(),
                        Name1 = c.String(),
                        IdProfile = c.Int(),
                        Specialty = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        JobRequest_IdRequest = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Profiles", t => t.IdProfile)
                .ForeignKey("dbo.JobRequests", t => t.JobRequest_IdRequest)
                .Index(t => t.IdProfile)
                .Index(t => t.JobRequest_IdRequest);
            
            CreateTable(
                "dbo.Claims",
                c => new
                    {
                        idClaim = c.Int(nullable: false, identity: true),
                        Id = c.Int(nullable: false),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.idClaim)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        idLogin = c.Int(nullable: false, identity: true),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        UserId = c.String(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.idLogin)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Meetings",
                c => new
                    {
                        IdMeeting = c.Int(nullable: false, identity: true),
                        MeetingDate = c.DateTime(nullable: false),
                        IdRessource = c.Int(),
                        IdClient = c.Int(),
                        IdManager = c.Int(),
                    })
                .PrimaryKey(t => t.IdMeeting)
                .ForeignKey("dbo.Users", t => t.IdClient)
                .ForeignKey("dbo.Users", t => t.IdManager)
                .ForeignKey("dbo.Users", t => t.IdRessource)
                .Index(t => t.IdRessource)
                .Index(t => t.IdClient)
                .Index(t => t.IdManager);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        idRole = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        RoleId = c.String(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.idRole)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Competences",
                c => new
                    {
                        IdCompetence = c.Int(nullable: false, identity: true),
                        CompetenceName = c.String(),
                        Rank = c.Int(nullable: false),
                        Ressource_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.IdCompetence)
                .ForeignKey("dbo.Users", t => t.Ressource_UserId)
                .Index(t => t.Ressource_UserId);
            
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
                "dbo.Messages",
                c => new
                    {
                        IdMessage = c.Int(nullable: false, identity: true),
                        Sender = c.String(),
                        Reciever = c.String(),
                        Type = c.String(),
                        Content = c.String(),
                        IdClient = c.Int(),
                        IdRessource = c.Int(),
                    })
                .PrimaryKey(t => t.IdMessage)
                .ForeignKey("dbo.Users", t => t.IdClient)
                .ForeignKey("dbo.Users", t => t.IdRessource)
                .Index(t => t.IdClient)
                .Index(t => t.IdRessource);
            
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
                "dbo.Mandats",
                c => new
                    {
                        MandatId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Ressource_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.MandatId)
                .ForeignKey("dbo.Users", t => t.Ressource_UserId)
                .Index(t => t.Ressource_UserId);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        IdFile = c.Int(nullable: false, identity: true),
                        IdRessource = c.Int(),
                    })
                .PrimaryKey(t => t.IdFile)
                .ForeignKey("dbo.Users", t => t.IdRessource)
                .Index(t => t.IdRessource);
            
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
                "dbo.OrganizationalCharts",
                c => new
                    {
                        IdChart = c.Int(nullable: false, identity: true),
                        IdRessource = c.Int(),
                        IdClient = c.Int(),
                        IdProject = c.Int(),
                    })
                .PrimaryKey(t => t.IdChart)
                .ForeignKey("dbo.Users", t => t.IdClient)
                .ForeignKey("dbo.Projects", t => t.IdProject)
                .ForeignKey("dbo.Users", t => t.IdRessource)
                .Index(t => t.IdRessource)
                .Index(t => t.IdClient)
                .Index(t => t.IdProject);
            
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
                        Ressource_UserId = c.Int(nullable: false),
                        Project_IdProject = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ressource_UserId, t.Project_IdProject })
                .ForeignKey("dbo.Users", t => t.Ressource_UserId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.Project_IdProject, cascadeDelete: true)
                .Index(t => t.Ressource_UserId)
                .Index(t => t.Project_IdProject);
            
            CreateTable(
                "dbo.VaccationsRessources",
                c => new
                    {
                        Vaccations_IdVaccation = c.Int(nullable: false),
                        Ressource_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Vaccations_IdVaccation, t.Ressource_UserId })
                .ForeignKey("dbo.Vaccations", t => t.Vaccations_IdVaccation, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Ressource_UserId, cascadeDelete: true)
                .Index(t => t.Vaccations_IdVaccation)
                .Index(t => t.Ressource_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Roles", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Logins", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Claims", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.OrganizationalCharts", "IdRessource", "dbo.Users");
            DropForeignKey("dbo.OrganizationalCharts", "IdProject", "dbo.Projects");
            DropForeignKey("dbo.OrganizationalCharts", "IdClient", "dbo.Users");
            DropForeignKey("dbo.Users", "JobRequest_IdRequest", "dbo.JobRequests");
            DropForeignKey("dbo.Files", "IdRessource", "dbo.Users");
            DropForeignKey("dbo.ClientRequestForms", "IdProject", "dbo.Projects");
            DropForeignKey("dbo.Projects", "IdMandat", "dbo.Mandats");
            DropForeignKey("dbo.Mandats", "Ressource_UserId", "dbo.Users");
            DropForeignKey("dbo.Projects", "IdClient", "dbo.Users");
            DropForeignKey("dbo.VaccationsRessources", "Ressource_UserId", "dbo.Users");
            DropForeignKey("dbo.VaccationsRessources", "Vaccations_IdVaccation", "dbo.Vaccations");
            DropForeignKey("dbo.RessourceProjects", "Project_IdProject", "dbo.Projects");
            DropForeignKey("dbo.RessourceProjects", "Ressource_UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "IdProfile", "dbo.Profiles");
            DropForeignKey("dbo.Messages", "IdRessource", "dbo.Users");
            DropForeignKey("dbo.Messages", "IdClient", "dbo.Users");
            DropForeignKey("dbo.Meetings", "IdRessource", "dbo.Users");
            DropForeignKey("dbo.Competences", "Ressource_UserId", "dbo.Users");
            DropForeignKey("dbo.RessourceFormCompetences", "Competence_IdCompetence", "dbo.Competences");
            DropForeignKey("dbo.RessourceFormCompetences", "RessourceForm_IdForm", "dbo.RessourceForms");
            DropForeignKey("dbo.Meetings", "IdManager", "dbo.Users");
            DropForeignKey("dbo.Meetings", "IdClient", "dbo.Users");
            DropForeignKey("dbo.ClientRequestForms", "Client_UserId", "dbo.Users");
            DropIndex("dbo.VaccationsRessources", new[] { "Ressource_UserId" });
            DropIndex("dbo.VaccationsRessources", new[] { "Vaccations_IdVaccation" });
            DropIndex("dbo.RessourceProjects", new[] { "Project_IdProject" });
            DropIndex("dbo.RessourceProjects", new[] { "Ressource_UserId" });
            DropIndex("dbo.RessourceFormCompetences", new[] { "Competence_IdCompetence" });
            DropIndex("dbo.RessourceFormCompetences", new[] { "RessourceForm_IdForm" });
            DropIndex("dbo.OrganizationalCharts", new[] { "IdProject" });
            DropIndex("dbo.OrganizationalCharts", new[] { "IdClient" });
            DropIndex("dbo.OrganizationalCharts", new[] { "IdRessource" });
            DropIndex("dbo.Files", new[] { "IdRessource" });
            DropIndex("dbo.Mandats", new[] { "Ressource_UserId" });
            DropIndex("dbo.Messages", new[] { "IdRessource" });
            DropIndex("dbo.Messages", new[] { "IdClient" });
            DropIndex("dbo.Competences", new[] { "Ressource_UserId" });
            DropIndex("dbo.Roles", new[] { "User_UserId" });
            DropIndex("dbo.Meetings", new[] { "IdManager" });
            DropIndex("dbo.Meetings", new[] { "IdClient" });
            DropIndex("dbo.Meetings", new[] { "IdRessource" });
            DropIndex("dbo.Logins", new[] { "User_UserId" });
            DropIndex("dbo.Claims", new[] { "User_UserId" });
            DropIndex("dbo.Users", new[] { "JobRequest_IdRequest" });
            DropIndex("dbo.Users", new[] { "IdProfile" });
            DropIndex("dbo.Projects", new[] { "IdClient" });
            DropIndex("dbo.Projects", new[] { "IdMandat" });
            DropIndex("dbo.ClientRequestForms", new[] { "Client_UserId" });
            DropIndex("dbo.ClientRequestForms", new[] { "IdProject" });
            DropTable("dbo.VaccationsRessources");
            DropTable("dbo.RessourceProjects");
            DropTable("dbo.RessourceFormCompetences");
            DropTable("dbo.OrganizationalCharts");
            DropTable("dbo.JobRequests");
            DropTable("dbo.Files");
            DropTable("dbo.Mandats");
            DropTable("dbo.Vaccations");
            DropTable("dbo.Profiles");
            DropTable("dbo.Messages");
            DropTable("dbo.RessourceForms");
            DropTable("dbo.Competences");
            DropTable("dbo.Roles");
            DropTable("dbo.Meetings");
            DropTable("dbo.Logins");
            DropTable("dbo.Claims");
            DropTable("dbo.Users");
            DropTable("dbo.Projects");
            DropTable("dbo.ClientRequestForms");
        }
    }
}
