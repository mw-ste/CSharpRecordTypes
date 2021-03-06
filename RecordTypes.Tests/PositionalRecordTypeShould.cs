using System.Collections.Generic;

namespace RecordTypes.Tests
{
    using Xunit;

    public class PositionalRecordTypeShould
    {
        [Fact]
        public void BeEqual()
        {
            var someRecord = new PositionalRecordType(1, "one", 1.0);
            var otherRecord = new PositionalRecordType(1, "one", 1.0);

            Assert.Equal(someRecord, otherRecord);
            Assert.True(someRecord == otherRecord);
        }

        [Fact]
        public void NotBeEqual()
        {
            var someRecord = new PositionalRecordType(1, "one", 1.0);
            var otherRecord = new PositionalRecordType(2, "two", 2.0);

            Assert.NotEqual(someRecord, otherRecord);
            Assert.False(someRecord == otherRecord);
        }

        [Fact]
        public void NotBeEqualForInheritedTypes()
        {
            PositionalRecordType someRecord = new PositionalRecordType(1, "one", 1.1);
            PositionalRecordType otherRecord = new PositionalRecordTypeWithNestedReferenceType(1, "one", 1.1, new List<int> { 1, 2, 3 });

            Assert.NotEqual(someRecord, otherRecord);
        }

        [Fact]
        public void BeCopyableWithNewValue()
        {
            var someRecord = new PositionalRecordType(1, "one", 1.0);
            var otherRecord = someRecord with {Id = 42};

            Assert.Equal(42, otherRecord.Id);
            Assert.NotEqual(someRecord, otherRecord);
        }

        [Fact]
        public void BeImmutable()
        {
            var someRecord = new PositionalRecordType(1, "one", 1.0);
            var otherRecord = someRecord with { };

            Assert.Equal(someRecord, otherRecord);
            Assert.NotSame(someRecord, otherRecord);
        }

        [Fact]
        public void BeCarefulAboutNestedReferenceTypes()
        {
            var someRecord = new PositionalRecordTypeWithNestedReferenceType(1, "one", 1.1, new List<int> { 1, 2, 3 });
            var otherRecord = someRecord with { };

            Assert.NotSame(someRecord, otherRecord);
            Assert.Same(someRecord.MoreValues, otherRecord.MoreValues); //!!!

            someRecord.MoreValues.Clear();
            Assert.Empty(otherRecord.MoreValues);
        }

        [Fact]
        public void AlsoBeCarefulAboutNestedRecordTypes()
        {
            // this is not such a big problem, since the nested record should be immutable!

            var internalRecord = new PositionalRecordType(1, "one", 1.0);
            var someRecord = new PositionalRecordTypeWithNestedRecord(internalRecord);
            var otherRecord = new PositionalRecordTypeWithNestedRecord(internalRecord);

            Assert.NotSame(someRecord, otherRecord);
            Assert.Same(someRecord.InternalRecord, otherRecord.InternalRecord);
        }

        [Fact]
        public void BeEqualForGenericRecordTypes()
        {
            var someRecord = new GenericPositionalRecordType<string>("text");
            var otherRecord = new GenericPositionalRecordType<string>("text");

            Assert.Equal(someRecord, otherRecord);
        }

        [Fact]
        public void BeEqualWhenNestedRecordsAreEqual()
        {
            var someRecord  = new PositionalRecordTypeWithNestedRecord(new PositionalRecordType(1, "one", 1.0));
            var otherRecord = new PositionalRecordTypeWithNestedRecord(new PositionalRecordType(1, "one", 1.0));

            Assert.Equal(someRecord, otherRecord);
            Assert.NotSame(someRecord, otherRecord);
            Assert.NotSame(someRecord.InternalRecord, otherRecord.InternalRecord);
        }

        [Fact]
        public void BeEqualWhenNestedReferenceTypesAreSame()
        {
            var moreValues = new List<int> { 1, 2, 3 };
            var someRecord = new PositionalRecordTypeWithNestedReferenceType(1, "one", 1.1, moreValues);
            var otherRecord = new PositionalRecordTypeWithNestedReferenceType(1, "one", 1.1, moreValues);

            Assert.Equal(someRecord, otherRecord);
        }

        [Fact]
        public void NotBeEqualWhenNestedReferenceTypesAreDifferent()
        {
            var someRecord  = new PositionalRecordTypeWithNestedReferenceType(1, "one", 1.1, new List<int> { 1, 2, 3 });
            var otherRecord = new PositionalRecordTypeWithNestedReferenceType(1, "one", 1.1, new List<int> { 1, 2, 3 });

            Assert.NotEqual(someRecord, otherRecord);
        }

        [Fact]
        public void HaveDeconstruct()
        {
            const int expectedId = 1;
            const string expectedName = "one";
            const double expected = 1.0;

            var (id, name, value) = new PositionalRecordType(expectedId, expectedName, expected);

            Assert.Equal(expectedId, id);
            Assert.Equal(expectedName, name);
            Assert.Equal(expected, value);
        }

        [Fact]
        public void OverloadToStringMethod()
        {
            var someRecord = new PositionalRecordType(1, "one", 1.1);
            var expectedString = $"{nameof(PositionalRecordType)} {{ " +
                        $"{nameof(PositionalRecordType.Id)} = {someRecord.Id}, " +
                        $"{nameof(PositionalRecordType.Name)} = {someRecord.Name}, " +
                        $"{nameof(PositionalRecordType.Value)} = {someRecord.Value} }}";

            Assert.Equal(expectedString, someRecord.ToString());
        }

        [Fact]
        public void PrintNestedRecordTypes()
        {
            var someRecord = new PositionalRecordType(1, "one", 1.1);
            var someRecordWithNestedRecord = new PositionalRecordTypeWithNestedRecord(someRecord);
            var expectedString = $"{nameof(PositionalRecordTypeWithNestedRecord)} {{ " +
                                 $"{nameof(PositionalRecordTypeWithNestedRecord.InternalRecord)} = {someRecord} }}";

            Assert.Equal(expectedString, someRecordWithNestedRecord.ToString());
        }

        [Fact]
        public void HaveMethods()
        {
            var someRecord = new PositionalRecordTypeWithMethod(1.1);

            someRecord.DoStuff();
        }

        [Fact]
        public void HaveSomeThingsYouCannotDo()
        {
            //// data is immutable
            //var someRecord = new PositionalRecordType(1, "one", 1.0);
            //someRecord.Id = 5;

            //// can't use collection initializer
            //var _ = new PositionalRecordType
            //{
            //    Id = 1,
            //    Name = "one",
            //    Value = 1.0
            //};

            //// generated copy constructor is protected
            //var originalRecord = new PositionalRecordType(1, "one", 1.0);
            //var _ = new PositionalRecordType(originalRecord);

            //// check if is record type
            //var someRecord = new PositionalRecordType(1, "one", 1.0);
            //Assert.True(someRecord is record);
        }
    }
}
