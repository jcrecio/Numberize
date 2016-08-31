namespace Numberize.Services
{
    using Numberize.Model;
    
    public interface ICalculatorService
    {
        ResponseDto Calculate(RequestDto requestDto);
    }
}