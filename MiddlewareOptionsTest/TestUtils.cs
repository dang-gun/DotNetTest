using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace MiddlewareOptionsTest
{
	public interface ITestUtils
	{
	}

	public class TestUtils: ITestUtils
	{
		private readonly TestUtilsSettingModel _appSettings;

		public TestUtils(IOptions<TestUtilsSettingModel> appSettings)
		{
			_appSettings = appSettings.Value;
		}

	}

}
