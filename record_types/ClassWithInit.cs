namespace record_types
{
    public class ClassWithInit : IDummyData
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public double Value { get; init; }

        public ClassWithInit()
        {
        }

        public ClassWithInit(int id, string name, double value)
        {
            Id = id;
            Name = name;
            Value = value;
        }
    }
}
