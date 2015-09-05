using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Core;
using NUnit.Framework;

namespace KattisSolution.Tests
{
    [Ignore]
    [TestFixture]
    public class CustomTest
    {
        [Test]
        public void Should_Pass()
        {
            // Arrange
            const string expectedAnswer = "50\n";
            using (var input = new MemoryStream(Encoding.UTF8.GetBytes("10\n")))
            using (var output = new MemoryStream())
            {
                // Act
                Program.Solve(input, output);
                var result = Encoding.UTF8.GetString(output.ToArray());

                // Assert
                Assert.That(result, Is.EqualTo(expectedAnswer));
            }
        }
    }
}
