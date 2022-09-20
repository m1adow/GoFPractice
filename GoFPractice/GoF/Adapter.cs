namespace GoFPractice.GoF.Adapter
{
    class ThirdPartyPhone
    {
        public string GetPhoneModel() => "iPhone";
    }

    interface IPhone
    {
        string GetModel();
    }

    class PhoneAdapter : ThirdPartyPhone, IPhone
    {
        public string GetModel() => GetPhoneModel();
    }
}
