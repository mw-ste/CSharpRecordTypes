﻿namespace RecordTypes
{
    using System;
    using System.Collections.Generic;
    

    public record PositionalRecordType(int Id, string Name, double Value) : IDummyData;

    
    public record PositionalRecordTypeWithInheritance(int Id, string Name, double Value, List<int> MoreValues) 
        : PositionalRecordType(Id, Name, Value)
    {
        public void DoStuff()
        {
            Console.WriteLine(ToString());
        }
    }

    public record PositionalRecordTypeWithNestedRecord(PositionalRecordType InternalRecord);
}