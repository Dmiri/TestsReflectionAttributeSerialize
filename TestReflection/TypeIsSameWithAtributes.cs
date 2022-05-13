using NUnit.Framework;
using ReflectionWithAttributes;
using TestReflection.Base;

namespace TestReflection.Attributes
{
    public class TypeIsSameWithAtributes
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCopy()
        {
            Source sourceNull = null;
            var source = new Source { Timeout = 42, String = "Source" };
            var destination = new Destination { Time = 24, String = "It's destination now.", Uri = null };
            var destination2 = new Destination { Time = 24, String = "It's destination now.", Uri = null };
            var destination3 = new Destination { Time = 24, String = "It's destination now.", Uri = null };
            var destination4 = new Destination { Time = 24, String = "It's destination now.", Uri = null };
            var SourceShort = new SourceShort { Uri = new System.Uri("https://docs.microsoft.com") };
            var destinationFull = new Destination
            {
                Time = 24,
                String = "Destination",
                Note = "note",
                Uri = new System.Uri("https://docs.microsoft.com/en-us/dotnet/api/system.type.getproperty?view=net-6.0")
            };
            var destinationFull2 = new Destination
            {
                Time = 24,
                String = "Destination",
                Note = "note",
                Uri = new System.Uri("https://docs.microsoft.com/en-us/dotnet/api/system.type.getproperty?view=net-6.0")
            };
            var sourceNotMapped = new SourceNotMapped
            {
                Timeout = 42,
                String = "Source",
                Note = "noteSource",
                Uri = new System.Uri("https://docs.microsoft.com")
            };
            var sourceNotMappedAll = new SourceNotMappedAll
            {
                Timeout = 42,
                String = "Source",
                Note = "noteSource",
                Uri = new System.Uri("https://docs.microsoft.com")
            };


            // Act + Assert
            sourceNull.CopyTo(destination);
            Assert.AreNotEqual(destination, null, "Error!");

            var resultSD = source.CopyTo(destination);
            Assert.AreEqual(source.Timeout, ((Destination)resultSD).Time, "Error!");
            Assert.AreEqual(source.Note, ((Destination)resultSD).Note, "Error!");
            Assert.AreEqual(source.String, ((Destination)resultSD).String, "Error!");
            Assert.AreEqual(source.Uri, ((Destination)resultSD).Uri, "Error!");

            SourceShort.CopyTo(destination2);
            Assert.AreEqual(destination2.Time, destination2.Time, "Error!");
            Assert.AreEqual(destination2.String, destination2.String, "Error!");
            Assert.AreEqual(SourceShort.Uri, destination2.Uri, "Error!");

            source.CopyTo(destination3);
            Assert.AreEqual(source.Timeout, destination3.Time, "Error!");
            Assert.AreEqual(source.String, destination3.String, "Error!");
            Assert.AreEqual(destination3.Uri, destination3.Uri, "Error!");

            destinationFull.CopyTo(destination4);
            Assert.AreEqual(destinationFull.Time, destination4.Time, "Error!");
            Assert.AreEqual(destinationFull.String, destination4.String, "Error!");
            Assert.AreEqual(destinationFull.Uri, destination4.Uri, "Error!");

            sourceNotMapped.CopyTo(destinationFull);
            Assert.AreEqual(sourceNotMapped.Timeout, destinationFull.Time, "Error!");
            Assert.AreNotEqual(sourceNotMapped.String, destinationFull.String, "Error!");
            Assert.AreNotEqual(sourceNotMapped.String, sourceNotMapped.Note, "Error!");
            Assert.AreEqual(sourceNotMapped.Uri, destinationFull.Uri, "Error!");


            sourceNotMappedAll.CopyTo(destinationFull2);
            Assert.AreNotEqual(sourceNotMappedAll.Timeout, destinationFull2.Time, "Error!");
            Assert.AreNotEqual(sourceNotMappedAll.String, destinationFull2.String, "Error!");
            Assert.AreNotEqual(sourceNotMappedAll.String, destinationFull2.Note, "Error!");
            Assert.AreNotEqual(sourceNotMappedAll.Uri, destinationFull2.Uri, "Error!");
        }
    }
}