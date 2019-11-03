using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace yutoVR.Localizer
{
	public static class ResourceBridge
	{
		static readonly List<IInjector> injectors = new List<IInjector>();
		static readonly Dictionary<string, string> currentLang = new Dictionary<string, string>();

		[RuntimeInitializeOnLoadMethod]
		public static void Initialize()
		{
			Load();
			InjectAll();
		}

		static void Load()
		{
			// TODO 言語ファイルを読み込む

			var data = File.ReadAllText(""); // TODO パス指定
			// TODO CSV Reader を TSV 用に改造できないかな。パースして二次元配列に。
			// データ構造を考える
			// 行が項目、1列目が項目名、2列目以降は言語
			// 2次元配列で読めばいいかな？
		}

		public static void ChangeLanguage(string languageName)
		{
			// TODO 何か定数で指定したい。ランタイム Enum 的なことを
		}

		public static void AddInjector(this IInjector injector)
		{
			injectors.Add(injector);
		}

		static void InjectAll()
		{
			foreach (var injector in injectors)
			{
				if (currentLang.TryGetValue(injector.Id, out var text))
				{
					injector.Inject(text);
				}
				else
				{
					Debug.LogError($"ローカライズ ID: {injector.Id} は存在しません。");
				}
			}
		}
	}
}