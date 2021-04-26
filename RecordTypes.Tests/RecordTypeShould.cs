namespace RecordTypes.Tests
{
    using Xunit;

    public class RecordTypeShould
    {
        [Fact]
        public void HaveCollectionInitializer()
        {
            //when default constructor is specified!

            var _ = new RecordType
            {
                Id = 1,
                Name = "one",
                Value = 1.0
            };
        }

        [Fact]
        public void BeEqual()
        {
            var someRecord = new RecordType(1, "one", 1.0);
            var otherRecord = new RecordType(1, "one", 1.0);

            Assert.Equal(someRecord, otherRecord);
            Assert.True(someRecord == otherRecord);
        }

        [Fact]
        public void NotBeEqual()
        {
            var someRecord = new RecordType(1, "one", 1.0);
            var otherRecord = new RecordType(2, "two", 2.0);

            Assert.NotEqual(someRecord, otherRecord);
            Assert.False(someRecord == otherRecord);
        }

        [Fact]
        public void BeCopyableWithNewValue()
        {
            var someRecord = new RecordType(1, "one", 1.0);
            var otherRecord = someRecord with { Id = 42 };

            Assert.Equal(42, otherRecord.Id);
            Assert.NotEqual(someRecord, otherRecord);
        }

        [Fact]
        public void BeImmutable()
        {
            var someRecord = new RecordType(1, "one", 1.0);
            var otherRecord = someRecord with { };

            Assert.Equal(someRecord, otherRecord);
            Assert.NotSame(someRecord, otherRecord);
        }

        [Fact]
        public void OverloadToStringMethod()
        {
            var someRecord = new RecordType(1, "one", 1.1);
            var expectedString = $"{nameof(RecordType)} {{ " +
                                 $"{nameof(RecordType.Id)} = {someRecord.Id}, " +
                                 $"{nameof(RecordType.Name)} = {someRecord.Name}, " +
                                 $"{nameof(RecordType.Value)} = {someRecord.Value} }}";

            Assert.Equal(expectedString, someRecord.ToString());
        }

        [Fact]
        public void HaveSomeThingsYouCannotDo()
        {
            //// deconstruct
            //var (id, name, value) = new RecordType(1, "one", 1.1).ToString();
        }

        #region with mutable data

        [Fact]
        public void HaveCollectionInitializerAlsoForMutableData()
        {
            //when default constructor is specified!

            var _ = new RecordTypeWithMutableData
            {
                Id = 1,
                Name = "one",
                Value = 1.0,
                Index = 5
            };
        }

        [Fact]
        public void BeCopyableWithNewValueForMutableData()
        {
            var someRecord = new RecordTypeWithMutableData(1, "one", 1.0, 32);
            var otherRecord = someRecord with { Index = 42 };

            Assert.Equal(42, otherRecord.Index);
            Assert.NotEqual(someRecord, otherRecord);
        }

        #endregion
    }
}