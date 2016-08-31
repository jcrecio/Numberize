using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Numberize.Model;
using Numberize.Services;

namespace Numberize
{
    public class OperationsController
    {
        private ICalculatorService calculatorService;

        public OperationsController(ICalculatorService calculatorService)
        {
            this.calculatorService = calculatorService;
        }

        [HttpPost]
        public IActionResult Post(RequestDto request)
        {
            return new OkObjectResult(calculatorService.Calculate(request));
        }
     }
}    
    
