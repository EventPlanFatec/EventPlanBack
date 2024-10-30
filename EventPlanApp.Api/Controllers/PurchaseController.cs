using EventPlanApp.Application.Interfaces;
using EventPlanApp.Application.Services;
using EventPlanApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanApp.Api.Controllers
{
    [ApiController]
    [Route("api/purchases")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpPost]
        public async Task<IActionResult> PurchaseTicket([FromBody] PurchaseRequest request)
        {
            var result = await _purchaseService.ProcessPurchaseAsync(request);
            if (!result.Success)
                return BadRequest(result.ErrorMessage);

            return Ok(result);
        }
    }

}
