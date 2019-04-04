using NorthWindDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindDb
{
    class Program
    {
        static void Main(string[] args)
        {
            /*AnotherContext c1 = new AnotherContext();
            AnotherContext c2 = new AnotherContext();
            var o1 = c1.AnotherOrderInfos.First();
            var o2 = c2.AnotherOrderInfos.First();
            o1.Quantity += 2;
            c1.SaveChanges();
            try
            {
                o2.Quantity += 2;
                c2.SaveChanges();
            }
            catch(Exception ex)
            {
                c2 = new AnotherContext();
                o2 = c2.AnotherOrderInfos.First();
                o2.Quantity += 2;
                c2.SaveChanges();
            }*/
            ApplicationDbContext applicationDbContext = new ApplicationDbContext();
            applicationDbContext.Database.CreateIfNotExists();
        }
    }
}
