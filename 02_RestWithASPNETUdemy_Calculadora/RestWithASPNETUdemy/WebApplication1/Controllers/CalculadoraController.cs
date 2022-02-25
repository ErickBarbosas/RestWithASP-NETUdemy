using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculadoraController : ControllerBase
    {
       

        private readonly ILogger<CalculadoraController> _logger;

        public CalculadoraController(ILogger<CalculadoraController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{operacao}/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string operacao,string firstNumber,string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                switch (operacao)
                {
                    case "sum":
                        var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                        return Ok(sum.ToString());
                        break;
                    case "mul":
                        var mul = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                        return Ok(mul.ToString());
                        break;
                    case "div":
                        var div = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                        return Ok(div.ToString());
                        break;

                    default:
                        return Ok("Operacao INvalida");
                        break;
                }
            }

            


            return BadRequest("Invalid Input");
        }

   

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);

            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;

            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }

            return 0;
        }
       

       

       
    }
}
