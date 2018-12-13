using MapDomain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFinance.Data.Infrastructure;
using MapData;
using Data.Infrastructure;

namespace MapService
{
    public class ServiceDemandeur : Service<Demandeur>, IServiceDemandeur
    {
        
        static DatabaseFactory dbf = new DatabaseFactory();
        static UnitOfWork uow = new UnitOfWork(dbf);
        public ServiceDemandeur() : base(uow)
        {
        }
    }
}
