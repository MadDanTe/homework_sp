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
            while (true)
            {
                Console.WriteLine("Вы хотите:" + "\n" + "1 - Добавить товар" + "\n" + "2 - Применить скидочную карту" + "\n" + "3 - Скидка по процентам" + "\n" + "4 - скидка на сумму" + "\n" + "5 - выход");
                if (!int.TryParse(Console.ReadLine(), out var ans))
                    System.Environment.Exit(0);
                Logic logic = new Logic();
                while (ans <= 0 || ans > 5)
                {
                    Console.WriteLine("Выбран некорректный вариант действий, выберите снова");
                    int.TryParse(Console.ReadLine(), out ans);
                }
                if (ans == 1)
                    logic.addProduct();
                if (ans == 2)
                    logic.getDiscountCard();
                if (ans == 3)
                    logic.getDiscountPercent();
                if (ans == 4)
                    logic.getDiscountPrice();
                if (ans >= 5)
                    System.Environment.Exit(0);
            }

        

        }
    }
}
