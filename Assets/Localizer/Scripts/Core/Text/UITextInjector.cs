using UnityEngine.UI;

namespace yutoVR.Localizer
{
	public class UITextInjector : IInjector
	{
		readonly Text uiText;

		public UITextInjector(Text uiText)
		{
			this.uiText = uiText;
		}

		public void Inject<T>(T localizedData)
		{
			uiText.text = localizedData as string;
		}
	}
}
