namespace GoFPractice.GoF.Factory
{
    interface IVehicle
    {
        void ShowDetailsAboutVehicle();
    }

    class Car : IVehicle
    {
        public void ShowDetailsAboutVehicle()
        {
            Console.WriteLine("I'm car");
        }
    }

    class Bike : IVehicle
    {
        public void ShowDetailsAboutVehicle()
        {
            Console.WriteLine("I'm bike");
        }
    }

    class Motorbike : IVehicle
    {
        public void ShowDetailsAboutVehicle()
        {
            Console.WriteLine("I'm motorbike");
        }
    }

    abstract class VehicleFactory
    {
        public abstract IVehicle CreateVehicle(string vehicleType);
    }

    class ConcreteVehicleFactory : VehicleFactory
    {
        public override IVehicle CreateVehicle(string vehicleType)
        {
            switch (vehicleType)
            {
                case nameof(Car):
                    return new Car();
                case nameof(Bike):
                    return new Bike();
                case nameof(Motorbike):
                    return new Motorbike();
                default:
                    throw new ApplicationException(string.Format("This type of vehicle can not be created"));
            }
        }
    }
}
