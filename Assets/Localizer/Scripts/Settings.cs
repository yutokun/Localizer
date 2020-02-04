using System.IO;

namespace yutoVR.Localizer
{
	public static class Settings
	{
		static string SettingsDirectory => Path.Combine(Directory.GetCurrentDirectory(), "Localizer");
		static string SettingsPath => Path.Combine(SettingsDirectory, "CurrentLanguage.txt");

		public static void LoadLanguageSettings()
		{
			if (File.Exists(SettingsPath))
			{
				var languageName = File.ReadAllText(SettingsPath);
				Localizer.CurrentLanguageName = languageName;
			}
		}

		public static void SaveLanguageSettings()
		{
			Directory.CreateDirectory(SettingsDirectory);
			File.WriteAllText(SettingsPath, Localizer.CurrentLanguageName);
		}
	}
}
