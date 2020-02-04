﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace yutoVR.Localizer
{
	public static class Localizer
	{
		static readonly List<IInjector> Injectors = new List<IInjector>();
		public static List<string> LanguageList { get; private set; } = new List<string>();
		static readonly Dictionary<string, List<string>> LocalizedStrings = new Dictionary<string, List<string>>();
		public static string CurrentLanguageName { get; private set; }
		public static int CurrentLanguageIndex => GetLanguageIndex(CurrentLanguageName);

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		static void Initialize()
		{
			Load();
		}

		/// <summary>
		/// Load localized strings to the memory.
		/// </summary>
		public static void Load()
		{
			var path = Path.Combine(Application.streamingAssetsPath, "LocalizedStrings.tsv");
			var sheet = CSVParser.LoadFromPath(path, CSVParser.Delimiter.Tab);

			LocalizedStrings.Clear();
			for (var i = 1; i < sheet.Count; i++)
			{
				var id = sheet[i][0];
				var strings = sheet[i].ToList();
				strings.RemoveAt(0);
				strings = strings.Select(s => s.Replace("\\n", "\n"))
				                 .Select(s => s.Replace("\r", ""))
				                 .ToList();
				LocalizedStrings.Add(id, strings);
			}

			LanguageList = sheet[0].Select(s => s.Replace("\r", "")).ToList();
			LanguageList.RemoveAt(0);

			ChangeLanguage(CurrentLanguageName ?? "");
		}

		/// <summary>
		/// Change current language.
		/// </summary>
		/// <param name="languageName">ex. "Japanese" "English"</param>
		public static void ChangeLanguage(string languageName)
		{
			var languageIndex = 0;
			if (languageName != "")
			{
				languageIndex = GetLanguageIndex(languageName);
			}

			CurrentLanguageName = LanguageList[languageIndex];
		}

		/// <summary>
		/// Activate Previous Language.
		/// </summary>
		/// <returns>Activated language name</returns>
		public static string ActivatePreviousLanguage()
		{
			var prevIndex = (int)Mathf.Repeat(CurrentLanguageIndex - 1, LanguageList.Count);
			ChangeLanguage(LanguageList[prevIndex]);
			InjectAll();
			return LanguageList[prevIndex];
		}

		/// <summary>
		/// Activate Next Language.
		/// </summary>
		/// <returns>Activated language name</returns>
		public static string ActivateNextLanguage()
		{
			var nextIndex = (int)Mathf.Repeat(CurrentLanguageIndex + 1, LanguageList.Count);
			ChangeLanguage(LanguageList[nextIndex]);
			InjectAll();
			return LanguageList[nextIndex];
		}

		static int GetLanguageIndex(string languageName)
		{
			var i = LanguageList.FindIndex(s => s.Contains(languageName));
			if (i == -1) Debug.LogError($"Unavailable language name: {languageName}");
			return i;
		}

		public static void AddInjector(this IInjector injector)
		{
			Injectors.Add(injector);
		}

		public static void RemoveInjector(this IInjector injector)
		{
			Injectors.Remove(injector);
		}

		/// <summary>
		/// Re-inject strings to all IInjectors.
		/// </summary>
		public static void InjectAll()
		{
			foreach (var injector in Injectors) injector.Inject();
		}

		/// <summary>
		/// Get localized string from String ID.
		/// </summary>
		/// <param name="id">String ID</param>
		/// <returns>Localized String</returns>
		public static string GetStringFromId(string id)
		{
			return GetStringFromId(id, CurrentLanguageName);
		}

		/// <summary>
		/// Get localized string of specific language from String ID.
		/// </summary>
		/// <param name="id">String ID</param>
		/// <param name="languageName">Language Name</param>
		/// <returns>Localized String</returns>
		public static string GetStringFromId(string id, string languageName)
		{
			if (!LocalizedStrings.ContainsKey(id)) return null;
			var languageIndex = GetLanguageIndex(languageName);

			return LocalizedStrings[id][languageIndex];
		}

		/// <summary>
		/// Get dictionary contains string of all language for specific ID.
		/// </summary>
		/// <param name="id">String ID</param>
		/// <returns>Dictionary contains localized strings</returns>
		public static Dictionary<string, string> GetDictionaryFromId(string id)
		{
			if (!LocalizedStrings.ContainsKey(id)) return null;

			var dict = new Dictionary<string, string>();

			foreach (var language in LanguageList)
			{
				var text = GetStringFromId(id, language);
				dict.Add(language, text);
			}

			return dict;
		}
	}
}
