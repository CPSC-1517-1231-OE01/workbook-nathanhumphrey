using FluentAssertions;
using Utils;
namespace UtilitiesTestProject
{
    public class UtilitiesTest
    {
        // DateOnly data generator
        public static IEnumerable<object[]> GenerateIsInTheFutureTestData()
        {
            // present
            yield return new object[]
            {
                DateOnly.FromDateTime(DateTime.Now),
                false,
            };
            // past
            yield return new object[]
            {
                DateOnly.FromDateTime(DateTime.Now).AddDays(-1),
                false,
            };
            // future
            yield return new object[]
            {
                DateOnly.FromDateTime(DateTime.Now).AddDays(1),
                true,
            };
        }

        [Theory]
        [MemberData(nameof(GenerateIsInTheFutureTestData))]
        public void Utilities_IsInTheFuture_ReturnsTrueForFutureFalseOtherwise(DateOnly value, bool expected)
        {
            // Arrange
            bool actual;

            // Act
            actual = Utilities.IsInTheFuture(value);

            // Assert
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Utilities_IsNullEmptyOrWhiteSpace_ReturnsTrueForNullEmptyOrWhiteSpace(string value)
        {
            // Arrange
            bool actual;

            // Act
            actual = Utilities.IsNullEmptyOrWhiteSpace(value);

            // Assert
            actual.Should().BeTrue();
        }

        [Fact]
        public void Utilities_IsNullEmptyOrWhiteSpace_ReturnsFalseForNonEmpty()
        {
            // Arrange
            bool actual;
            const string GOOD_STRING = "x";

            // Act
            actual = Utilities.IsNullEmptyOrWhiteSpace(GOOD_STRING);

            // Assert
            actual.Should().BeFalse();
        }
    }
}