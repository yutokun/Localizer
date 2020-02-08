using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace yutoVR.Localizer
{
	public enum StringType
	{
		TextMesh,
		UIText,
		TextMeshPro
	}

	public class StringInjector : InjectorBase
	{
		[HideInInspector] public StringType stringType;
		public string stringId;

		void Reset()
		{
			if (GetComponent<TextMesh>())
			{
				stringType = StringType.TextMesh;
			}
			else if (GetComponent<Text>())
			{
				stringType = StringType.UIText;
			}
			else if (GetComponent<TMP_Text>())
			{
				stringType = StringType.TextMeshPro;
			}
		}

		public override void Inject()
		{
			var text = Localizer.GetStringFromId(stringId);
			if (text == null) Debug.LogError($"String ID: {stringId} is not available.");

			switch (stringType)
			{
				case StringType.TextMesh:
					GetComponent<TextMesh>().text = text;
					break;

				case StringType.UIText:
					GetComponent<Text>().text = text;
					break;

				case StringType.TextMeshPro:
					GetComponent<TMP_Text>().text = text;
					break;
			}
		}
	}
}
