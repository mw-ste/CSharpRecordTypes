# Record Types

- You can create immutable record types knowing that none of the compiler-generated members would mutate state.
- And with expressions make it easy to support non-destructive mutation.

- Records add another way to define types.
- You use class definitions to create object-oriented hierarchies that focus on the responsibilities and behavior of objects.
- You create struct types for data structures that store data and are small enough to copy efficiently.
- You create record types when you want value-based equality and comparison, don't want to copy values,
- and want to use reference variables.

- you use the record keyword to define a reference type that provides built-in functionality for encapsulating data
- While records can be mutable, they are primarily intended for supporting immutable data models

- Record type has overwritten equality comparison and toString

### `init` Properties

- init only properties --> can be set in the constructor or using a property initializer

### Immutability

- nondestructive mutation --> change value using "with"

### Inheritance

- A record can inherit from another record. However, a record can't inherit from a class, and a class can't inherit from a record.
- Generic constraints: There is no generic constraint that requires a type to be a record. Records satisfy the class constraint --> can't check for record

### Reference type

- Is a reference type
- Properties are init only properties, can only be set in the constructor
- The compiler synthesizes additional methods:
- - A primary constructor whose parameters match the positional parameters on the record declaration.
- - Public init-only properties for each parameter of a primary constructor.
- - A Deconstruct method to extract properties from the record.

### Record Types vs. Structs

- You can also use structure types to design data-centric types that provide value equality and little or no behavior.
- But for relatively large data models, structure types have some disadvantages:
- - They don't support inheritance.
- - They're less efficient at determining value equality.
-      For value types, the ValueType.Equals method uses reflection to find all fields.
-      For records, the compiler generates the Equals method.
-      In practice, the implementation of value equality in records is measurably faster.
- - They use more memory in some scenarios, since every instance has a complete copy of all of the data.
-      Record types are reference types, so a record instance contains only a reference to the data.

### Record Types vs. self implemented `ValueObject`

- Advantage over ValueObject: can't forget to add new props to equality comparison, no need to test

### Equality

- Value equality means that two variables of a record type are equal if the types match and all property and field values match.For other reference types, equality means identity.

## Positional Record Types

## Regular Record Types

## Special case: Classes with `init` Properties
