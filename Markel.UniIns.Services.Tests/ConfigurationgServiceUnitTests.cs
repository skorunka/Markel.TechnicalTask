namespace Markel.UniIns.Services.Tests
{
	using System;

	using Markel.UniIns.Services.Implementations;
	using Markel.UniIns.Services.Tests.Fakes;

	using NUnit.Framework;

	[TestFixture]
	public class ConfigurationgServiceUnitTests
	{
		[Test]
		public void ShouldReturn800BasePremiumForCarVenicleType()
		{
			var expectedResult = 800m;
			var vehicleType = VehicleType.Car;
			var configurationRepository = new InMemoryConfigurationRepository();

			var service = new ConfigurationgService(configurationRepository) as IConfigurationgService;

			var result = service.GetInsuranceBasePremium(vehicleType);

			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void ShouldReturn1Point5FactorForAudiVehicleManufacturer()
		{
			var expectedResult = 1.5m;
			var vehicleManufacturer = "Audi";
			var configurationRepository = new InMemoryConfigurationRepository();

			var service = new ConfigurationgService(configurationRepository) as IConfigurationgService;

			var result = service.GetInsuranceFactor(vehicleManufacturer);

			Assert.AreEqual(expectedResult, result);
		}

		[Test, ExpectedException(typeof(ArgumentException))]
		public void ShoulThrowArgumentExceptionWhenNoPremiumBaseForRequestedVehicleType()
		{
			var vehicleType = VehicleType.Car;
			var configurationRepository = new InMemoryConfigurationRepository();

			var service = new ConfigurationgService(configurationRepository) as IConfigurationgService;

			service.GetInsuranceBasePremium(vehicleType);
		}
	}
}