using CalculateInterest.Domain.Entity;
using CalculateInterest.Domain.Interface.AppService;
using CalculateInterest.Domain.Interface.DomService;
using System.Threading.Tasks;

namespace CalculateInterest.Services
{
	public class CalculateInterestAppService : ICalculateInterestAppService
	{
		private readonly ICalculateInterestDomService _calculateInterestDomService;

		public CalculateInterestAppService(ICalculateInterestDomService calculateInterestDomService)
		{
			_calculateInterestDomService = calculateInterestDomService;
		}
		public async Task<string> CalculateIterestAsync(CalculateInterestParamter input)
		{
			var result = await _calculateInterestDomService.CalculateIterestAsync(input);
			return result.Result;
		}

		public async Task<string> GetDescriptionAsync()
		{
			var result = await _calculateInterestDomService.GetDescriptionAsync();
			return result.Urls;
		}
	}
}