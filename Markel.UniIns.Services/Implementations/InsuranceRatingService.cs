namespace Markel.UniIns.Services.Implementations
{
	using System;

	public class InsuranceRatingService : IInsuranceRatingService
	{
		private readonly IConfigurationgService _configurationgService;

		public InsuranceRatingService(IConfigurationgService configurationgService)
		{
			if (configurationgService == null)
			{
				throw new ArgumentNullException(nameof(configurationgService));
			}

			this._configurationgService = configurationgService;
		}

		public decimal GetInsuranceRate(VehicleType vehicleType, string vehicleManufacturer)
		{
			var basePremiumForVehicleType = this._configurationgService.GetInsuranceBasePremium(vehicleType);
			var factorForVehicleManufacturer = this._configurationgService.GetInsuranceFactor(vehicleManufacturer);

			return basePremiumForVehicleType * factorForVehicleManufacturer;
		}
	}
}