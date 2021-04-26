namespace RecordTypes.Tests
{
    using Xunit;

    public class ClassWithInitShould
    {
        [Fact]
        public void HaveCollectionInitializer()
        {
            // only works when default constructor is specified!

            var _ = new ClassWithInit
            {
                Id = 1,
                Name = "one",
                Value = 1.0
            };
        }

        [Fact]
        public void NotBeComparable()
        {
            var someRecord  = new ClassWithInit(1, "one", 1.0);
            var otherRecord = new ClassWithInit(1, "one", 1.0);

            Assert.NotEqual(someRecord, otherRecord); // !!!
        }

        [Fact]
        public void HaveSomeThingsYouCannotDo()
        {
            //// data is immutable
            //var someRecord = new ClassWithInit(1, "one", 1.0);
            //someRecord.Id = 5;

            //// deconstruct
            //var (id, name, value) = new ClassWithInit(1, "one", 1.1).ToString();

            //// copy with new value
            //var someRecord = new ClassWithInit(1, "one", 1.0);
            //var otherRecord = someRecord with { Id = 42 };

            //// overload toString
            //var recordAsString = new ClassWithInit(1, "one", 1.1).ToString();
            //Assert.Equal("ClassWithInit { Id = 1, Name = one, Value = 1.1 }", recordAsString);
        }
    }
}