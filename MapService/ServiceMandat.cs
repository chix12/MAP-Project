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
    public class ServiceMandat : Service<Mandat>, IServiceMandat
    {
        // MyfinanctCtx ctx = new MyfinanctCtx();
        static IDatabaseFactory dbf = new DatabaseFactory();
        // IRepositoryBase<Product> repo = new RepositoryBase<Product>(dbf);
        static IUnitOfWork uow = new UnitOfWork(dbf);


        public IEnumerable<Mandat> GetMandat()
        {
            var req = from p in GetMany()

                      select p;
            return req;

        }
        public ServiceMandat() : base(uow)
        {

        }
        //* public void Add(Mandat p)
        // {
             // ctx.Products.Add(p);
             //dbf.DataContext.Products.Add(p);
             //repo.Add(p);
          //   uow.getRepository<Mandat>().Add(p);
         //}

        //public new void Commit()
        //{
            //dbf.DataContext.SaveChanges();
            //  ctx.SaveChanges();
          //  uow.Commit();
        //}
    }
   
}
    

