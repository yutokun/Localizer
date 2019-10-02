using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace yutoVR.Localizer
{
	public class StringInjector : MonoBehaviour, IInjector
	{
		[SerializeField] string stringId;
		public string Id => stringId;

		[SerializeField] Component target;

		void Awake()
		{
			this.AddInjector();
		}

		public void Inject(string text)
		{
			if (target is TextMesh textMesh)
			{
				textMesh.text = text;
			}
			else if (target is TextMeshPro textMeshPro)
			{
				textMeshPro.text = text;
			}
			else if (target is Text uiText)
			{
				uiText.text = text;
			}

			// TODO : ID がないときには警告
		}
	}
}