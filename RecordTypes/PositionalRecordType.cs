using System.Collections.Generic;

namespace RecordTypes
{
    using System;

    /*
     * You can create immutable record types knowing that none of the compiler-generated members would mutate state.
     * And with expressions make it easy to support non-destructive mutation.
     *
     * Records add another way to define types.
     * You use class definitions to create object-oriented hierarchies that focus on the responsibilities and behavior of objects.
     * You create struct types for data structures that store data and are small enough to copy efficiently.
     * You create record types when you want value-based equality and comparison, don't want to copy values,
     * and want to use reference variables.
     */

    //you use the record keyword to define a reference type that provides built-in functionality for encapsulating data
    //While records can be mutable, they are primarily intended for supporting immutable data models

    //equality
    //Value equality means that two variables of a record type are equal if the types match and all property and field values match.For other reference types, equality means identity.

    /*
     * struct vs. record
     * You can also use structure types to design data-centric types that provide value equality and little or no behavior.
     * But for relatively large data models, structure types have some disadvantages:
     * - They don't support inheritance.
     * - They're less efficient at determining value equality.
     *      For value types, the ValueType.Equals method uses reflection to find all fields.
     *      For records, the compiler generates the Equals method.
     *      In practice, the implementation of value equality in records is measurably faster.
     * - They use more memory in some scenarios, since every instance has a complete copy of all of the data.
     *      Record types are reference types, so a record instance contains only a reference to the data.
     */

    //Advantage over ValueObject: can't forget to add new props to equality comparison, no need to test

    //nondestructive mutation --> change value using "with"

    //A record can inherit from another record. However, a record can't inherit from a class, and a class can't inherit from a record.


    //init only properties --> can be set in the constructor or using a property initializer
    /*
     * Record type has overwritten equality comparison and toString
     */

    //Generic constraints: There is no generic constraint that requires a type to be a record. Records satisfy the class constraint
    //--> can't check for record

    /*
     * Is a reference type
     * Properties are init only properties, can only be set in the constructor
     * The compiler synthesizes additional methods:
     * - A primary constructor whose parameters match the positional parameters on the record declaration.
     * - Public init-only properties for each parameter of a primary constructor.
     * - A Deconstruct method to extract properties from the record.
     */

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