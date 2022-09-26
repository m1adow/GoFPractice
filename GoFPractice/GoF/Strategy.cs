namespace GoFPractice.GoF.Strategy
{
    interface IShop
    {
        void SellItem();
    }

    class PCShop : IShop
    {
        public void SellItem()
        {
            Console.WriteLine("I can sell pc");
        }
    }

    class Bakery : IShop
    {
        public void SellItem()
        {
            Console.WriteLine("I can sell meals");
        }
    }

    class Supermarket : IShop
    {
        public void SellItem()
        {
            Console.WriteLine("I can sell everything");
        }
    }

    class Shop
    {
        private IShop shop;

        public Shop(IShop shop)
        {
            this.shop = shop;
        }

        public void Sell() => this.shop.SellItem();
    }
}
