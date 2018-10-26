using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloSchool
{
    class Logic : InterfaceLogic
    {
        static List<Product> allProducts = new List<Product>();

        public void addProduct()
        {
            var product = new Product();
            DateTime startSellDate;
            DateTime endSellDate;
            Console.WriteLine("Введите название продукта");
            product.Name = Console.ReadLine();
            Console.WriteLine("Введите стоимость продукта");
            int.TryParse(Console.ReadLine(), out var price);
            while(price<=0 )
            {
                Console.WriteLine("Стоимость продукта не была введена или она была введена с ошибкой. Пожалуйста, введите стоимость продукта ещё раз");
                int.TryParse(Console.ReadLine(), out price);
            }
            product.Price = price;

            Console.WriteLine("Введите дату начала продажи");
            while(!DateTime.TryParse(Console.ReadLine(), out startSellDate))
                Console.WriteLine("Введена некорректная дата, введите снова:");    
            product.StartDateSell = startSellDate;

            Console.WriteLine("Введите дату конца продажи");
            while(!DateTime.TryParse(Console.ReadLine(), out endSellDate))
                Console.WriteLine("Введена некорректная дата, введите снова:");
            product.EndDateSell = endSellDate;

            allProducts.Add(product);
        }

        public void getDiscountCard()
        {
            var selected=getSelectedProduct();
            DateTime startDiscountDate;
            DateTime endDiscountDate;
            Console.WriteLine("Введите сумму скидки вашей скидочной карты:");
            int.TryParse(Console.ReadLine(), out var discount);
            while(discount<=0)
            {
                Console.WriteLine("Введена некорректная сумма скидки, п");
                int.TryParse(Console.ReadLine(), out discount);
            }
            if(discount> allProducts.ElementAt(selected).Price)
            {
                Console.WriteLine("Скидка больше стоимоститовара, полностью оплачивает товар и остаток сгорает");
                discount = allProducts.ElementAt(selected).Price;
            }

            Console.WriteLine("Введите дату начала действия скидки");
            while (!DateTime.TryParse(Console.ReadLine(), out startDiscountDate))
                Console.WriteLine("Введена не корректная дата, введите заново:");
            if (startDiscountDate > DateTime.Now)
                {
                    Console.WriteLine("Ваша скидка ещё не начала действие");
                    return;
                }
            Console.WriteLine("Введите дату Конец действия скидки");
            while (!DateTime.TryParse(Console.ReadLine(), out endDiscountDate))
                Console.WriteLine("Введена не корректная дата, введите заново:");
            if (endDiscountDate < DateTime.Now)
                {
                    Console.WriteLine("Ваша скидка закончилась");
                    return;
                }
            var i = allProducts.ElementAt(selected).Price - discount;
            Console.WriteLine("Стоимость товара "+allProducts.ElementAt(selected).Name+" со скидкой = "+i+" размер скидки = "+discount);

        }

        public void getDiscountPercent()
        {
            var selected = getSelectedProduct();
            Console.WriteLine("Введите процент вашей скидки от 0 до 100:");
            int.TryParse(Console.ReadLine(), out var discount);
            while (discount < 0 || discount > 100)
            {
                Console.WriteLine("Введен некорректный процент скидки, введите заново:");
                int.TryParse(Console.ReadLine(), out discount);
            }
            var i = allProducts.ElementAt(selected).Price - (allProducts.ElementAt(selected).Price / 100) * discount;
            Console.WriteLine("Стоимость товара " + allProducts.ElementAt(selected).Name + " со скидкой = " + i + " размер скидки = " + discount);

        }

        public void getDiscountPrice()
        {
            var selected = getSelectedProduct();
            Console.WriteLine("Введите сумму вашей скидки:");
            int.TryParse(Console.ReadLine(), out var discount);
            while(discount < 0)
            {
                Console.WriteLine("Вы ввели отрицательное значение, введите положительное значение");
                int.TryParse(Console.ReadLine(), out discount);
            }
            if(discount> allProducts.ElementAt(selected).Price)
            {
                Console.WriteLine("Скидка больше стоимоститовара, полностью оплачивает товар и остаток сгорает");
                discount = allProducts.ElementAt(selected).Price;
            }
            var i = allProducts.ElementAt(selected).Price -  discount;
            Console.WriteLine("Стоимость товара " + allProducts.ElementAt(selected).Name + " со скидкой = " + i + " размер скидки = " + discount);
        }

        public int getSelectedProduct()
        {
            Console.WriteLine("Товары в наличие:");
            var i = 1;
            foreach (Product p in allProducts)
            {
                Console.WriteLine(i + " - " + p.Name + " Цена " + p.Price + " Дата начала продаж: " + p.StartDateSell + " окончание: " + p.EndDateSell);
                i++;
            }
            Console.WriteLine("Выберите товар введя номер от 1 до " + allProducts.Count + ": ");
            int.TryParse(Console.ReadLine(), out var selected);
            while(selected <= 0 || selected > allProducts.Count)
            {
                Console.WriteLine("Вы ввели некорректное значение, введите от 1 до " + allProducts.Count + ": ");
                int.TryParse(Console.ReadLine(), out selected);
            }
                
            return selected-1;
        }
    }
}
