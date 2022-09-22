namespace GoFPractice.GoF.ChainOfResponsibility
{
    enum BanType
    {
        Week,
        Month,
        Permanent
    }

    class BanRequest
    {
        public BanType BanType { get; set; }
    }

    interface IBanRequestHandler
    {
        void HandleBanRequest(BanRequest request);
        IBanRequestHandler NextHandler { get; set; }
    }

    class Helper : IBanRequestHandler
    {
        public IBanRequestHandler NextHandler { get; set; }

        public void HandleBanRequest(BanRequest request)
        {
            if (request.BanType != BanType.Week)
            {
                NextHandler.HandleBanRequest(request);
            }
            else
            {
                Console.WriteLine("Ban was executed");
            }
        }
    }

    class Admin : IBanRequestHandler
    {
        public IBanRequestHandler NextHandler { get; set; }

        public void HandleBanRequest(BanRequest request)
        {
            if (request.BanType != BanType.Month)
            {
                NextHandler.HandleBanRequest(request);
            }
            else
            {
                Console.WriteLine("Ban was executed");
            }
        }
    }

    class SuperAdmin : IBanRequestHandler
    {
        public IBanRequestHandler NextHandler { get; set; }

        public void HandleBanRequest(BanRequest request)
        {
            Console.WriteLine("Ban was executed");
        }
    }
}
