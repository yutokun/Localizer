using System.Linq;
using UnityEditor;

namespace yutoVR.Localizer
{
	[CustomEditor(typeof(StringInjector))]
	public class StringInjectorInspector : Editor
	{
		StringInjector injector;

		void OnEnable()
		{
			injector = (StringInjector)target;
		}

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			if (string.IsNullOrEmpty(injector.stringId))
			{
				EditorGUILayout.HelpBox("Please enter a String ID.", MessageType.Info);
				return;
			}

			Localizer.Load();
			var dict = Localizer.GetDictionaryFromId(injector.stringId);
			if (dict != null)
			{
				var helpText = dict.Aggregate("", (current, item) => current + $"{item.Key}: {item.Value}\n");
				helpText = helpText.TrimEnd('\n');
				EditorGUILayout.HelpBox($"{helpText}", MessageType.Info);
			}
			else
			{
				EditorGUILayout.HelpBox($"String ID: {injector.stringId} is not available.", MessageType.Error);
			}
		}
	}
}
