using System;
using System.IO;
using CustomSerializeTools;
using NUnit.Framework;
using TestReflection.Attributes;

namespace TestReflection.TestSerialize
{
    public class TestCustomSerialize
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetString()
        {
            var source = new Destination
            {
                Time = 24,
                String = "Destination",
                Note = "note",
                Uri = new System.Uri("https://docs.microsoft.com/en-us/dotnet/api/system.type.getproperty?view=net-6.0"),
                CreatedDT = new DateTime(2022, 12, 24, 0, 34, 56)
            };
            string fullPath = "test.json";
            // Act
            CustomSerialize.WriteToFile(fullPath, source);
            var result = CustomSerialize.ReadFromFile<Destination>(fullPath);

            // Assert
            string jsonString = File.ReadAllText(fullPath);
            Assert.True(jsonString.Contains("2022/12/24 00:34:56"));

            Assert.AreEqual(source.Time, result.Time);
            Assert.AreEqual(source.Note, result.Note);
            Assert.AreEqual(source.String, result.String);
            Assert.AreEqual(source.Uri, result.Uri);
            Assert.AreEqual(source.CreatedDT, result.CreatedDT);
        }
    }
}