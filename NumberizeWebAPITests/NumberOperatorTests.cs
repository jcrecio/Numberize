namespace NumberizeTests
{
    using Numberize.Artifacts;
    using Xunit;
    using FluentAssertions;

    public class NumberOperatorTests{
        
        [Fact]
        public void ShouldReturnTheOpposite()
        {
            var expectedResponse = new Number("1", true);

            var number = new Number("1");

            var response = -number;

            response.ShouldBeEquivalentTo(expectedResponse);
        }
    }

}