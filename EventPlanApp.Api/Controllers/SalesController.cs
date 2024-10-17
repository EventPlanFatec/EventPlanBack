using EventPlanApp.Application.Interfaces;
using EventPlanApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly IIngressoService _ingressoService;

        public SalesController(IIngressoService ingressoService)
        {
            _ingressoService = ingressoService;
        }

        [HttpGet("sales")]
        public async Task<IActionResult> GetSalesReport()
        {
            var report = await _ingressoService.GetSalesReportAsync();
            return Ok(report);
        }
    }
}
