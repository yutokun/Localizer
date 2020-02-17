﻿using System.IO;
using UnityEngine;

namespace yutoVR.Localizer
{
	public static class Settings
	{
		class Definition
		{
			public string currentLanguageName;
		}

#if UNITY_EDITOR
		static string SettingsDirectory => Path.Combine(Directory.GetCurrentDirectory(), "Localizer");
#elif UNITY_STANDALONE
		static string SettingsDirectory => Path.Combine(Application.dataPath, "Localizer");
#endif

		static string SettingsPath => Path.Combine(SettingsDirectory, "Settings.json");

		public static void LoadLanguageSettings()
		{
			if (File.Exists(SettingsPath))
			{
				var json = File.ReadAllText(SettingsPath);
				var definition = JsonUtility.FromJson<Definition>(json);
				Localizer.CurrentLanguageName = definition.currentLanguageName;
			}
		}

		public static void SaveLanguageSettings()
		{
			var definition = new Definition { currentLanguageName = Localizer.CurrentLanguageName };
			var json = JsonUtility.ToJson(definition, true);

			Directory.CreateDirectory(SettingsDirectory);
			File.WriteAllText(SettingsPath, json);
		}
	}
}
