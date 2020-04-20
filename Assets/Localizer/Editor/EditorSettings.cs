using System.IO;
using UnityEditor;
using UnityEngine;

namespace yutoVR.Localizer
{
	public class EditorSettings
	{
		public class SettingsDefinition
		{
			public int maxSuggestion = 50;
			public bool enableTMP = false;

			public SettingsDefinition Clone() => (SettingsDefinition)MemberwiseClone();
		}

		public static SettingsDefinition current;

		static string EditorSettingsPath => PathProvider.EditorSettingsPath;

		public static void ResetAll()
		{
			current = new SettingsDefinition();
		}

		[InitializeOnLoadMethod]
		public static void LoadEditorSettings()
		{
			if (File.Exists(EditorSettingsPath))
			{
				var json = File.ReadAllText(EditorSettingsPath);
				current = JsonUtility.FromJson<SettingsDefinition>(json);
			}
			else
			{
				current = new SettingsDefinition();
				SaveEditorSettings();
			}
		}

		public static void SaveEditorSettings()
		{
			var json = JsonUtility.ToJson(current, true);
			File.WriteAllText(EditorSettingsPath, json);
		}
	}
}
