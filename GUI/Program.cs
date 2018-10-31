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

            Console.WriteLine("Database Created");
            Console.ReadKey();

        }
    }
}
