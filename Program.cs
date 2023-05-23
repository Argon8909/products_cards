using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Library;
using Library.figures;
using Products.mails;


namespace Products
{
    class Program
    {
        private const int ProductsCapacity = 100;
        private static Random _random = new Random();
        private static List<Product> _products = new List<Product>(ProductsCapacity); //перечень продуктов

        static void Main(string[] args)
        {
            for (int i = 0; i < ProductsCapacity; i++)
            {
                _products.Add(CreateProduct());
            }

            List<ProductBasket> Baskets = new List<ProductBasket>(); //список корзин
            for (int i = 0; i < 10; i++)
            {
                Baskets.Add(CreateBasket());
            }

            //выбрать такие корзины, в которых сумма всех продуктов больше 100
            var basketsOver100 = Baskets.Where(b => b.SumProducts > 100);

            //ыбрать такие продукты, у которых название длинее 5 символов и цена больше 10
            var namePriceProducts = _products.Where(p => p.Title.Length > 5 && p.Price > 10);

            //выбрать такие корзины, у которых более 4 продуктов 
            var basketsOver4Positions = Baskets.Where(b => b.Products.Count > 4);

            //выбрать продукты из всех корзин, у которых цена в интервале от 10 до 100
            var price10To100 =
                _products.Where(p =>
                    p.Price > 10 &&
                    p.Price < 100);

            //выбрать для каждой корзины продукт с максимальной ценой в рамках данной корзины
            var maxPriceInBasket = Baskets
                .Select(b => b.Products.OrderByDescending(p => p.Key.Price).FirstOrDefault())
                .Select(p => p.Key);

            //посчитать сумму всех продуктов в рамках каждой корзины
            var sumProductPriceInBasket = Baskets.Select(s => s.Products.Sum(s => s.Key.Price));

            //посмитчать сумму всех продуктов для всех корзин суммарно
            var sumPriceProductInAllBasket = Baskets.SelectMany(b => b.Products.Keys)
                .Sum(p => p.Price);
        }


