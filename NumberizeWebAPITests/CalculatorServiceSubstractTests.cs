namespace NumberizeTests
{
    using Numberize.Services;
    using Numberize.Model;
    using Xunit;
    using FluentAssertions;
    public class Substract
    {
        private ICalculatorService Target { get; } = new CalculatorService();

        [Fact]
        public void ShouldGet_0_From_0()
        {
            var responseDto = new ResponseDto()
            {
                Result = "0"
            };

            var requestDto = new RequestDto()
            {
                Values = new[] { "0", "0" },
                Operation = "substract"
            };

            var result = Target.Calculate(requestDto);

            result.ShouldBeEquivalentTo(responseDto);
        }

        [Fact]
        public void ShouldGet_1_From_1_0()
        {
            var expectedResponse = new ResponseDto()
            {
                Result = "1"
            };

            var request = new RequestDto()
            {
                Values = new[] { "1", "0" },
                Operation = "substract"
            };

            var result = Target.Calculate(request);

            result.ShouldBeEquivalentTo(expectedResponse);
        }

        [Fact]
        public void ShouldGet_0_From_1_1()
        {
            var expectedResponse = new ResponseDto()
            {
                Result = "0"
            };

            var request = new RequestDto()
            {
                Values = new[] { "1", "1" },
                Operation = "substract"
            };

            var result = Target.Calculate(request);
            result.ShouldBeEquivalentTo(expectedResponse);
        }

        [Fact]
        public void ShouldGet_1_From_2_1()
        {
            var expectedResponse = new ResponseDto()
            {
                Result = "1"
            };

            var request = new RequestDto()
            {
                Values = new[] { "2", "1" },
                Operation = "substract"
            };

            var result = Target.Calculate(request);
            result.ShouldBeEquivalentTo(expectedResponse);
        }

        [Fact]
        public void ShouldGet_2_From_3_1()
        {
            var expectedResponse = new ResponseDto()
            {
                Result = "2"
            };

            var request = new RequestDto()
            {
                Values = new[] { "3", "1" },
                Operation = "substract"
            };

            var result = Target.Calculate(request);
            result.ShouldBeEquivalentTo(expectedResponse);
        }

        [Fact]
        public void ShouldGet_7_From_9_2()
        {
            var expectedResponse = new ResponseDto()
            {
                Result = "7"
            };

            var request = new RequestDto()
            {
                Values = new[] { "9", "2" },
                Operation = "substract"
            };

            var result = Target.Calculate(request);
            result.ShouldBeEquivalentTo(expectedResponse);
        }

        [Fact]
        public void ShouldGet_2_From_5_1_2()
        {
            var expectedResponse = new ResponseDto()
            {
                Result = "2"
            };

            var request = new RequestDto()
            {
                Values = new[] { "5", "1", "2" },
                Operation = "substract"
            };

            var result = Target.Calculate(request);
            result.ShouldBeEquivalentTo(expectedResponse);
        }
    }
}