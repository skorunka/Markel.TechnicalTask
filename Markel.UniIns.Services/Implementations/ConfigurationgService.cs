namespace Markel.UniIns.Services.Implementations
{
	using System;

	public class ConfigurationgService : IConfigurationgService
	{
		private readonly IConfigurationStorage _configurationStorage;

		public ConfigurationgService(IConfigurationStorage configurationStorage)
		{
			if (configurationStorage == null)
			{
				throw new ArgumentNullException(nameof(configurationStorage));
			}

			this._configurationStorage = configurationStorage;
		}

		public decimal GetInsuranceBasePremium(VehicleType vehicleType)
		{
			if (!this._configurationStorage.VehicleTypeBasePremiums.ContainsKey(vehicleType))
			{
				throw new ArgumentException(nameof(vehicleType));
			}

			return this._configurationStorage.VehicleTypeBasePremiums[vehicleType];
		}

		public decimal GetInsuranceFactor(string vehicleManufacturer)
		{
			if (string.IsNullOrWhiteSpace(vehicleManufacturer))
			{
				throw new ArgumentException(nameof(vehicleManufacturer));
			}

			vehicleManufacturer = vehicleManufacturer.ToLower();

			if (!this._configurationStorage.CarManufacturerFactors.ContainsKey(vehicleManufacturer))
			{
				throw new ArgumentException(nameof(vehicleManufacturer));
			}

			return this._configurationStorage.CarManufacturerFactors[vehicleManufacturer];
		}
	}
}