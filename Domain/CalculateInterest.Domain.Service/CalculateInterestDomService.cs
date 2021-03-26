using CalculateInterest.Domain.Entity;
using CalculateInterest.Domain.Interface.DomService;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CalculateInterest.Domain.Service
{
	public class CalculateInterestDomService : ICalculateInterestDomService
	{
		private readonly IConfiguration _configuration;

		public CalculateInterestDomService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public async Task<CalculateInterests> CalculateIterestAsync(CalculateInterestParamter input)
		{
			var rate = 0.0;
			var url = _configuration.GetSection("RateUrl:Url").Value;
			using (var client = new HttpClient())
			{
				client.BaseAddress = new System.Uri(url);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				var response = await client.GetAsync("api/InterestRate/GetRate/");
				rate = Convert.ToDouble(response.Content.ReadAsStringAsync().Result) / 100;
				var model = new CalculateInterests();
				var temp = Convert.ToDouble(input.Temp);
				for (int i = 0; i <= input.Temp; i++)
				{
					model.Result = (Convert.ToDouble(input.Value) * Math.Pow((1 + rate / temp), (temp * i))).ToString("#.##");
				}
				return await Task.FromResult(model);
			}
		}

		public async Task<CalculateInterests> GetDescriptionAsync()
		{
			return await Task.FromResult(new CalculateInterests()
			{
				Urls = "https://github.com/zecabr/SoftPlan \r\n" +
					   "https://github.com/zecabr/SoftPlanCalculateInterest"
			});

		}

		private void teste()
		{
		}
	}
}