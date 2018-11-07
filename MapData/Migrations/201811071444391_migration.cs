namespace MapData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration : DbMigration
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
                        Client_idUser = c.Int(),
                    })
                .PrimaryKey(t => t.IdForm)
                .ForeignKey("dbo.AspNetUsers", t => t.Client_idUser)
                .ForeignKey("dbo.Projects", t => t.IdProject)
                .Index(t => t.IdProject)
                .Index(t => t.Client_idUser);
            
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
                .ForeignKey("dbo.AspNetUsers", t => t.IdClient)
                .ForeignKey("dbo.Mandats", t => t.IdMandat)
                .Index(t => t.IdMandat)
                .Index(t => t.IdClient);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        idUser = c.Int(nullable: false, identity: true),
                        UserType = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Type = c.String(),
                        Category = c.String(),
                        Name = c.String(),
                        Photo = c.String(),
                        Rating = c.Int(),
                        Seniority = c.String(),
                        Status = c.String(),
                        Name1 = c.String(),
                        IdProfile = c.Int(),
                        Specialty = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        JobRequest_IdRequest = c.Int(),
                    })
                .PrimaryKey(t => t.idUser)
                .ForeignKey("dbo.Profiles", t => t.IdProfile)
                .ForeignKey("dbo.JobRequests", t => t.JobRequest_IdRequest)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.IdProfile)
                .Index(t => t.JobRequest_IdRequest);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Meetings",
                c => new
                    {
                        IdMeeting = c.Int(nullable: false, identity: true),
                        MeetingDate = c.DateTime(nullable: false),
                        IdRessource = c.Int(),
                        IdClient = c.Int(),
                        IdAdministrator = c.Int(),
                    })
                .PrimaryKey(t => t.IdMeeting)
                .ForeignKey("dbo.AspNetUsers", t => t.IdAdministrator)
                .ForeignKey("dbo.AspNetUsers", t => t.IdClient)
                .ForeignKey("dbo.AspNetUsers", t => t.IdRessource)
                .Index(t => t.IdRessource)
                .Index(t => t.IdClient)
                .Index(t => t.IdAdministrator);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Competences",
                c => new
                    {
                        IdCompetence = c.Int(nullable: false, identity: true),
                        CompetenceName = c.String(),
                        Rank = c.Int(nullable: false),
                        Ressource_idUser = c.Int(),
                    })
                .PrimaryKey(t => t.IdCompetence)
                .ForeignKey("dbo.AspNetUsers", t => t.Ressource_idUser)
                .Index(t => t.Ressource_idUser);
            
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
                .ForeignKey("dbo.AspNetUsers", t => t.IdClient)
                .ForeignKey("dbo.AspNetUsers", t => t.IdRessource)
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
                        Ressource_idUser = c.Int(),
                    })
                .PrimaryKey(t => t.MandatId)
                .ForeignKey("dbo.AspNetUsers", t => t.Ressource_idUser)
                .Index(t => t.Ressource_idUser);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        IdFile = c.Int(nullable: false, identity: true),
                        IdRessource = c.Int(),
                    })
                .PrimaryKey(t => t.IdFile)
                .ForeignKey("dbo.AspNetUsers", t => t.IdRessource)
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
                .ForeignKey("dbo.AspNetUsers", t => t.IdClient)
                .ForeignKey("dbo.Projects", t => t.IdProject)
                .ForeignKey("dbo.AspNetUsers", t => t.IdRessource)
                .Index(t => t.IdRessource)
                .Index(t => t.IdClient)
                .Index(t => t.IdProject);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
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
                        Ressource_idUser = c.Int(nullable: false),
                        Project_IdProject = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ressource_idUser, t.Project_IdProject })
                .ForeignKey("dbo.AspNetUsers", t => t.Ressource_idUser, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.Project_IdProject, cascadeDelete: true)
                .Index(t => t.Ressource_idUser)
                .Index(t => t.Project_IdProject);
            
            CreateTable(
                "dbo.VaccationsRessources",
                c => new
                    {
                        Vaccations_IdVaccation = c.Int(nullable: false),
                        Ressource_idUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Vaccations_IdVaccation, t.Ressource_idUser })
                .ForeignKey("dbo.Vaccations", t => t.Vaccations_IdVaccation, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Ressource_idUser, cascadeDelete: true)
                .Index(t => t.Vaccations_IdVaccation)
                .Index(t => t.Ressource_idUser);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.OrganizationalCharts", "IdRessource", "dbo.AspNetUsers");
            DropForeignKey("dbo.OrganizationalCharts", "IdProject", "dbo.Projects");
            DropForeignKey("dbo.OrganizationalCharts", "IdClient", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "JobRequest_IdRequest", "dbo.JobRequests");
            DropForeignKey("dbo.Files", "IdRessource", "dbo.AspNetUsers");
            DropForeignKey("dbo.ClientRequestForms", "IdProject", "dbo.Projects");
            DropForeignKey("dbo.Projects", "IdMandat", "dbo.Mandats");
            DropForeignKey("dbo.Mandats", "Ressource_idUser", "dbo.AspNetUsers");
            DropForeignKey("dbo.Projects", "IdClient", "dbo.AspNetUsers");
            DropForeignKey("dbo.Meetings", "IdRessource", "dbo.AspNetUsers");
            DropForeignKey("dbo.VaccationsRessources", "Ressource_idUser", "dbo.AspNetUsers");
            DropForeignKey("dbo.VaccationsRessources", "Vaccations_IdVaccation", "dbo.Vaccations");
            DropForeignKey("dbo.RessourceProjects", "Project_IdProject", "dbo.Projects");
            DropForeignKey("dbo.RessourceProjects", "Ressource_idUser", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "IdProfile", "dbo.Profiles");
            DropForeignKey("dbo.Messages", "IdRessource", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "IdClient", "dbo.AspNetUsers");
            DropForeignKey("dbo.Competences", "Ressource_idUser", "dbo.AspNetUsers");
            DropForeignKey("dbo.RessourceFormCompetences", "Competence_IdCompetence", "dbo.Competences");
            DropForeignKey("dbo.RessourceFormCompetences", "RessourceForm_IdForm", "dbo.RessourceForms");
            DropForeignKey("dbo.Meetings", "IdClient", "dbo.AspNetUsers");
            DropForeignKey("dbo.Meetings", "IdAdministrator", "dbo.AspNetUsers");
            DropForeignKey("dbo.ClientRequestForms", "Client_idUser", "dbo.AspNetUsers");
            DropIndex("dbo.VaccationsRessources", new[] { "Ressource_idUser" });
            DropIndex("dbo.VaccationsRessources", new[] { "Vaccations_IdVaccation" });
            DropIndex("dbo.RessourceProjects", new[] { "Project_IdProject" });
            DropIndex("dbo.RessourceProjects", new[] { "Ressource_idUser" });
            DropIndex("dbo.RessourceFormCompetences", new[] { "Competence_IdCompetence" });
            DropIndex("dbo.RessourceFormCompetences", new[] { "RessourceForm_IdForm" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.OrganizationalCharts", new[] { "IdProject" });
            DropIndex("dbo.OrganizationalCharts", new[] { "IdClient" });
            DropIndex("dbo.OrganizationalCharts", new[] { "IdRessource" });
            DropIndex("dbo.Files", new[] { "IdRessource" });
            DropIndex("dbo.Mandats", new[] { "Ressource_idUser" });
            DropIndex("dbo.Messages", new[] { "IdRessource" });
            DropIndex("dbo.Messages", new[] { "IdClient" });
            DropIndex("dbo.Competences", new[] { "Ressource_idUser" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Meetings", new[] { "IdAdministrator" });
            DropIndex("dbo.Meetings", new[] { "IdClient" });
            DropIndex("dbo.Meetings", new[] { "IdRessource" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "JobRequest_IdRequest" });
            DropIndex("dbo.AspNetUsers", new[] { "IdProfile" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Projects", new[] { "IdClient" });
            DropIndex("dbo.Projects", new[] { "IdMandat" });
            DropIndex("dbo.ClientRequestForms", new[] { "Client_idUser" });
            DropIndex("dbo.ClientRequestForms", new[] { "IdProject" });
            DropTable("dbo.VaccationsRessources");
            DropTable("dbo.RessourceProjects");
            DropTable("dbo.RessourceFormCompetences");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.OrganizationalCharts");
            DropTable("dbo.JobRequests");
            DropTable("dbo.Files");
            DropTable("dbo.Mandats");
            DropTable("dbo.Vaccations");
            DropTable("dbo.Profiles");
            DropTable("dbo.Messages");
            DropTable("dbo.RessourceForms");
            DropTable("dbo.Competences");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Meetings");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Projects");
            DropTable("dbo.ClientRequestForms");
        }
    }
}
