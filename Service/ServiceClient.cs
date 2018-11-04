using Data.Infrastructure;
using Domain.Entities;
using Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceClient : Service<Client>// , IServiceClient
    {
        static IDatabaseFactory dbf = new DatabaseFactory();
        static IUnitOfWork uow = new UnitOfWork(dbf);

        public ServiceClient() : base(uow)
        {
        }
    }
}
