using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Theory]
        [InlineData("33.168176,-87.521815,Taco Bell Tuscaloosa")]
        public void ShouldParse(string str)
        {
            //Arrange
            TacoParser tacoParser = new TacoParser();

            // Act
            ITrackable actual = tacoParser.Parse(str);

            // Assert
            Assert.NotNull(actual);
        }


        [Theory]
        [InlineData("0,abc,Tacobell")]
        [InlineData("abc,0,Tacobell")]
        [InlineData("abc,abc,Tacobell")]
        [InlineData("300,0,Tacobell")]
        [InlineData("90.00001,84,Tacobell")]
        [InlineData("84,180.000001,Tacobell")]
        [InlineData(",0,Tacobell")]
        [InlineData("0,0,")]
        [InlineData("34.376395")]
        [InlineData("34.376395,-84.913185")]
        public void ShouldFailParse(string str)
        {
            //Arrange
            TacoParser tacoParser = new TacoParser();

            // Act
            ITrackable actual = tacoParser.Parse(str);

            // Assert
            Assert.Null(actual);
        }
    }
}
