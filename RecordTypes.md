# Record types

_as of April 2021, C#9 / .Net 5.0_

## What are they?

- the `record` keyword adds another way to define types (like `class`, `interface`, ...)
- records are reference types
- records are intended for supporting immutable data models
- therefore records have compiler-generated members like overwritten equality comparison and `toString`, or non-destructive mutation
- the compiler-generated members will not change the state of the record

## When do I use them?

- use `class` to create object-oriented hierarchies that focus on the responsibilities and behavior of objects
- use `struct` for data structures that store data and are small enough to copy efficiently
- use `record` when you:
  - want value-based equality
  - don't want to copy values
  - want to use reference variables

### Non-destructive mutation using `with`

- the `with` expressions make it easy to support non-destructive mutation

- this allows to change values of the immutable records
- thereby a new instance of the record will be created
  ```csharp
  var newRecord = oldRecord with { Value = 42 };
  ```
- **be careful**: members, which are reference types, will be a shallow copy :exclamation:
- this includes nested record types

### `init`-only property setters

- https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/init
- new kind of property setter
- can also be used in regular classes and structs
- supports data immutability
- can only be set during object creation, e.g. in the constructor or object initializer

  ```csharp
  public int PropertyA { get; } // can only be set in the ctor
  public int PropertyB { get; private set; } // can only be set internally
  public int PropertyC { get; init; } // can only be set during object creation
  ```

### Inheritance

- https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/

- records support inheritance, but with some restrictions
- records can inherit from other records and from interfaces
- records can't inherit from classes
- also classes can't inherit from records

Also:

- records satisfy the class constraint
- there is no generic constraint that requires a type to be a record
  `public void Foo<T>() where T : record` :zap:

### Equality

- records have automatically generated value comparison
- the generated comparison can be overwritten if needed
- two variables of a record type are equal if:

  - the types match
  - and all property and field values match
    - values for value types
    - references for reference types

- for reference types other than records: equality means identity

## "Regular" record types

- defined like a `class`, but with the `record` keyword
- create immutable properties using `init` setter
- if needed: create mutable properties :scream:
- what you get for free:
  - collection initialization (but no constructor)
  - equality comparison
  - `with` operator

```csharp
public record RecordType
{
    public string Name { get; init; }
    public double Value { get; init; }
}
```

## Positional record types

- shorthand for creating records
- what you get for free:
  - equality comparison
  - `with` operator
  - **primary constructor whose parameters match the positional parameters on the record declaration** (but no object initializer)
  - **public `init` properties for all parameters on the record declaration**
  - **property deconstruction**
  - protected copy-constructor

  ```csharp
  public record PositionalRecordType(string Name, double Value);
  ```

# Appendix

### classes or structs with `init` properties

- regular classes and structs can also have `init`-only properties
- but they don't get the auto-generated benefits, that records have

### Record types vs. structs

- why not just use a `struct`?
- `struct` can also be used to define data-centric types that provide value equality
- `readonly` structs (C# 7.2) also provide immutability:

  ```csharp
  public readonly struct ReadonlyStruct {}
  ```

  https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/struct#readonly-struct

- But for larger models, structs have some disadvantages:
  - structs don't support inheritance
  - structs are less efficient at determining value equality (according to the docs!)
  - structs can use more memory, since every instance has a complete copy of all its data