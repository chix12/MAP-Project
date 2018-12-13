using MapDomain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFinance.Data.Infrastructure;
using Infrastructure;
using Data.Infrastructure;

namespace MapService
{
    public class ServiceQuestion : Service<Question>, IServiceQuestion
    {
        // MyfinanctCtx ctx = new MyfinanctCtx();
        static IDatabaseFactory dbf = new DatabaseFactory();
        // IRepositoryBase<Product> repo = new RepositoryBase<Product>(dbf);
        static IUnitOfWork uow = new UnitOfWork(dbf);
        public ServiceQuestion() : base(uow)
        {
        }
    }
}
