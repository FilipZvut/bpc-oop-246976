using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cv12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcController : ControllerBase
    {
        [HttpPost(Name = "Calculate")]
        public decimal Post([FromBody] CalcDTO calcDTO)
        {
            decimal vysledek = 0;

            switch(calcDTO.Operation) 
            {
                case "plus":
                    vysledek = calcDTO.Operand1 + calcDTO.Operand2;
                    break;
                case "minus":
                    vysledek = calcDTO.Operand1 - calcDTO.Operand2;
                    break;
                case "krat":
                    vysledek = calcDTO.Operand1 * calcDTO.Operand2;
                    break;
                case "deleno":
                    if (calcDTO.Operand2 != 0)
                        vysledek = calcDTO.Operand1 / calcDTO.Operand2;
                    else
                        vysledek = 0;
                    break;
                default:
                    return 0;
            }
            return vysledek;
        }

    }
}
