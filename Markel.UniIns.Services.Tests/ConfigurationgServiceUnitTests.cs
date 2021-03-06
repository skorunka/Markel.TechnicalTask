namespace Markel.UniIns.Services.Tests
{
	using System;
	using System.Collections.Generic;

	using Markel.UniIns.Services.Implementations;
	using Markel.UniIns.Services.Tests.Fakes;

	using Moq;

	using NUnit.Framework;

	[TestFixture]
	public class ConfigurationgServiceUnitTests
	{
		[Test]
		public void ShouldReturn800BasePremiumForCarVenicleType()
		{
			var expectedResult = 800m;
			var vehicleType = VehicleType.Car;

			var configurationRepository = new ConfigurationStorageFake() as IConfigurationStorage;
			var service = new ConfigurationgService(configurationRepository) as IConfigurationgService;

			var result = service.GetInsuranceBasePremium(vehicleType);

			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void ShouldReturn1Point5FactorForAudiVehicleManufacturer()
		{
			var expectedResult = 1.5m;
			var vehicleManufacturer = "Audi";

			var configurationRepository = new ConfigurationStorageFake() as IConfigurationStorage;
			var service = new ConfigurationgService(configurationRepository) as IConfigurationgService;

			var result = service.GetInsuranceFactor(vehicleManufacturer);

			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void EnsureVehicleManufacturerIsCaseInsensitiveWhileLookingForInsuranceFactor()
		{
			var expectedResult = 1.0m;
			var vehicleManufacturer = "AuDi";

			var configurationRepositoryMock = new Mock<IConfigurationStorage>();
			configurationRepositoryMock.SetupGet(x => x.CarManufacturerFactors)
				.Returns(new Dictionary<string, decimal> {["audi"] = 1.0m });
			var service = new ConfigurationgService(configurationRepositoryMock.Object) as IConfigurationgService;

			var result = service.GetInsuranceFactor(vehicleManufacturer);

			Assert.AreEqual(expectedResult, result);
		}

		[Test, ExpectedException(typeof(ArgumentException))]
		public void ShoulThrowArgumentExceptionWhenNoPremiumBaseForRequestedVehicleType()
		{
			var vehicleType = VehicleType.Car;

			var configurationRepositoryMock = new Mock<IConfigurationStorage>();
			configurationRepositoryMock.SetupGet(x => x.VehicleTypeBasePremiums)
				.Returns(new Dictionary<VehicleType, decimal>());

			var service = new ConfigurationgService(configurationRepositoryMock.Object) as IConfigurationgService;

			service.GetInsuranceBasePremium(vehicleType);
		}

		[Test, ExpectedException(typeof(ArgumentException))]
		[TestCase(null), TestCase(""), TestCase("  "), TestCase("\n")]
		public void ShoulThrowArgumentExceptionWhenRequestedVehicleManufacturerIsNullOrEmptyOrWhitespace(string vehicleManufacturer)
		{
			var configurationRepositoryMock = new Mock<IConfigurationStorage>();
			configurationRepositoryMock.SetupGet(x => x.CarManufacturerFactors)
				.Returns(new Dictionary<string, decimal>
				{
					[""] = 1.0m,
					["  "] = 2.0m,
					["\n"] = 3.0m,
				});

			var service = new ConfigurationgService(configurationRepositoryMock.Object) as IConfigurationgService;

			service.GetInsuranceFactor(vehicleManufacturer);
		}

		[Test, ExpectedException(typeof(ArgumentException))]
		public void ShoulThrowArgumentExceptionWhenNoFactorForRequestedVehicleManufacturer()
		{
			var vehicleManufacturer = "xx";

			var configurationRepositoryMock = new Mock<IConfigurationStorage>();
			configurationRepositoryMock.SetupGet(x => x.CarManufacturerFactors)
				.Returns(new Dictionary<string, decimal>());

			var service = new ConfigurationgService(configurationRepositoryMock.Object) as IConfigurationgService;

			service.GetInsuranceFactor(vehicleManufacturer);
		}
	}
}