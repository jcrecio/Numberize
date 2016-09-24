namespace NumberizeTests
{
    using Numberize.Services;
    using Numberize.Model;
    using Xunit;
    using FluentAssertions;

    public class CalculatorAddServiceTests
    {
        private ICalculatorService Target { get; } = new CalculatorService();

        [Fact]
        public void ShouldGet_0_From_0_0()
        {
            var expectedResponse = new ResponseDto()
            {
                Result = "0"
            };

            var requestDto = new RequestDto()
            {
                Values = new[] { "0", "0" },
                Operation = "add"
            };

            var response = this.Target.Calculate(requestDto);

            response.ShouldBeEquivalentTo(expectedResponse);
        }

        [Fact]
        public void ShouldGet_0_From_0()
        {
            var responseDto = new ResponseDto()
            {
                Result = "0"
            };

            var requestDto = new RequestDto()
            {
                Values = new[] { "0" },
                Operation = "add"
            };

            var result = this.Target.Calculate(requestDto);
            result.ShouldBeEquivalentTo(responseDto);
        }

        [Fact]
        public void ShouldGet_1_From_0_1()
        {
            var responseDto = new ResponseDto()
            {
                Result = "1"
            };

            var requestDto = new RequestDto()
            {
                Values = new[] { "0", "1" },
                Operation = "add"
            };

            var result = this.Target.Calculate(requestDto);

            result.ShouldBeEquivalentTo(responseDto);
        }

        [Fact]
        public void ShouldGet_1_From_1_0()
        {
            var responseDto = new ResponseDto()
            {
                Result = "1"
            };

            var requestDto = new RequestDto()
            {
                Values = new[] { "1", "0" },
                Operation = "add"
            };

            var result = this.Target.Calculate(requestDto);

            result.ShouldBeEquivalentTo(responseDto);
        }

        [Fact]
        public void ShouldGet_2_From_1_1()
        {
            var responseDto = new ResponseDto()
            {
                Result = "2"
            };

            var requestDto = new RequestDto()
            {
                Values = new[] { "1", "1" },
                Operation = "add"
            };

            var result = this.Target.Calculate(requestDto);

            result.ShouldBeEquivalentTo(responseDto);
        }

        [Fact]
        public void ShouldGet_3_From_1_2()
        {
            var responseDto = new ResponseDto()
            {
                Result = "3"
            };

            var requestDto = new RequestDto()
            {
                Values = new[] { "1", "2" },
                Operation = "add"
            };

            var result = this.Target.Calculate(requestDto);

            result.ShouldBeEquivalentTo(responseDto);
        }

        [Fact]
        public void ShouldGet_0_From_0_0_0()
        {
            var responseDto = new ResponseDto()
            {
                Result = "0"
            };

            var requestDto = new RequestDto()
            {
                Values = new[] { "0", "0", "0" },
                Operation = "add"
            };

            var result = this.Target.Calculate(requestDto);

            result.ShouldBeEquivalentTo(responseDto);
        }

        [Fact]
        public void ShouldGet_1_From_1_0_0()
        {
            var responseDto = new ResponseDto()
            {
                Result = "1"
            };

            var requestDto = new RequestDto()
            {
                Values = new[] { "1", "0", "0" },
                Operation = "add"
            };

            var result = this.Target.Calculate(requestDto);

            result.ShouldBeEquivalentTo(responseDto);
        }

        [Fact]
        public void ShouldGet_1_From_0_1_0()
        {
            var responseDto = new ResponseDto()
            {
                Result = "1"
            };

            var requestDto = new RequestDto()
            {
                Values = new[] { "0", "1", "0" },
                Operation = "add"
            };

            var result = this.Target.Calculate(requestDto);

            result.ShouldBeEquivalentTo(responseDto);
        }

        [Fact]
        public void ShouldGet_1_From_0_0_1()
        {
            var responseDto = new ResponseDto()
            {
                Result = "1"
            };

            var requestDto = new RequestDto()
            {
                Values = new[] { "0", "0", "1" },
                Operation = "add"
            };

            var result = this.Target.Calculate(requestDto);

            result.ShouldBeEquivalentTo(responseDto);
        }

        [Fact]
        public void ShouldGet_2_From_1_1_0()
        {
            var responseDto = new ResponseDto()
            {
                Result = "2"
            };

            var requestDto = new RequestDto()
            {
                Values = new[] { "1", "1", "0" },
                Operation = "add"
            };

            var result = this.Target.Calculate(requestDto);

            result.ShouldBeEquivalentTo(responseDto);
        }

        [Fact]
        public void ShouldGet_2_From_0_1_1()
        {
            var responseDto = new ResponseDto()
            {
                Result = "2"
            };

            var requestDto = new RequestDto()
            {
                Values = new[] { "0", "1", "1" },
                Operation = "add"
            };

            var result = this.Target.Calculate(requestDto);

            result.ShouldBeEquivalentTo(responseDto);
        }

        [Fact]
        public void ShouldGet_3_From_1_1_1()
        {
            var responseDto = new ResponseDto()
            {
                Result = "3"
            };

            var requestDto = new RequestDto()
            {
                Values = new[] { "1", "1", "1" },
                Operation = "add"
            };

            var result = this.Target.Calculate(requestDto);

            result.ShouldBeEquivalentTo(responseDto);
        }

        [Fact]
        public void ShouldGet_10_From_5_3_2()
        {
            var responseDto = new ResponseDto()
            {
                Result = "10"
            };

            var requestDto = new RequestDto()
            {
                Values = new[] { "5", "3", "2" },
                Operation = "add"
            };

            var result = this.Target.Calculate(requestDto);

            result.ShouldBeEquivalentTo(responseDto);
        }

        [Fact]
        public void ShouldGet_0_From_0_0_0_0_0()
        {
            var responseDto = new ResponseDto()
            {
                Result = "0"
            };

            var requestDto = new RequestDto()
            {
                Values = new[] { "0", "0", "0", "0", "0" },
                Operation = "add"
            };

            var result = this.Target.Calculate(requestDto);

            result.ShouldBeEquivalentTo(responseDto);
        }

        [Fact]
        public void ShouldNotRaiseAnException_WhenAnyOperand_IsGreaterThanMaxInt()
        {
            var requestDto = new RequestDto()
            {
                Values = new[] { "9223372036854775808" }, // MaxInt64 = 9,223,372,036,854,775,807
                Operation = "add"
            };

            this.Target.Calculate(requestDto);
        }

        [Fact]
        public void ShouldNotRaiseAnException_WhenSomeOperands_AreGreaterThanMaxInt()
        {
            var requestDto = new RequestDto()
            {
                Values = new[]{
                            "9223372036854775808",
                            "9223372036854775809",
                            "9223372036854775808000000000000000000000"},
                Operation = "add"
            };

            this.Target.Calculate(requestDto);
        }
    }
}