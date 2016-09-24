namespace NumberizeTests
{
    using Numberize.Artifacts;
    using Xunit;
    using FluentAssertions;

    public class NumberSubstractTests{

        [Fact]
        public void ShouldReturn_0_From_0_0()
        {
            var expectedResponse = new Number("0");

            var firstNumber = new Number("0");
            var secondNumber = new Number("0");

            var response = firstNumber - secondNumber;
            response.ShouldBeEquivalentTo(expectedResponse);
        }
    }
}