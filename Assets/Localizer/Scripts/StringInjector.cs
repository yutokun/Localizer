using System.Linq;
using TMPro;
using UnityEditor;
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
	}

	[CustomEditor(typeof(StringInjector))]
	public class StringInjectorInspector : Editor
	{
		StringInjector injector;

		void OnEnable()
		{
			injector = (StringInjector) target;
		}

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			ResourceBridge.Load();
			var dict = ResourceBridge.GetDictionaryFromId(injector.Id);
			if (dict != null)
			{
				var helpText = dict.Aggregate("", (current, item) => current + $"{item.Key}: {item.Value}\n");
				helpText = helpText.TrimEnd('\n');
				EditorGUILayout.HelpBox($"{helpText}", MessageType.Info);
			}
			else
			{
				EditorGUILayout.HelpBox($"String ID: {injector.Id} is not available.", MessageType.Error);
			}
		}
	}
}