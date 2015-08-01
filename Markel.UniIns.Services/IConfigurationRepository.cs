namespace Markel.UniIns.Services
{
	using System.Collections.Generic;

	public interface IConfigurationRepository
	{
		IDictionary<VehicleType, decimal> VehicleTypeBasePremiums { get; }

		IDictionary<string, decimal> CarManufacturerFactors { get; }
	}
}