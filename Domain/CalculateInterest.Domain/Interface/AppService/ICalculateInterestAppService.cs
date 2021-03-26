using CalculateInterest.Domain.Entity;
using System.Threading.Tasks;

namespace CalculateInterest.Domain.Interface.AppService
{
	public interface ICalculateInterestAppService
	{
		Task<string> CalculateIterestAsync(CalculateInterestParamter input);
		Task<string> GetDescriptionAsync();
	}
}