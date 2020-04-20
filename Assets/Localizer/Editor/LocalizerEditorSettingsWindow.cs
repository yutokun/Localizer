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
			if (prevSettings.enableTMP != EditorSettings.current.enableTMP)
			{
				if (EditorSettings.current.enableTMP)
				{
					var enableTMP = AskToEnableTMP();
					EditorSettings.current.enableTMP = enableTMP;
					if (enableTMP) TMPIntegrationSwitcher.Enable();
				}
				else
				{
					TMPIntegrationSwitcher.Disable();
				}
			}

			if (EditorSettings.current != prevSettings) EditorSettings.SaveEditorSettings();
		}

		static void DrawSettingsPanel(ref EditorSettings.SettingsDefinition settings)
		{
			EditorGUILayout.LabelField("Settings", EditorStyles.boldLabel);
			settings.maxSuggestion = EditorGUILayout.IntField("Max Suggestion", settings.maxSuggestion);
			settings.enableTMP = EditorGUILayout.Toggle("TextMesh Pro Integration", settings.enableTMP);
			EditorGUILayout.Space();
			if (GUILayout.Button("Reset All")) ResetAllSettings();
		}

		static bool AskToEnableTMP()
		{
			const string message = "This causes compilation errors if your project doesn't have TextMesh Pro. Would you like to do it?";
			return EditorUtility.DisplayDialog("Enable TextMesh Pro Integration", message, "Enable", "Keep it disabled");
		}

		static void ResetAllSettings()
		{
			EditorSettings.ResetAll();
			TMPIntegrationSwitcher.Disable();
		}
	}
}
