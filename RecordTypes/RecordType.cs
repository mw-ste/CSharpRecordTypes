namespace RecordTypes
{
    public record RecordType : IDummyData
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public double Value { get; init; }

        // not strictly needed, since object initialization works out of the box
        public RecordType(int id, string name, double value)
        {
            Id = id;
            Name = name;
            Value = value;
        }

        // needs to be present for object initialization to work, if other constructors are defined
        public RecordType()
        {
        }
    }

    #region special record types

    public record RecordTypeWithMutableData : RecordType
    {
        public int Index { get; set; } // needs to have public setter for "with" to work!

        public RecordTypeWithMutableData()
        {
        }

        public RecordTypeWithMutableData(int id, string name, double value, int index) 
            : base(id, name, value)
        {
            Index = index;
        }
    }

    #endregion
}