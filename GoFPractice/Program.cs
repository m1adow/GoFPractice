using GoFPractice.GoF.AbstractFactory;
using GoFPractice.GoF.Adapter;
using GoFPractice.GoF.Bridge;
using GoFPractice.GoF.Builder;
using GoFPractice.GoF.Decorator;
using GoFPractice.GoF.Facade;
using GoFPractice.GoF.Factory;
using GoFPractice.GoF.Prototype;

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

var computer = new Computer();
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