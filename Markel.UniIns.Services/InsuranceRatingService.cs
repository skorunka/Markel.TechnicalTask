namespace Markel.UniIns.Services
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

		public decimal? GetInsuranceRate(VehicleType vehicleType, string vehicleManufacturer)
		{
			var basePremium = this._configurationgService.GetInsuranceBasePremium(vehicleType);
			var factor = 1.5m;

			return basePremium * factor;
		}
	}
}