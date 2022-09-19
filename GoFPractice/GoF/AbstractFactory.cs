namespace GoFPractice.GoF.AbstractFactory
{
    interface IKeyboard
    {
        string GetName();
    }    

    class WireKeyboard : IKeyboard
    {
        public string GetName() => "Wire keyboard";
    }

    class WirelessKeyboard : IKeyboard
    {
        public string GetName() => "Wireless keyboard";
    }

    interface IMouse
    {
        string GetName();
    }

    class WireMouse : IMouse
    {
        public string GetName() => "Wire mouse";
    }

    class WirelessMouse : IMouse
    {
        public string GetName() => "Wireless mouse";
    }

    interface IDeviceFactory
    {
        IKeyboard GetKeyboard(string keyboardType);
        IMouse GetMouse(string mouseType);
    }

    class LogitechFactory : IDeviceFactory
    {
        public IKeyboard GetKeyboard(string keyboardType)
        {
            switch (keyboardType)
            {
                case "Wireless":
                    return new WirelessKeyboard();
                case "Wire":
                    return new WireKeyboard();
                default:
                    throw new ApplicationException(keyboardType + "cannot be created");
            }
        }

        public IMouse GetMouse(string mouseType)
        {
            switch (mouseType)
            {
                case "Wireless":
                    return new WirelessMouse();
                case "Wire":
                    return new WireMouse();
                default:
                    throw new ApplicationException(mouseType + "cannot be created");
            }
        }
    }

    class RazerFactory : IDeviceFactory
    {
        public IKeyboard GetKeyboard(string keyboardType)
        {
            switch (keyboardType)
            {
                case "Wireless":
                    return new WirelessKeyboard();
                case "Wire":
                    return new WireKeyboard();
                default:
                    throw new ApplicationException(keyboardType + "cannot be created");
            }
        }

        public IMouse GetMouse(string mouseType)
        {
            switch (mouseType)
            {
                case "Wireless":
                    return new WirelessMouse();
                case "Wire":
                    return new WireMouse();
                default:
                    throw new ApplicationException(mouseType + "cannot be created");
            }
        }
    }

    class DeviceClient
    {
        private IKeyboard keyboard;
        private IMouse mouse;

        public DeviceClient(IDeviceFactory deviceFactory, string wireType)
        {
            keyboard = deviceFactory.GetKeyboard(wireType);
            mouse = deviceFactory.GetMouse(wireType);
        }

        public string GetKeyboardName() => keyboard.GetName(); 
        public string GetMouseName() => mouse.GetName(); 
    }
}
