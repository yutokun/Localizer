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

		void Start()
		{
			Inject();
		}

		public void Inject()
		{
			var text = Localizer.GetStringFromId(Id);
			if (text == null) Debug.LogError($"String ID: {Id} is not available.");

			if (GetComponent<TextMesh>() is TextMesh textMesh)
			{
				textMesh.text = text;
			}
			else if (GetComponent<TMP_Text>() is TMP_Text textMeshPro)
			{
				textMeshPro.text = text;
			}
			else if (GetComponent<Text>() is Text uiText)
			{
				uiText.text = text;
			}
			else
			{
				Debug.LogError("No component with replaceable text.");
			}
		}

		void OnDestroy()
		{
			this.RemoveInjector();
		}
	}
}