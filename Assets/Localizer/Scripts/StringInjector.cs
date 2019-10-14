using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace yutoVR.Localizer
{
	public class StringInjector : MonoBehaviour, IInjector
	{
		[SerializeField] string stringId;
		public string Id => stringId;

		void Awake()
		{
			this.AddInjector();
		}

		public void Inject(string text)
		{
			if (GetComponent<TextMesh>() is TextMesh textMesh)
			{
				textMesh.text = text;
			}
			else if (GetComponent<TextMeshPro>() is TextMeshPro textMeshPro)
			{
				textMeshPro.text = text;
			}
			else if (GetComponent<Text>() is Text uiText)
			{
				uiText.text = text;
			}
			else
			{
				Debug.LogError("テキストを置換できるコンポーネントがありません。");
			}
		}
	}
}