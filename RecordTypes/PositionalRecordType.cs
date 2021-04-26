namespace RecordTypes
{
    using System;
    using System.Collections.Generic;

    public record PositionalRecordType(int Id, string Name, double Value) : IDummyData;

    #region special positional record types

    public record PositionalRecordTypeWithNestedReferenceType(int Id, string Name, double Value, List<int> MoreValues)
        : PositionalRecordType(Id, Name, Value);

    public record PositionalRecordTypeWithNestedRecord(PositionalRecordType InternalRecord);

    public record PositionalRecordTypeWithMethod(double Value)
    {
        public void DoStuff()
        {
            Console.WriteLine(ToString());
        }
    }

    #endregion
}