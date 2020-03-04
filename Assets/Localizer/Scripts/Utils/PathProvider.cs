using System.IO;
using UnityEngine;

namespace yutoVR.Localizer
{
	public class PathProvider : MonoBehaviour
	{
		internal static string LocalizerDirectory => Path.Combine(Application.dataPath, "Localizer");
		static string SheetName => "LocalizedStrings.tsv";
		static string SettingsName => "Settings.json";

		internal static string SheetPath => Path.Combine(LocalizerDirectory, SheetName);
		internal static string SettingsPath => Path.Combine(LocalizerDirectory, SettingsName);
	}
}
