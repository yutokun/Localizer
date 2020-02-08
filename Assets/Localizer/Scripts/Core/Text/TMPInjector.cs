using TMPro;

namespace yutoVR.Localizer
{
	public class TMPInjector : IInjector
	{
		readonly TMP_Text tmp;

		public TMPInjector(TMP_Text tmp)
		{
			this.tmp = tmp;
		}

		public void Inject<T>(T localizedData)
		{
			tmp.text = localizedData as string;
		}
	}
}
