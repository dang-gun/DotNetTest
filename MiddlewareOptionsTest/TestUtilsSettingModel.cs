namespace MiddlewareOptionsTest
{
	public class TestUtilsSettingModel
	{
		public int Test01 { get; set; } = 0;
		public string Test02 { get; set; } = string.Empty;

		public string Test03 { get; set; } = string.Empty;

		public void ToCopy(TestUtilsSettingModel testUtilsSettingModel)
		{
			this.Test01 = testUtilsSettingModel.Test01;
			this.Test02 = testUtilsSettingModel.Test02;
			this.Test03 = testUtilsSettingModel.Test03;
		}
	}
}
