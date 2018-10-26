using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            start:
            Console.WriteLine("Вы хотите:"+"\n"+"1 - Добавить товар"+"\n"+"2 - Применить скидочную карту"+"\n"+"3 - Скидка по процентам" +"\n"+ "4 - скидка на сумму"+"\n"+"5 - выход");
            if(!int.TryParse(Console.ReadLine(), out var ans))
                System.Environment.Exit(0);
            Logic logic = new Logic();
            switch (ans)
            {
                case 1:
                    logic.addProduct();
                    goto start;
                case 2:
                    logic.getDiscountCard();
                    goto start;
                case 3:
                    logic.getDiscountPercent();
                    goto start;
                case 4:
                    logic.getDiscountPrice();
                    goto start;
                case 5:
                    System.Environment.Exit(0);
                    break;
                default:
                    System.Environment.Exit(0);
                    break;

            }
        }
    }
}
