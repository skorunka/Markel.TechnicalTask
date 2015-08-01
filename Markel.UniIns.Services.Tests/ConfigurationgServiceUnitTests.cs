namespace Markel.UniIns.Services.Tests
{
	using NUnit.Framework;

	[TestFixture]
	public class ConfigurationgServiceUnitTests
	{
		[Test]
		public void ShouldReturn800ForVenicleTypeCar()
		{
			var expectedResult = 800m;
			var vehicleType = VehicleType.Car;

			var service = new InMemoryConfigurationgService() as IConfigurationgService;

			var result = service.GetInsuranceBasePremium(vehicleType);

			Assert.AreEqual(expectedResult, result);
		}
	}
}