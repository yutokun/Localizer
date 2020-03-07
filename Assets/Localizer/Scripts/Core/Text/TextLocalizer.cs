using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace yutoVR.Localizer
{
	public class TextLocalizer : LocalizerBase
	{
		public string textId;

		protected override void Prepare()
		{
			var component = ComponentFinder.Find<TextMesh, Text, TMP_Text>(this);
			if (component == null) return;

			if (component is TextMesh textMesh)
			{
				injector = new TextMeshInjector(textMesh);
			}
			else if (component is Text text)
			{
				injector = new UITextInjector(text);
			}
			else if (component is TMP_Text tmp)
			{
				injector = new TMPInjector(tmp);
			}
		}

		internal override void Localize()
		{
			ChangeID(textId);
		}

		public bool ChangeID(string textId)
		{
			if (string.IsNullOrEmpty(textId)) return false;

			if (!Localizer.Has(textId))
			{
				Debug.LogError($"Text ID: {textId} is not available.");
				return false;
			}

			this.textId = textId;
			var text = Localizer.GetTextFromId(textId);
			injector.Inject(text, this);
			return true;
		}
	}
}
