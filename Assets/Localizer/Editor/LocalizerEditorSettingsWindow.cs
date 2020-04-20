using UnityEditor;
using UnityEngine;

namespace yutoVR.Localizer
{
	public class LocalizerEditorSettingsWindow : EditorWindow
	{
		[MenuItem("Window/Localizer")]
		static void Open()
		{
			EditorSettings.LoadEditorSettings();
			GetWindow<LocalizerEditorSettingsWindow>("Localizer");
		}

		void OnGUI()
		{
			var prevSettings = EditorSettings.current.Clone();
			DrawSettingsPanel(ref EditorSettings.current);
			if (EditorSettings.current != prevSettings) EditorSettings.SaveEditorSettings();
		}

		static void DrawSettingsPanel(ref EditorSettings.SettingsDefinition settings)
		{
			EditorGUILayout.LabelField("Settings", EditorStyles.boldLabel);
			var maxSuggestion = EditorGUILayout.IntField("Max Suggestion", settings.maxSuggestion);
			settings.maxSuggestion = maxSuggestion;
			EditorGUILayout.Space();
			if (GUILayout.Button("Reset All")) ResetAllSettings();
		}

		static void ResetAllSettings()
		{
			EditorSettings.ResetAll();
		}
	}
}
