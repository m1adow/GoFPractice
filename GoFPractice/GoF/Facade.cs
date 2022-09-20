namespace GoFPractice.GoF.Facade
{
    interface IGameElement
    {
        void Create();
        void Delete();
    }

    class Player : IGameElement
    {
        public void Create() => Console.WriteLine("Create player");

        public void Delete() => Console.WriteLine("Delete player");
    }

    class Map : IGameElement
    {
        public void Create() => Console.WriteLine("Create map");

        public void Delete() => Console.WriteLine("Delete map");
    }

    class Menu : IGameElement
    {
        public void Create() => Console.WriteLine("Create menu");

        public void Delete() => Console.WriteLine("Delete menu");
    }

    class GameFacade
    {
        public List<IGameElement> GameElements { get; private set; }

        public GameFacade()
        {
            GameElements = new List<IGameElement>()
            {
                new Player(),
                new Player(),
                new Map(),
                new Menu()
            };
        }

        public void LaunchGame()
        {
            foreach (var gameElement in GameElements)
                gameElement.Create();
        }

        public void StopGame()
        {
            foreach (var gameElement in GameElements)
                gameElement.Delete();
        }
    }
}
