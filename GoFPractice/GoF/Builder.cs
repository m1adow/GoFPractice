namespace GoFPractice.GoF.Builder
{
    class Account
    {
        public string? Name { get; set; }
        public string? CurrencyType { get; set; }

        public void PrintDetails()
        {
            Console.WriteLine($"------Account: {this.Name}------");
            Console.WriteLine("Account currency: " + this.CurrencyType);
        }
    }

    interface IAccountBuilder
    {
        void AddName();
        void AddCurency();
    }

    class UAHAccountBuilder : IAccountBuilder
    {
        public Account Account { get; private set; } = new Account();

        public void AddCurency()
        {
            Account.CurrencyType = "UAH";
        }

        public void AddName()
        {
            Account.Name = "Account in UAH";
        }
    }

    class USDAccountBuilder : IAccountBuilder
    {
        public Account Account { get; private set; } = new Account();

        public void AddCurency()
        {
            Account.CurrencyType = "USD";
        }

        public void AddName()
        {
            Account.Name = "Account in USD";
        }
    }

    class AccountManufacturer
    {
        public void BuildAccount(IAccountBuilder accountBuilder)
        {
            accountBuilder.AddName();
            accountBuilder.AddCurency();
        }
    }
}
