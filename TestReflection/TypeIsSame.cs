using NUnit.Framework;
using Reflection;
using TestReflection.Base;

namespace TestReflection
{
    public class TypeIsSame
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestA()
        {
            // Act
            var resultSD = typeof(Source).IsSame(typeof(Destination));
            var resultDS = typeof(Destination).IsSame(typeof(Source));
            var resultSsD = typeof(SourceShort).IsSame(typeof(Destination));
            var resultDsS = typeof(DestinationShort).IsSame(typeof(Source));
            var resultDsDs = typeof(DestinationShort).IsSame(typeof(DestinationShort));

            var resultSDs = typeof(Source).IsSame(typeof(DestinationShort));
            var resultSDot = typeof(Source).IsSame(typeof(DestinationOtherType));
            var resultSDots = typeof(Source).IsSame(typeof(DestinationOtherTypeShort));

            // Assert
            Assert.AreEqual(true, resultSD, "Type not equal.");
            Assert.AreEqual(true, resultDS, "Type not equal.");
            Assert.AreEqual(true, resultSsD, "Type not equal.");
            Assert.AreEqual(true, resultDsS, "Type not equal.");
            Assert.AreEqual(true, resultDsDs, "Type not equal.");

            Assert.AreEqual(false, resultSDs, "Type not equal.");
            Assert.AreEqual(false, resultSDot, "Type not equal.");
            Assert.AreEqual(false, resultSDots, "Type not equal.");
        }

        [Test]
        public void TestB()
        {
            Source sourceNull = null;
            var source = new Source { Timeout = 42, String = "Source" };
            var destination = new Destination { Timeout = 24, String = "It's destination now.", Uri = null };
            var destination2 = new Destination { Timeout = 24, String = "It's destination now.", Uri = null };
            var destination3 = new Destination { Timeout = 24, String = "It's destination now.", Uri = null };
            var SourceShort = new SourceShort { Uri = new System.Uri("https://docs.microsoft.com") };
            var destinationFull = new Destination
            {
                Timeout = 24,
                String = "Destination",
                Uri = new System.Uri("https://docs.microsoft.com/en-us/dotnet/api/system.type.getproperty?view=net-6.0")
            };

            // Act
            sourceNull.CopyTo(destination);

            var resultSD = source.CopyTo(destination);
            SourceShort.CopyTo(destination2);
            source.CopyTo(destinationFull);
            destinationFull.CopyTo(destination3);

            // Assert
            Assert.AreEqual(destination.Timeout, destination.Timeout, "Error!");
            Assert.AreEqual(destination.String, destination.String, "Error!");
            Assert.AreEqual(destination.Uri, destination.Uri, "Error!");

            Assert.AreEqual(source.Timeout, ((Destination)resultSD).Timeout, "Error!");
            Assert.AreEqual(source.String, ((Destination)resultSD).String, "Error!");
            Assert.AreEqual(source.Uri, ((Destination)resultSD).Uri, "Error!");

            Assert.AreEqual(destination2.Timeout, destination2.Timeout, "Error!");
            Assert.AreEqual(destination2.String, destination2.String, "Error!");
            Assert.AreEqual(SourceShort.Uri, destination2.Uri, "Error!");

            Assert.AreEqual(source.Timeout, destinationFull.Timeout, "Error!");
            Assert.AreEqual(source.String, destinationFull.String, "Error!");
            Assert.AreEqual(destinationFull.Uri, destinationFull.Uri, "Error!");

            Assert.AreEqual(destinationFull.Timeout, destination3.Timeout, "Error!");
            Assert.AreEqual(destinationFull.String, destination3.String, "Error!");
            Assert.AreEqual(destinationFull.Uri, destination3.Uri, "Error!");
        }
    }
}