namespace GoFPractice.GoF.Decorator
{
    interface IComputer
    {
        string GetName();
        int GetPrice();
    }

    class Computer : IComputer
    {
        public int GetPrice() => 300;

        public string GetName() => "Computer";

        public override string ToString() => $"{this.GetName()} {this.GetPrice()}";
    }

    abstract class ComputerDecorator : IComputer
    {
        public abstract string GetName();
        public abstract int GetPrice();
    }

    class GamingComputer : ComputerDecorator
    {
        private IComputer computer;
        public int AddedPrice { get; set; }

        public GamingComputer(IComputer computer)
        {
            this.computer = computer;
        }

        public override string GetName() => "Gaming computer";

        public override int GetPrice() => computer.GetPrice() + AddedPrice;

        public override string ToString() => $"{this.GetName()} {this.GetPrice()}";
    }

    class OfficeComputer : ComputerDecorator
    {
        private IComputer computer;
        public string? CompanyPrefix { get; set; }

        public OfficeComputer(IComputer computer)
        {
            this.computer = computer;
        }

        public override string GetName() => $"{CompanyPrefix} {computer.GetName()}";

        public override int GetPrice() => computer.GetPrice();

        public override string ToString() => $"{this.GetName()} {this.GetPrice()}";
    }
}
