using System;
using System.Collections.Generic;
using System.Linq;
using WebSchool.Models;
using System.Threading.Tasks;

namespace WebSchool.Data
{
    public class DbStartData
    {
        public static void Initialize(WebSchoolContext context)
        {
            if (context.Customers.Any())
                return;
            var customers = new Customer[]
            {
                new Customer{ Name="Инокентий", Age=24, Sex="Male", Budget=25000 },
                new Customer{ Name="Акакий", Age=30, Sex="Male", Budget=14000 },
                new Customer{ Name="Галина", Age=22, Sex="Female", Budget=9000 },
                new Customer{ Name="Александрина", Age=31, Sex="Female", Budget=31000 },
                new Customer{ Name="Виктор", Age=37, Sex="Male", Budget=21000}
            };

            foreach (var c in customers)
                context.Customers.Add(c);

            var products = new Product[]
            {
                new Product{ Name="Соль", Price=1000 },
                new Product{ Name="Сахар", Price=4000 },
                new Product{ Name="Мёд", Price=14000 },
                new Product{ Name="Хмель", Price=24000 },
                new Product{ Name="Хлеб", Price=20000 },
                new Product{ Name="Мука", Price=400 },
                new Product{ Name="Сода", Price=16000 },
                new Product{ Name="Кари", Price=30000 },
            };

            foreach (var p in products)
                context.Products.Add(p);

            context.SaveChanges();


        }
    }
}