        static Product CreateProduct()
        {
            int price = _random.Next(1, 25);
            var productName = RandomString(_random.Next(2, 10));
            return new Product(price, productName); //
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        static ProductBasket CreateBasket()
        {
            var basket = new ProductBasket();
            var productsCount = _random.Next(1, 10);

            for (int i = 0; i < productsCount; i++)
            {
                var randomProductIndex = _random.Next(_products.Count);
                var selectedProduct = _products[randomProductIndex];
                basket.AddProduct(selectedProduct, _random.Next(1, 200)); //Заполняем количество продуктов в корзине
            }

            return basket;
        }
    }
}

/*
  static void MainFigures()
        {
            int i = 1;

            i.PrintInt();

            var cube = new Cube(1, 10);
            cube.GetAreaAndVolSumm();

            var circle = new Circle(10, "324");

            circle.CalculateAndPrint("Квадрат площади");

            //var prop = GetAreaAndVolSumm(cube);
        }

        static double GetAreaAndVolSumm(Cube cube)
        {
            return cube.Perimeter + cube.Volume;
        }

        static void Main1()
        {
            var pr1 = new Product(10000, "pr1");
            var pr2 = new Product(99, "pr2");
            var pr3 = new Product(10, "pr3");

            // var card = new ProductCard(NotifyMagnit, NotifyOfSaleByConsole, CalculateSaleMagnit, obj => true);
            //
            // card.BuyEvent += CardOnBuyEvent;
            // card.AddProducts(new []{pr1, pr2, pr3});
            // card.Buy();
            //
            // card.BuyEvent -= CardOnBuyEvent;
        }

        private static void CardOnBuyEvent(object sender, decimal total)
        {
            Console.WriteLine($"Сделана покупка на сумму {total}");
        }

        public static void NotifyPerekrestok(Product product)
        {
            Console.WriteLine($"Added new product: {product}");
        }

        public static void NotifyDiksi(Product product)
        {
            Console.WriteLine($"Welcome! Added new product: {product}");
        }

        public static void NotifyMagnit(Product product)
        {
            //Console.WriteLine($"MAGNIT! Added new product: {product}");
        }

        public static void NotifyOfSaleByConsole(decimal sale, decimal summOfSale)
        {
            // Console.WriteLine($"Скидка составила {sale:P} процентов. В деньгах: {summOfSale:N0}");
        }

        public static void NotifyOfSaleByFile(decimal sale, decimal summOfSale)
        {
            var message = $"Скидка составила {sale:P} процентов. В деньгах: {summOfSale:N0}";
            File.WriteAllText("log.txt", message);
        }

        // private readonly Func<decimal, decimal> _calculateSaleFunc;

        public static decimal CalculateSaleMagnit(decimal summ)
        {
            decimal sale = 1;

            if (summ > 1000)
            {
                sale = 0.95M;
            }
            else if (summ > 100)
            {
                sale = 0.975M;
            }
            else if (summ > 25)
            {
                sale = 0.99M;
            }

            return sale;
        }

        public static decimal CalculateSalePerekrestok(decimal summ)
        {
            decimal sale = 0.9M;

            return sale;
        }
 
 
 *  //var circle = new Circle(1, "23");

            var typeOfCircle = typeof(Circle);
            foreach (var att in typeOfCircle.GetCustomAttributes(true))
            {
                if (att is AuthorAttribute authorAttribute)
                {
                    Console.WriteLine($"Наш атрибут: {authorAttribute}");
                }
            }
            
            return;
            
            
            MainFigures();
            return;
            Main1();
            return;
            void OnMail(object sender, MailEventArgs eventArgs)
            {
                //Console.WriteLine($"5Получено письмо: {eventArgs.Mail}");
            }
            
            void OnMail1(object sender, MailEventArgs eventArgs)
            {
                //Console.WriteLine($"5Получено письмо: {eventArgs.Mail}");
            }

            var man = new Human();
            
            man.GetMailEvent += OnMail;
            man.GetMailEvent += OnMail1;
            man.PrintInvocationList();

            man.AddMail(new Mail("ssfd", "sdf", "sdf"));
            
            man.GetMailEvent -= OnMail;
            man.PrintInvocationList();
            
            
            // EventHandler<ProductAddEventArgs> cardOnProductAddedEvent()
            // {
            //     return (sender, eventArgs) =>
            //     {
            //         var product = eventArgs.AddedProduct;
            //         Console.WriteLine($"Обработчик1. {product}"); 
            //     };
            // }
            //
            //
            // // EventHandler<ProductAddEventArgs> cardOnProductAddedEvent2()
            // // {
            // //     return (sender, eventArgs) =>
            // //     {
            // //         Console.WriteLine("Обработчик2"); 
            // //     };
            // // }
            // var pr1 = new Product(10000, "pr1");
            // var pr2 = new Product(99, "pr2");
            // var pr3 = new Product(10, "pr3");
            //
            // var card = new ProductCard(NotifyMagnit, NotifyOfSaleByConsole, CalculateSaleMagnit, obj => true );
            //
            // card.ProductAddedEvent += cardOnProductAddedEvent();
            // //card.ProductAddedEvent += cardOnProductAddedEvent2();
            //
            // card.AddProducts(new []{pr1, pr2, pr3});
            //
            // card.ProductAddedEvent -= cardOnProductAddedEvent();
            // //card.ProductAddedEvent -= cardOnProductAddedEvent2();
            
            return;

            // Console.WriteLine("perekrestok");
            // var card1 = new ProductCard(
            //     product => { Console.WriteLine($"Added new product: {product}"); },
            //     (sale, summOfSale) =>
            //     {
            //         Console.WriteLine($"Скидка составила {sale:P} процентов. В деньгах: {summOfSale:N0}");
            //     },
            //     (arg) => 0.8M, 
            //     summ =>
            //     {
            //         if (summ > 1000) return true;
            //         return false;
            //     });
            //
            // card1.AddProduct(pr1);
            // Console.WriteLine($"Total: {card1.GetTotalSumm():N0}");


            // Console.WriteLine("magin");
            // var card2 = new ProductCard(NotifyMagnit, NotifyOfSaleByConsole, CalculateSaleMagnit);
            // card2.AddProduct(pr2);
            // Console.WriteLine($"Total: {card2.GetTotalSumm():N0}");
            //
            // //
            // var card2 = new ProductCard(NotifyPerekrestok, NotifyOfSaleByFile);
            // Console.WriteLine($"Total: {card2.GetTotalSumm():N0}");

            // Console.WriteLine("DIKSI");
            // var productCardDiksi = new ProductCard(NotifyDiksi, NotifyOfSale);
            // productCardDiksi.AddProduct(pr1);
            // productCardDiksi.AddProduct(pr2);
            // productCardDiksi.AddProduct(pr3);
            //
            // Console.WriteLine("MAGNIT");
            // var productCardMagnit = new ProductCard(NotifyMagnit, NotifyOfSale);
            // productCardMagnit.AddProduct(pr1);

            // Console.WriteLine(productCard.PrintAllProduct());

*/