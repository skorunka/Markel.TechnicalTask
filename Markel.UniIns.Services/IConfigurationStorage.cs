namespace Markel.UniIns.Services
{
	using System.Collections.Generic;

	public interface IConfigurationStorage
	{
		IDictionary<VehicleType, decimal> VehicleTypeBasePremiums { get; }

		IDictionary<string, decimal> CarManufacturerFactors { get; }
	}
}