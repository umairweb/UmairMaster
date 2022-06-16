using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task1.Entities;

namespace Task1.Controllers
{
    [Route( "api/[controller]/[Action]" )]
    [ApiController]
    public class ExcelParserController : ControllerBase
    {
        public ExcelParserController()
        {

        }
        [HttpPost]
        public async Task<IActionResult> SaveParsedExcel([FromBody] List<TargetWarmBuyers> buyers )
        {
            try
            {
                await new BuyerManager().SaveTargetWarmBuyerAsync( buyers );
                return Ok();

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
