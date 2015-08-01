// ReSharper disable InconsistentNaming
namespace Markel.UniIns.Services.Tests.Fakes
{
	using System.Collections.Generic;

	public class InMemoryConfigurationRepositoryFake : IConfigurationRepository
	{
		private static readonly IDictionary<VehicleType, decimal> _vehicleTypeBasePremiums = new Dictionary<VehicleType, decimal>
		{
			[VehicleType.Car] = 800m,
			[VehicleType.Van] = 1000m,
		};

		private static readonly IDictionary<string, decimal> _carManufacturerFactors = new Dictionary<string, decimal>
		{
			["audi"] = 1.5m,
			["mercedes"] = 2.0m
		};

		public IDictionary<VehicleType, decimal> VehicleTypeBasePremiums => _vehicleTypeBasePremiums;

		public IDictionary<string, decimal> CarManufacturerFactors => _carManufacturerFactors;
	}
}