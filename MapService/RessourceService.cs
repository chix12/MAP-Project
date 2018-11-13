using Data.Infrastructure;
using MapData;
using MapDomain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFinance.Data.Infrastructure;

namespace MapService
{
   public class RessourceService: Service<Ressource>
        {
            MapContext ctx = new MapContext();
            static DatabaseFactory dbf = new DatabaseFactory();
            static UnitOfWork uow = new UnitOfWork(dbf);

        public RessourceService() : base(uow)
        {
        }
        public IEnumerable<Ressource> GetRessource()
        {
            var req = from p in GetMany()

                      select p;
            return req;

        }
    


    }
}
