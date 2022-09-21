namespace GoFPractice.GoF.Composite
{
    interface IComputer
    {
        string CPU { get; set; }
        string GPU { get; set; }
        string RAM { get; set; }
        void ShowDetails();
    }

    class Computer : IComputer
    {
        public string CPU { get; set; }
        public string GPU { get; set; }
        public string RAM { get; set; }

        public void ShowDetails()
        {
            Console.WriteLine($"CPU: {CPU}\tGPU: {GPU}\tRAM: {RAM}");
        }
    }

    class Supervisor : IComputer
    {
        public string CPU { get; set; }
        public string GPU { get; set; }
        public string RAM { get; set; }

        public List<IComputer> Computers = new List<IComputer>();

        public void ShowDetails()
        {
            Console.WriteLine($"I'm supervisor! CPU: {CPU}\tGPU: {GPU}\tRAM: {RAM}");
            foreach (var computer in Computers)
            {
                computer.ShowDetails();
            }
        }
    }
}
