using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace yutoVR.Localizer
{
	public static class ResourceBridge
	{
		static readonly List<IInjector> Injectors = new List<IInjector>();
		static readonly Dictionary<string, string> CurrentLang = new Dictionary<string, string>();
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

			CurrentLang.Clear();
			for (var i = 1; i < Sheet.Count; i++)
			{
				var key = Sheet[i][0];
				var value = Sheet[i][languageIndex];
				CurrentLang.Add(key, value);
			}

			LastLangName = Sheet[0][languageIndex];
		}

		static int GetLanguageIndex(string languageName)
		{
			var i = Sheet[0].FindIndex(s => s == languageName);
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
				if (CurrentLang.TryGetValue(injector.Id, out var text))
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
			try
			{
				return CurrentLang[id];
			}
			catch (KeyNotFoundException e)
			{
				return null;
			}
		}
	}
}