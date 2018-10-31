using Data;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    class Program
    {
        static void Main(string[] args)
        {
            MyContext ctx = new MyContext();

            Client c = new Client
            {
                Category = "category",
                Type = "type",
                Photo = "photo",
                IdClient = 123,
                

            };
            ctx.Clients.Add(c);
            ctx.SaveChanges();
            Console.WriteLine("Database Created");
            Console.ReadKey();

        }
    }
}
