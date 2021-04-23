namespace record_types
{
    public record RecordType : IDummyData
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public double Value { get; init; }

        public RecordType()
        {
        }

        public RecordType(int id, string name, double value)
        {
            Id = id;
            Name = name;
            Value = value;
        }
    }
}