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
            var recordAsString = new RecordType(1, "one", 1.1).ToString();

            Assert.Equal("RecordType { Id = 1, Name = one, Value = 1.1 }", recordAsString);
        }

        [Fact]
        public void HaveSomeThingsYouCannotDo()
        {
            //// deconstruct
            //var (id, name, value) = new RecordType(1, "one", 1.1).ToString();
        }
    }
}