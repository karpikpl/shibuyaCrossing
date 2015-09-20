using System.IO;
using System.Text;
using NUnit.Framework;

namespace KattisSolution.Tests
{
    [TestFixture]
    [Category("sample")]
    public class CustomTest
    {
        [Test]
        public void SampleTest_WithStringData_Should_Pass()
        {
            // Arrange
            const string expectedAnswer = "13\n";
            StringBuilder inputString = new StringBuilder("800 9588\n");
            for (int i = 1; i <= 12; i++)
                for (int j = 1; j <= 800; j++)
                {
                    if (i != j)
                    {
                        inputString.Append(i).Append(" ").Append(j).Append("\n");
                    }
                }


            using (var input = new MemoryStream(Encoding.UTF8.GetBytes(inputString.ToString())))
            using (var output = new MemoryStream())
            {
                // Act
                Program.Solve(input, output);
                var result = Encoding.UTF8.GetString(output.ToArray());

                // Assert
                Assert.That(result, Is.EqualTo(expectedAnswer));
            }
        }

        [Test]
        public void SampleTest_WithStringData_Should_Pass2()
        {
            // Arrange
            const string expectedAnswer = "2\n";
            StringBuilder inputString = new StringBuilder("800 799\n");
            for (int i = 1; i <= 800; i++)
            {
                inputString.Append("1 ").Append(i).Append("\n");
            }


            using (var input = new MemoryStream(Encoding.UTF8.GetBytes(inputString.ToString())))
            using (var output = new MemoryStream())
            {
                // Act
                Program.Solve(input, output);
                var result = Encoding.UTF8.GetString(output.ToArray());

                // Assert
                Assert.That(result, Is.EqualTo(expectedAnswer));
            }
        }

        [Test]
        public void SampleTest_WithStringData_Should_Pass_When_OnePerson()
        {
            // Arrange
            const string expectedAnswer = "1\n";

            using (var input = new MemoryStream(Encoding.UTF8.GetBytes("1 0\n")))
            using (var output = new MemoryStream())
            {
                // Act
                Program.Solve(input, output);
                var result = Encoding.UTF8.GetString(output.ToArray());

                // Assert
                Assert.That(result, Is.EqualTo(expectedAnswer));
            }
        }

        [Test]
        public void SampleTest_WithStringData_Should_Pass_When_ZereBumps()
        {
            // Arrange
            const string expectedAnswer = "0\n";

            using (var input = new MemoryStream(Encoding.UTF8.GetBytes("2 0\n")))
            using (var output = new MemoryStream())
            {
                // Act
                Program.Solve(input, output);
                var result = Encoding.UTF8.GetString(output.ToArray());

                // Assert
                Assert.That(result, Is.EqualTo(expectedAnswer));
            }
        }

        [Test]
        public void SampleTest_WithStringData_Should_Pass5()
        {
            // Arrange
            const string expectedAnswer = "2\n";

            using (var input = new MemoryStream(Encoding.UTF8.GetBytes("3 2\n1 2\n2 3\n")))
            using (var output = new MemoryStream())
            {
                // Act
                Program.Solve(input, output);
                var result = Encoding.UTF8.GetString(output.ToArray());

                // Assert
                Assert.That(result, Is.EqualTo(expectedAnswer));
            }
        }

        [Test]
        public void SampleTest_WithStringData_Should_Pass6()
        {
            // Arrange
            const string expectedAnswer = "5\n";

            using (var input = new MemoryStream(Encoding.UTF8.GetBytes("9 15\n1 7\n3 9\n2 9\n1 2\n2 3\n5 6\n1 5\n1 4\n1 6\n4 6\n5 7\n6 7\n4 5\n4 7\n1 3\n")))
            using (var output = new MemoryStream())
            {
                // Act
                Program.Solve(input, output);
                var result = Encoding.UTF8.GetString(output.ToArray());

                // Assert
                Assert.That(result, Is.EqualTo(expectedAnswer));
            }
        }

        [Test]
        public void SampleTest_WithStringData_Should_Pass7()
        {
            // Arrange
            const string expectedAnswer = "3\n";

            using (var input = new MemoryStream(Encoding.UTF8.GetBytes("9 13\n1 7\n3 9\n2 9\n1 2\n2 3\n5 6\n1 4\n1 6\n5 7\n6 7\n4 5\n4 7\n1 3\n")))
            using (var output = new MemoryStream())
            {
                // Act
                Program.Solve(input, output);
                var result = Encoding.UTF8.GetString(output.ToArray());

                // Assert
                Assert.That(result, Is.EqualTo(expectedAnswer));
            }
        }

        [Test]
        public void SampleTest_WithStringData_Should_Pass8()
        {
            // Arrange
            const string expectedAnswer = "2\n";

            using (var input = new MemoryStream(Encoding.UTF8.GetBytes("9 10\n1 7\n3 9\n2 9\n1 2\n5 6\n1 4\n1 6\n5 7\n4 5\n1 3\n")))
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
