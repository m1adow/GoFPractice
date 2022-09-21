namespace GoFPractice.GoF.Flyweight
{
    interface IGang
    {
        void GetName();
        void GetColor();
    }

    class BloodsGang : IGang
    {
        public void GetName() => Console.WriteLine("Bloods");
        
        public void GetColor() => Console.WriteLine("Red");
    }

    class RifaGang : IGang
    {
        public void GetName() => Console.WriteLine("Rifa");

        public void GetColor() => Console.WriteLine("Blue");
    }

    class GangFactory
    {
        Dictionary<string, IGang?> gangs = new Dictionary<string, IGang?>();

        public int GetGangsCount() => gangs.Count;

        public IGang? GetGang(string name)
        {
            IGang? gang = null;

            if (gangs.ContainsKey(name))
            {
                gang = gangs[name];
            }
            else
            {
                if (name == "Bloods")
                {
                    gang = new BloodsGang();
                }
                else if (name == "RifaGang")
                {
                    gang = new RifaGang();
                }

                gangs.Add(name, gang);
            }

            return gang;
        }
    }
}
