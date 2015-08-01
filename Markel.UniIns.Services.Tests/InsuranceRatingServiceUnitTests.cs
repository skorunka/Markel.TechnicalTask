namespace Markel.UniIns.Services.Tests
{
	using Markel.UniIns.Services.Implementations;

	using Moq;

	using NUnit.Framework;

	[TestFixture]
	public class InsuranceRatingServiceUnitTests
	{
		[Test]
		public void ShouldCalculateInsuranceRateForVenicleTypeAndManufacturer()
		{
			var vehicleType = VehicleType.Car;
			var venicleManufacturer = "Audi";

			var configurationgServiceMock = new Mock<IConfigurationgService>();
			var service = new InsuranceRatingService(configurationgServiceMock.Object) as IInsuranceRatingService;

			var result = service.GetInsuranceRate(vehicleType, venicleManufacturer);

			Assert.IsNotNull(result);
		}

		[Test]
		public void ShouldReturnInsuranceRate1200ForCarAudi()
		{
			var expectedRate = 1200m;
			var vehicleType = VehicleType.Car;
			var venicleManufacturer = "Audi";

			var configurationgServiceMock = new Mock<IConfigurationgService>();
			configurationgServiceMock.Setup(x => x.GetInsuranceBasePremium(It.Is<VehicleType>(p => VehicleType.Car == p)))
				.Returns(800m);
			configurationgServiceMock.Setup(x => x.GetInsuranceFactor(It.Is<string>(p => "Audi" == p)))
				.Returns(1.5m);
			var service = new InsuranceRatingService(configurationgServiceMock.Object) as IInsuranceRatingService;

			var result = service.GetInsuranceRate(vehicleType, venicleManufacturer);

			Assert.AreEqual(expectedRate, result);
		}

		[Test]
		public void ShouldReturnInsuranceRate2000ForVanMercedes()
		{
			var expectedRate = 2000m;
			var vehicleType = VehicleType.Van;
			var venicleManufacturer = "Marcedes";

			var configurationgServiceMock = new Mock<IConfigurationgService>();
			configurationgServiceMock.Setup(x => x.GetInsuranceBasePremium(It.Is<VehicleType>(p => VehicleType.Van == p)))
				.Returns(1000m);
			configurationgServiceMock.Setup(x => x.GetInsuranceFactor(It.Is<string>(p => "Marcedes" == p)))
				.Returns(2.0m);
			var service = new InsuranceRatingService(configurationgServiceMock.Object) as IInsuranceRatingService;

			var result = service.GetInsuranceRate(vehicleType, venicleManufacturer);

			Assert.AreEqual(expectedRate, result);
		}
	}
}
