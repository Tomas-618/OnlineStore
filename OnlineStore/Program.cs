using System;

namespace OnlineStore
{
    internal static class Program
    {
        private static void Main()
        {
            var iPhone12 = new Product("IPhone 12");
            var iPhone11 = new Product("IPhone 11");

            var warehouse = new Warehouse();

            var shop = new Shop(warehouse);

            warehouse.Delive(iPhone12, 10);
            warehouse.Delive(iPhone11, 1);

            // Вывод всех товаров на складе с их остатком

            var cart = shop.CreateCart();

            cart.Add(iPhone12, 4);
            cart.Add(iPhone11,
                3); // при такой ситуации возникает ошибка так, как нет нужного количества товара на складе

            // Вывод всех товаров в корзине
            Console.WriteLine(cart.CreateOrder().Paylink);

            cart.Add(iPhone12, 9); //Ошибка, после заказа со склада убираются заказанные товары
        }
    }
}
