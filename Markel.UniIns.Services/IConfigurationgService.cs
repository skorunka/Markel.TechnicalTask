namespace Markel.UniIns.Services
{
	public interface IConfigurationgService
	{
		decimal GetInsuranceBasePremium(VehicleType vehicleType);

		decimal GetInsuranceFactor(string vehicleManufacturer);
	}
}