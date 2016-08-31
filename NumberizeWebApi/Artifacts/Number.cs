namespace Numberize.Artifacts
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    public class Number
    {
        public string Content { get; set; }

        public Number(string content)
        {
            this.Content = content;
        }

        public override string ToString()
        {
            return this.Content;
        }

        public static Number operator +(Number operand1, Number operand2)
        {
            var numbers = GetOrderedNumbers(operand1, operand2);

            var shortestNumber = numbers.ElementAt(0);
            var longestNumber = numbers.ElementAt(1);

            AdjustLengthForNumber(ref shortestNumber, longestNumber.Content.Length);

            return shortestNumber.Add(longestNumber);
        }

        private static IEnumerable<Number> GetOrderedNumbers(params Number[] operands)
        {
            return operands.OrderBy(n => n.Content.Length);
        }

        private static void AdjustLengthForNumber(ref Number number, int maxLength)
        {
            number.Content = number.Content.PadLeft(maxLength, '0');
        }

        private Number Add(Number longestNumber)
        {
            var overflow = 0;
            var result = new StringBuilder();
            
            for(int index = longestNumber.Content.Length - 1; index >= 0; index--)
            {
                var sumDigits = overflow
                   + GetCharDigitAsInt(this.Content[index])
                   + GetCharDigitAsInt(longestNumber.Content[index]);

                InsertDigitsSum(result, sumDigits);
                overflow = GetOverflowFromSum(sumDigits);
            };

            AddOverflow(result, overflow);
            return new Number(result.ToString());
        }

        private int GetCharDigitAsInt(char content)
        {
            return Convert.ToInt32(content.ToString());
        }

        private string GetOnes(int sumDigits)
        {
            return (sumDigits % 10).ToString();
        }

        private void AddOverflow(StringBuilder result, int overflow)
        {
            if(overflow != 0) result.Insert(0, "1");
        }

        private void InsertDigitsSum(StringBuilder result, int sumDigits)
        {
            var onesOfPartialSum = GetOnes(sumDigits);
            result.Insert(0, onesOfPartialSum);
        }

        private int GetOverflowFromSum(int sum)
        {
            return sum >= 10 ? 1 : 0;
        }
    }
}
