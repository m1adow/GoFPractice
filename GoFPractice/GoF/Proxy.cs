namespace GoFPractice.GoF.Proxy
{
    interface IAdress
    {
        string GetAdress();
    }

    class RealAdress : IAdress
    {
        public string GetAdress() => "Real adress";
    }

    class ProxyAdress : IAdress
    {
        IAdress? adress;
        public string GetAdress()
        {
            adress = new RealAdress();
            return adress.GetAdress();
        }
    }
}
