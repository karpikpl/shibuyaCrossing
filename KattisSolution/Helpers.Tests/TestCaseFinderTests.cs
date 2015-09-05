using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace KattisSolution.Helpers.Tests
{
    [TestFixture]
    [Category("integration")]
    public class TestCaseFinderTests
    {
        private const string TestCaseIn = "12345.in";
        private const string TestCaseOut = "12345.ans";

        [TestFixtureSetUp]
        public void SetUp()
        {
            using (var f = File.CreateText(TestCaseIn))
            {
                f.Write("11\n");
            }
            using (var f = File.CreateText(TestCaseOut))
            {
                f.Write("55\n");
            }
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            if (File.Exists(TestCaseIn))
                File.Delete(TestCaseIn);
            if (File.Exists(TestCaseOut))
                File.Delete(TestCaseOut);
        }

        [Test]
        public void Should_FindTestCasesInTheSolutionDir()
        {
            // Arrange


            // Act
            var result = TestCaseFinder.GetTestCases();

            // Assert
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Any(r => r.In.EndsWith(TestCaseIn) && r.Out.EndsWith(TestCaseOut)), Is.True);
        }
    }
}
