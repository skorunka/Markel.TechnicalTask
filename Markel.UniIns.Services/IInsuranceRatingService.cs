namespace Markel.UniIns.Services
{
	public interface IInsuranceRatingService
	{
		decimal? GetInsuranceRate(string vehicleType, string venicleManufacturer);
	}
}