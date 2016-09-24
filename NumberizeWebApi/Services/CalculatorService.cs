namespace Numberize.Services
{
    using Numberize.Model;
    using Numberize.Artifacts;
    using System.Linq;
    using System;

    public class CalculatorService: ICalculatorService
    {        
        public ResponseDto Calculate(RequestDto requestDto)
        {
            Func<Number, Number, Number> operatorToApply = GetOperatorToApply(requestDto.Operation);

            var content = requestDto.Values.Aggregate((previous, current) => 
                operatorToApply(new Number(previous), new Number(current)).ToString());

            var result = new Number(content);

            return  new ResponseDto(){ Result = result.Content } ; //TODO assembler
        }
 
        private Func<Number, Number, Number> GetOperatorToApply(string operation){
            if(operation == "add"){
                return (a, b) => a + b;
            }
            
            return (a, b) => a - b;
        }
    }
}