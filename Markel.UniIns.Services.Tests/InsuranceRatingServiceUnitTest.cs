namespace Markel.UniIns.Services.Tests
{
	using NUnit.Framework;

	[TestFixture]
	public class InsuranceRatingServiceUnitTest
	{
		[Test]
		public void ShouldCalculateInsuranceRateForVenicleTypeAndManufacturer()
		{
			var vehicleType = "Car";
			var venicleManufacturer = "Audi";

			var service = new InsuranceRatingService() as IInsuranceRatingService;

			var result = service.GetInsuranceRate(vehicleType, venicleManufacturer);

			Assert.IsNotNull(result);
		}
	}
}
