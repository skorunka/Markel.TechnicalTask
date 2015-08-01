namespace Markel.UniIns.Services.Implementations
{
	using System;

	public class ConfigurationgService : IConfigurationgService
	{
		private readonly IConfigurationRepository _configurationRepository;

		public ConfigurationgService(IConfigurationRepository configurationRepository)
		{
			if (configurationRepository == null)
			{
				throw new ArgumentNullException(nameof(configurationRepository));
			}

			this._configurationRepository = configurationRepository;
		}

		public decimal GetInsuranceBasePremium(VehicleType vehicleType)
		{
			if (!this._configurationRepository.VehicleTypeBasePremiums.ContainsKey(vehicleType))
			{
				throw new ArgumentException(nameof(vehicleType));
			}

			return this._configurationRepository.VehicleTypeBasePremiums[vehicleType];
		}

		public decimal GetInsuranceFactor(string vehicleManufacturer)
		{
			return this._configurationRepository.CarManufacturerFactors[vehicleManufacturer.ToLower()];
		}
	}
}