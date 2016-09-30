namespace Numberize.Artifacts
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    public class Number
    {
        public string Content { get; set; }
        public bool IsNegative { get; private set; }

        public Number(string content)
        {
            this.Content = content;
        }

        public Number(string content, bool isNegative)
        {
            this.IsNegative = isNegative;
        }

        public override string ToString()
        {
            return this.Content;
        }

        public static Number operator +(Number operand1, Number operand2)
        {
            var operationMembers = GetOperationMembers(operand1, operand2);
            return operationMembers.ShortestNumber.Add(operationMembers.LongestNumber);
        }

        private Number Add(Number number)
        {
            var overflow = 0;
            var result = new StringBuilder();

            for (int index = number.Content.Length - 1; index >= 0; index--)
            {
                var sumDigits = GetSumDigits(number.Content[index], Content[index], overflow);

                InsertDigitsSum(result, sumDigits);
                overflow = GetOverflowFromSum(sumDigits);
            };

            AddOverflow(result, overflow);
            return new Number(result.ToString());
        }

        private int GetSumDigits(char digit1, char digit2, int overflow)
        {
            return overflow + GetCharDigitAsInt(digit1) + GetCharDigitAsInt(digit2);
        }

        private int GetCharDigitAsInt(char content)
        {
            return Convert.ToInt32(content.ToString());
        }

        private int GetCharDigitAsInt(int index)
        {
            var digit = this.Content[index];
            var absoluteValue = Convert.ToInt32(digit.ToString());

            if (IsNegative)
            {
                absoluteValue = -absoluteValue;
            }

            return absoluteValue;
        }

        private void InsertDigitsSum(StringBuilder result, int amount)
        {
            var onesOfPartialSum = GetOnes(amount);
            result.Insert(0, onesOfPartialSum);
        }

        private string GetOnes(int sumDigits)
        {
            return (sumDigits % 10).ToString();
        }

        private int GetOverflowFromSum(int sum)
        {
            return sum >= 10 ? 1 : 0;
        }

        private void AddOverflow(StringBuilder result, int overflow)
        {
            if (overflow != 0)
            {
                result.Insert(0, "1");
            }
        }

        public static Number operator -(Number operand1)
        {
            return new Number(operand1.Content, !operand1.IsNegative);
        }

        public static Number operator -(Number operand1, Number operand2)
        {
            var operationMembers = GetOperationMembers(operand1, operand2);

            var substraction = operationMembers.LongestNumber.Substract(operationMembers.ShortestNumber);
            var result = AdjustOutput(substraction);

            return result;
        }

        private static OperationMembers GetOperationMembers(Number operand1, Number operand2)
        {
            var numbersOrderedByLength = GetNumbersOrderedByLength(operand1, operand2);

            var shortestNumber = numbersOrderedByLength.ElementAt(1);
            var longestNumber = numbersOrderedByLength.ElementAt(0);

            AdjustLengthForNumber(ref shortestNumber, longestNumber.Content.Length);

            return new OperationMembers
            {
                ShortestNumber = shortestNumber,
                LongestNumber = longestNumber
            };
        }
        private static IEnumerable<Number> GetNumbersOrderedByLength(params Number[] operands)
        {
            return operands.OrderByDescending(n => n.Content.Length);
        }

        private static void AdjustLengthForNumber(ref Number number, int maxLength)
        {
            number.Content = number.Content.PadLeft(maxLength, '0');
        }

        private Number Substract(Number shortestNumber)
        {
            var overflow = 0;
            var result = new StringBuilder();

            for (int index = Content.Length - 1; index >= 0; index--)
            {
                var partialOperandOne = GetCharDigitAsInt(index);
                var partialOperandTwo = overflow + shortestNumber.GetCharDigitAsInt(index);

                overflow = GetOverflowForSubstraction(partialOperandOne, partialOperandTwo);

                result.Insert(0, GetSubstraction(partialOperandOne, partialOperandTwo, overflow));
            };

            return new Number(result.ToString());
        }

        private int GetOverflowForSubstraction(int partialOperandOne, int partialOperandTwo)
        {
            return partialOperandOne < partialOperandTwo ? 1 : 0;
        }

        private int GetSubstraction(int operand1, int operand2, int overflow)
        {
            if (overflow == 1)
            {
                operand1 += 10;
            }

            return operand1 - operand2;
        }

        private static Number AdjustOutput(Number number)
        {
            if (number.Content.Length == 1)
            {
                return new Number(number.Content);
            }

            return new Number(number.Content.TrimStart('0'));
        }

        private class OperationMembers
        {
            public Number ShortestNumber { get; set; }
            public Number LongestNumber { get; set; }
        }
    }
}
