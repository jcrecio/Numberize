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

        [Route("")]
        [Route("Operations")]
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult("Ok");
        }

        [Route("Operations/Calculate")]
        [HttpPost]
        public IActionResult Post([FromBody]RequestDto request)
        {
            return new OkObjectResult(calculatorService.Calculate(request));
        }
     }
}    
    
