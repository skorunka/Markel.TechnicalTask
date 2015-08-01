namespace Markel.UniIns.Services
{
	public interface IInsuranceRatingService
	{
		decimal GetInsuranceRate(VehicleType vehicleType, string vehicleManufacturer);
	}
}