using MapDomain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapService
{
    class MandatService : Service<Mandat> , IServiceMandat
    {
        static IDatabaseFactory dbf = new DatabaseFactory();
        //IRepositoryBase<Product> rps = new RepositoryBase<Product>(dbf);
        static IUnitOfWork uow = new UnitOfWork(dbf);



        public MandatService():base(uow)
        {

        }

    } }
