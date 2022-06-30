namespace ShopsRUs.Controllers;

using Application.Dtos.Request;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/v1/bill")]
[ApiController]
public class BillController : Controller
{
    private readonly IBillService _billService;

    public BillController(IBillService billService)
    {
        _billService = billService;
    }
    
    [Produces("application/json")]
    [HttpPost]
    public async Task<ActionResult> GetAccountMenuHeader([FromBody] GetBillRequestDto request)
    {
        return new OkObjectResult(await _billService.GetBill(request));
    }
}