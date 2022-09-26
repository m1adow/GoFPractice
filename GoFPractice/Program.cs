using GoFPractice.GoF.AbstractFactory;
using GoFPractice.GoF.Adapter;
using GoFPractice.GoF.Bridge;
using GoFPractice.GoF.Builder;
using GoFPractice.GoF.ChainOfResponsibility;
using GoFPractice.GoF.Composite;
using GoFPractice.GoF.Decorator;
using GoFPractice.GoF.Facade;
using GoFPractice.GoF.Factory;
using GoFPractice.GoF.Flyweight;
using GoFPractice.GoF.Prototype;
using GoFPractice.GoF.Proxy;
using GoFPractice.GoF.Strategy;

#region Factory

VehicleFactory vehicleFactory = new ConcreteVehicleFactory();

var car = vehicleFactory.CreateVehicle(nameof(Car));
var bike = vehicleFactory.CreateVehicle(nameof(Bike));
var motorbike = vehicleFactory.CreateVehicle(nameof(Motorbike));

car.ShowDetailsAboutVehicle();
bike.ShowDetailsAboutVehicle();
motorbike.ShowDetailsAboutVehicle();

#endregion

#region Abstract factory

var logitechFactory = new LogitechFactory();
var razerFactory = new RazerFactory();

Console.WriteLine("Logitech products:\n");

Console.WriteLine("\tWire:\n");
var logitechClient = new DeviceClient(logitechFactory, "Wire");
Console.WriteLine($"\t{logitechClient.GetMouseName()} {logitechClient.GetKeyboardName()}\n");

Console.WriteLine("\tWireless:\n");
logitechClient = new DeviceClient(logitechFactory, "Wireless");
Console.WriteLine($"\t{logitechClient.GetMouseName()} {logitechClient.GetKeyboardName()}\n");

Console.WriteLine("Razer products:\n");

Console.WriteLine("\tWire:\n");
var razerClient = new DeviceClient(razerFactory, "Wire");
Console.WriteLine($"\t{logitechClient.GetMouseName()} {logitechClient.GetKeyboardName()}\t");

Console.WriteLine("\tWireless:\n");
razerClient = new DeviceClient(razerFactory, "Wireless");
Console.WriteLine($"\t{logitechClient.GetMouseName()} {logitechClient.GetKeyboardName()}\t");

#endregion

#region Builder

var accountManufracturer = new AccountManufacturer();

var accountInUAH = new UAHAccountBuilder();
accountManufracturer.BuildAccount(accountInUAH);
var uahAccount = accountInUAH.Account;
uahAccount.PrintDetails();

var accountInUSD = new USDAccountBuilder();
accountManufracturer.BuildAccount(accountInUSD);
var usdAccount = accountInUSD.Account;
usdAccount.PrintDetails();

#endregion

#region Prototype

var fatHuman = new FatHuman();
fatHuman.Name = "Gorg";
fatHuman.ComplexType = ComplexType.Fat;

var clone = (FatHuman)fatHuman.Clone();
clone.ComplexType = ComplexType.Slim;

Console.WriteLine($"{fatHuman.ComplexType}\n{clone.ComplexType}");

#endregion

#region Adapter

var phone = new PhoneAdapter();
Console.WriteLine(phone.GetPhoneModel());

#endregion

#region Bridge

var log = new ApplicationLog();
log.Message = "Log";

log.RegisterLog = new ConsoleLogger();
log.LogMessage();

log.RegisterLog = new FileLogger();
log.LogMessage();

#endregion

#region Decorator

var computer = new GoFPractice.GoF.Decorator.Computer();
Console.WriteLine(computer.ToString());

var gamingPC = new GamingComputer(computer);
gamingPC.AddedPrice = 1000;
Console.WriteLine(gamingPC.ToString());

var officePC = new OfficeComputer(gamingPC);
officePC.CompanyPrefix = "UA";
Console.WriteLine(officePC.ToString());

#endregion

#region Facade

var game = new GameFacade();
game.LaunchGame();
game.StopGame();

#endregion

#region Flyweight

var gangs = new List<IGang?>();
var gangFactory = new GangFactory();
gangs.Add(gangFactory.GetGang("Bloods"));
gangs.Add(gangFactory.GetGang("Rifa"));
gangs.Add(gangFactory.GetGang("Bloods"));
gangs.Add(gangFactory.GetGang("Rifa"));
gangs.Add(gangFactory.GetGang("Bloods"));
gangs.Add(gangFactory.GetGang("Rifa"));

foreach (var gang in gangs)
{
    if (gang != null)
    {
        gang.GetName();
        gang.GetColor();
    }
}

Console.WriteLine($"Count of created object: {gangFactory.GetGangsCount()}");

#endregion

#region Proxy

var proxy = new ProxyAdress();
Console.WriteLine(proxy.GetAdress());

#endregion

#region Composite

var supervisor = new Supervisor()
{
    CPU = "20",
    GPU = "24",
    RAM = "128",
    Computers = new List<GoFPractice.GoF.Composite.IComputer>()
    {
        new GoFPractice.GoF.Composite.Computer { CPU = "8", GPU = "12", RAM = "64" },
        new GoFPractice.GoF.Composite.Computer { CPU = "6", GPU = "8", RAM = "32" },
        new GoFPractice.GoF.Composite.Computer { CPU = "6", GPU = "6", RAM = "16" },
    }
};

supervisor.ShowDetails();

#endregion

#region Chain of responsibility

var request = new BanRequest();
request.BanType = BanType.Permanent;

var helper = new Helper();
var admin = new Admin();
var superAdmin = new SuperAdmin();

admin.NextHandler = superAdmin;
helper.NextHandler = admin;

helper.HandleBanRequest(request);

#endregion

#region Strategy

var pc = new PCShop();
var bakery = new Bakery();
var supermarket = new Supermarket();

var shops = new List<Shop>
{
    new Shop(pc),
    new Shop(bakery),
    new Shop(supermarket)
};

foreach (var shop in shops)
    shop.Sell();

#endregion