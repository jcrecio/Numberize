namespace NumberizeTests
{
    using Numberize.Artifacts;
    using Xunit;
    using FluentAssertions;

    public class NumberTests
    {
        public class Add
        {
            [Fact]
            public void ShouldGet0_From_0plus0()
            {
                var number1 = new Number("0");
                var number2 = new Number("0");

                var result = number1 + number2;

                result.Content.Should().Be("0");
            }

           [Fact]
            public void ShouldGet1_From_1plus0()
            {
                var number1 = new Number("1");
                var number2 = new Number("0");

                var result = number1 + number2;

                result.Content.Should().Be("1");
            }

            [Fact]
            public void ShouldGet1_From_0plus1()
            {
                var number1 = new Number("0");
                var number2 = new Number("1");

                var result = number1 + number2;

                result.Content.Should().Be("1");
            }

            [Fact]
            public void ShouldGet2_From_1plus1()
            {
                var number1 = new Number("1");
                var number2 = new Number("1");

                var result = number1 + number2;

                result.Content.Should().Be("2");
            }

            [Fact]
            public void ShouldGet5_From_3plus2()
            {
                var number1 = new Number("3");
                var number2 = new Number("2");

                var result = number1 + number2;

                result.Content.Should().Be("5");
            }

            [Fact]
            public void ShouldGet333_From_111plus222()
            {
                var number1 = new Number("111");
                var number2 = new Number("222");

                var result = number1 + number2;

                result.Content.Should().Be("333");
            }

           [Fact]
            public void ShouldGet333_From_444plus666()
            {
                var number1 = new Number("444");
                var number2 = new Number("666");

                var result = number1 + number2;

                result.Content.Should().Be("1110");
            }

            
           [Fact]
            public void ShouldGet1010_From_999plus11()
            {
                var number1 = new Number("999");
                var number2 = new Number("11");

                var result = number1 + number2;

                result.Content.Should().Be("1010");
            }

            [Fact]
            public void ShouldNotRaiseExceptionForNumbersBiggerThanMaxInt()
            {
                var number1 =  new Number("9223372036854775808");
                var number2 = new Number("12223372036854775808");

                var result = number1 + number2;
            }

            [Fact]
            public void ShouldGetTheCorrectSumForBigNumbers()
            {
                var number1 =  new Number("9223372036854775808");
                var number2 = new Number("12223372036854775808");

                var result = number1 + number2;
                result.Content.Should().Be("21446744073709551616");
            }
        }
    }
}