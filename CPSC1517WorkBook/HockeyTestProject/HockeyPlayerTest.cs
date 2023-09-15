using FluentAssertions;
using Hockey.Data;

namespace Hockey.Test
{
    public class HockeyPlayerTest
    {
        public HockeyPlayer GenerateTestPlayer()
        {
            return new HockeyPlayer();
        }

        [Fact]
        public void HockeyPlayer_FirstName_ReturnsGoodFirstName()
        {
            // Arrange
            HockeyPlayer player = GenerateTestPlayer();
            const string NAME = "test";
            player.FirstName = NAME;

            // Act
            string actual = player.FirstName;

            // Assert
            actual.Should().Be(NAME);
        }

        [Fact]
        public void HockeyPlayer_FirstName_ThrowsExceptionForEmptyArg()
        {
            // Arrange
            HockeyPlayer player = GenerateTestPlayer();
            const string EMPTY_NAME = "";

            // Act
            Action act = () => player.FirstName = EMPTY_NAME;

            // Assert
            act.Should().Throw<ArgumentException>().WithMessage("First name cannot be null or empty.");
        }
    }
}