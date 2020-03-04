using System.IO;
using UnityEngine;

namespace yutoVR.Localizer
{
	public class PathProvider : MonoBehaviour
	{
		internal static string LocalizerDirectory => Path.Combine(Application.dataPath, "Localizer");
		public static string SheetName => "LocalizedStrings.tsv";
		static string SettingsName => "Settings.json";

		public static string SheetPath => Path.Combine(LocalizerDirectory, SheetName);
		internal static string SettingsPath => Path.Combine(LocalizerDirectory, SettingsName);
	}
}
