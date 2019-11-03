using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace yutoVR.Localizer
{
	public static class ResourceBridge
	{
		static readonly List<IInjector> Injectors = new List<IInjector>();
		static readonly Dictionary<string, string> CurrentLangDictionary = new Dictionary<string, string>();
		static string LastLangName;
		static List<List<string>> Sheet;

		[RuntimeInitializeOnLoadMethod]
		public static void Initialize()
		{
			Load();
			InjectAll();
		}

		public static void Load()
		{
			var path = Path.Combine(Application.streamingAssetsPath, "Sample.tsv"); // TODO パス良い感じに
			Sheet = CSVParser.LoadFromPath(path, CSVParser.Delimiter.Tab);
			ChangeLanguage(LastLangName ?? "");
		}

		public static void ChangeLanguage(string languageName)
		{
			var languageIndex = 1; // 最初の言語
			if (languageName != "")
			{
				languageIndex = GetLanguageIndex(languageName);
			}

			CurrentLangDictionary.Clear();
			for (var i = 1; i < Sheet.Count; i++)
			{
				var key = Sheet[i][0];
				var value = Sheet[i][languageIndex];
				CurrentLangDictionary.Add(key, value);
			}

			LastLangName = Sheet[0][languageIndex];
		}

		static int GetLanguageIndex(string languageName)
		{
			var i = Sheet[0].FindIndex(s => s.Contains(languageName));
			// TODO 言語がなかった場合の処理
			return i;
		}

		public static void AddInjector(this IInjector injector)
		{
			Injectors.Add(injector);
		}

		static void InjectAll()
		{
			foreach (var injector in Injectors)
			{
				if (CurrentLangDictionary.TryGetValue(injector.Id, out var text))
				{
					injector.Inject(text);
				}
				else
				{
					Debug.LogError($"ローカライズ ID: {injector.Id} は存在しません。");
				}
			}
		}

		public static string GetStringFromId(string id)
		{
			return GetStringFromId(id, LastLangName);
		}

		public static string GetStringFromId(string id, string languageName)
		{
			var stringIndex = Sheet.FindIndex(words => words[0] == id);
			if (stringIndex == -1) return null;

			var langIndex = GetLanguageIndex(languageName);

			return Sheet[stringIndex][langIndex];
		}

		/// <summary>
		/// Get dictionary contains string of all language for specific ID.
		/// </summary>
		/// <param name="id">String ID.</param>
		/// <returns>Dictionary.</returns>
		public static Dictionary<string, string> GetDictionaryFromId(string id)
		{
			var stringIndex = Sheet.FindIndex(words => words[0] == id);
			if (stringIndex == -1) return null;

			var languageList = Sheet[0].ToList();
			languageList.RemoveAt(0);

			var dict = new Dictionary<string, string>();

			foreach (var language in languageList)
			{
				var text = GetStringFromId(id, language);
				dict.Add(language, text);
			}

			return dict;
		}
	}
}