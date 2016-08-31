namespace Numberize.Services
{
    using Numberize.Model;
    using Numberize.Artifacts;
    using System;
    using System.Linq;

    public class CalculatorService: ICalculatorService
    {        
        public ResponseDto Calculate(RequestDto requestDto)
        {
            var stringResult = requestDto.Values
                .Aggregate((previous, current) => (new Number(previous) + new Number(current)).ToString());

            var result = new Number(stringResult);

            return  new ResponseDto(){ Result = result.Content } ; //TODO assembler
        }
    }
}