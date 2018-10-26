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
            Console.WriteLine("Введите дату начала продажи");
            if(!DateTime.TryParse(Console.ReadLine(), out var startSellDate))
                goto rssd;
            product.StartDateSell = startSellDate;
            resd:
            Console.WriteLine("Введите дату конца продажи");
            if (!DateTime.TryParse(Console.ReadLine(), out var endSellDate))
                goto resd;
            product.EndDateSell = endSellDate;
            allProducts.Add(product);
            return true;
        }

        public void getDiscountCard()
        {
            var selected=getSelectedProduct();
            discount:
            Console.WriteLine("Введите сумму скидки вашей скидочной карты:");
            if (!int.TryParse(Console.ReadLine(), out var discount))
                goto discount;
            if(discount> allProducts.ElementAt(selected).Price)
            {
                Console.WriteLine("Скидка больше стоимоститовара, полностью оплачивает товар и остаток сгорает");
                discount = allProducts.ElementAt(selected).Price;
            }
            sdd:
            Console.WriteLine("Введите дату начала действия скидки");
            if (!DateTime.TryParse(Console.ReadLine(), out var startDiscountDate))
                goto sdd;
            else
                if (startDiscountDate > DateTime.Now)
                {
                    Console.WriteLine("Ваша скидка ещё не начала действие");
                    return;
                }
            edd:
            Console.WriteLine("Введите дату Конец действия скидки");
            if (!DateTime.TryParse(Console.ReadLine(), out var endDiscountDate))
                goto edd;
            else
                if(endDiscountDate < DateTime.Now)
                {
                    Console.WriteLine("Ваша скидка закончилась");
                    return;
                }
            var i = allProducts.ElementAt(selected).Price - discount;
            Console.WriteLine("Стоимость товара "+allProducts.ElementAt(selected).Name+" со скидкой = "+i+" размер скидки = "+discount);

            return;
        }

        public void getDiscountPercent()
        {
            var selected = getSelectedProduct();
            discount:
            Console.WriteLine("Введите процент вашей скидки от 0 до 100:");
            if (!decimal.TryParse(Console.ReadLine(), out var discount))
                goto discount;
            if (discount < 0 || discount > 100)
                goto discount;
            var i = allProducts.ElementAt(selected).Price - (allProducts.ElementAt(selected).Price / 100) * discount;
            Console.WriteLine("Стоимость товара " + allProducts.ElementAt(selected).Name + " со скидкой = " + i + " размер скидки = " + discount);

        }

        public void getDiscountPrice()
        {
            var selected = getSelectedProduct();
            discount:
            Console.WriteLine("Введите сумму вашей скидки:");
            if (!decimal.TryParse(Console.ReadLine(), out var discount))
                goto discount;
            if (discount < 0)
            {
                Console.WriteLine("Вы ввели отрицательное значение.");
                goto discount;
            }
            if(discount> allProducts.ElementAt(selected).Price)
            {
                Console.WriteLine("Скидка больше стоимоститовара, полностью оплачивает товар и остаток сгорает");
                discount = allProducts.ElementAt(selected).Price;
            }
            var i = allProducts.ElementAt(selected).Price - (allProducts.ElementAt(selected).Price / 100) * discount;
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
            sp:
            Console.WriteLine("Выберите товар введя номер от ноля до " + allProducts.Count + ": ");
            if (!int.TryParse(Console.ReadLine(), out var selected))
                if (selected <= 0 || selected > allProducts.Count)
                    goto sp;
            return selected-1;
        }
    }
}
