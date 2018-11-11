using Data.Infrastructure;
using Infrastructure;
using MapDomain.Entities;
using MyFinance.Data.Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapService
{
    public class RequestsService : Service<ClientRequestForm>, IRequestsService
    {
        static IDatabaseFactory dbf = new DatabaseFactory();
        static IUnitOfWork uow = new UnitOfWork(dbf);

        public RequestsService() : base(uow)
        {
                
        }

       
    }
}
