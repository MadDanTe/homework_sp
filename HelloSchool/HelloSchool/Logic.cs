using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloSchool
{
    class Logic : InterfaceLogic
    {
        public bool addProduct()
        {
            var product = new Product();
            Console.WriteLine("Введите название продукта");
            product.Name = Console.ReadLine();
            Console.WriteLine("Введите стоимость продукта");
            rp:
            int.TryParse(Console.ReadLine(), out var price);
            if(price==0)
            {
                Console.WriteLine("Стоимость продукта не была введена или она была введена с ошибкой. Пожалуйста, введите стоимость продукта ещё раз");
                goto rp;
            }
            product.Price = price;
            rssd:
            Console.WriteLine("Введите дату начала действия скидки");
            if(!DateTime.TryParse(Console.ReadLine(), out var startSellDate))
                goto rssd;


            return true;
        }
    }
}
