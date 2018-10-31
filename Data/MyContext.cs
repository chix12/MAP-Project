using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MyContext : DbContext
    {
        public MyContext() : base ("Name=Alias")
        {

        }
        public DbSet <Client> Clients { get; set; }
        public DbSet<ClientRequestForm> ClientRequestForms { get; set; }
        public DbSet<Competence> Competences { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<JobRequest> JobRequests { get; set; }
        public DbSet<Mandat> Mandats { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<OrganizationalChart> OrganizationalCharts { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<RecruitementManager> RecruitementManagers { get; set; }
        public DbSet<Ressource> Ressources { get; set; }
        public DbSet<RessourceForm> RessourceForms { get; set; }
        public DbSet<Vaccations> Vaccations { get; set; }
    }

}
