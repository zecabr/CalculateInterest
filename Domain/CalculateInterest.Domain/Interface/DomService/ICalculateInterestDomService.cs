using CalculateInterest.Domain.Entity;
using System.Threading.Tasks;

namespace CalculateInterest.Domain.Interface.DomService
{
	public interface ICalculateInterestDomService
	{
		Task<CalculateInterests> CalculateIterestAsync(CalculateInterestParamter input);
		Task<CalculateInterests> GetDescriptionAsync();
	}
}