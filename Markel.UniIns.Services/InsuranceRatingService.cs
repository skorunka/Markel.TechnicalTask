namespace Markel.UniIns.Services
{
	public class InsuranceRatingService : IInsuranceRatingService
	{
		public decimal? GetInsuranceRate(string vehicleType, string venicleManufacturer)
		{
			return 10;
		}
	}
}