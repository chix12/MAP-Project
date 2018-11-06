
using MapDomain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using static MapDomain.Entities.User;

namespace MapData
{
    public class MapContext : IdentityDbContext<User, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public MapContext() : base("Map")
        {
          
        }

        public static MapContext Create()
        {
            return new MapContext();
        }
        static MapContext()
        {
            Database.SetInitializer<MapContext>(null);
        }

        //public DbSet<User> User { get; set; }
      //  public DbSet<User> Users { get; set; }
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
        //public DbSet<RecruitementManager> RecruitementManagers { get; set; }
        // public DbSet<Ressource> Ressources { get; set; }
        public DbSet<RessourceForm> RessourceForms { get; set; }
        public DbSet<Vaccations> Vaccations { get; set; }
    }


    public class ContexInit : DropCreateDatabaseIfModelChanges<MapContext>
    {
        protected override void Seed(MapContext context)
        {
            /*   List<Patient> patients = new List<Patient>() {
                   new Patient {PatientId=1
                               }

               };
               context.Patients.AddRange(patients);
               context.SaveChanges();*/
        }
    }


}

