using Data.Infrastructure;
using MapData;
using MapDomain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapService
{
   public class ServiceUsers: Service<User> , IServiceUsers
    {
        MapContext ctx = new MapContext();
        static DatabaseFactory dbf = new DatabaseFactory();
        static UnitOfWork uow = new UnitOfWork(dbf);

        public ServiceUsers() : base(uow)
        {
        }

        public IEnumerable<User> UserByUserName(string m)
        { //{
          //    var ListProject = uow.getRepository<Project>().
          //         GetMany().
          //         Where(Project => Project.Mandat== m);
          //    var ListRessource = uow.getRepository<Ressource>().
          //        GetMany().
          //        Where(m.Ressource = Ressource);


            var req = from User in GetMany()
                      where User.UserName == m
                      select User;
            return req;

            //var req = from Project in ListProject
            //          select Project.Ressources;

            //return req;
        }
    }
}
