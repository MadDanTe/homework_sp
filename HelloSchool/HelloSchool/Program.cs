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
            Console.WriteLine("Вы хотите:"+"/n"+" 1 - Добавить товар"+"/n"+" 2 - Применить скидку"+"/n"+"3 - Выход");
            int.TryParse(Console.ReadLine(), out var ans);
            switch(ans)
            {
                case 1:
                    ;
            }
        }
    }
}
