namespace GoFPractice.GoF.Prototype
{
    enum ComplexType
    {
        Fat,
        Slim
    }

    interface IHuman
    {
        IHuman? Clone();
    }

    class Human
    {
        public string? Name { get; set; }
        public ComplexType ComplexType { get; set; }
    }

    class FatHuman : Human, IHuman
    {
        public IHuman? Clone()
        {
            return this.MemberwiseClone() as IHuman;
        }
    }

    class SlimHuman : Human, IHuman
    {
        public IHuman? Clone()
        {
            return this.MemberwiseClone() as IHuman;
        }
    }
}
