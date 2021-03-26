using CalculateInterest.Domain.Entity;
using CalculateInterest.Domain.Interface.AppService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CalculateInterest.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CalculateInterestController : ControllerBase
	{
		private readonly ICalculateInterestAppService _calculateInterestAppService;

		public CalculateInterestController(ICalculateInterestAppService calculateInterestAppService)
		{
			_calculateInterestAppService = calculateInterestAppService;
		}
		[HttpPost("Calculate")]
		public async Task<string> CalculateAsync([FromForm] CalculateInterestParamter input)
		{
			return await _calculateInterestAppService.CalculateIterestAsync(input);
		}
		[HttpGet("GetUrl")]
		public async Task<string> GetUrlAsync()
		{
			return await _calculateInterestAppService.GetDescriptionAsync();
		}
	}
}