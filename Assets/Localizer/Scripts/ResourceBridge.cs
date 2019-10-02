using System.Collections.Generic;

namespace yutoVR.Localizer
{
	public static class ResourceBridge
	{
		static readonly List<IInjector> injectors = new List<IInjector>();
		static readonly Dictionary<string, string> currentLang = new Dictionary<string, string>();

		// データ構造を考える
		// 行が項目、1列目が項目名、2列目以降は言語
		// 2次元配列で読めばいいかな？

		public static void Load()
		{
			// TODO 言語ファイルを読み込む
		}

		public static void AddInjector(this IInjector injector)
		{
			injectors.Add(injector);
		}

		public static void InjectAll()
		{
			foreach (var injector in injectors)
			{
				if (currentLang.TryGetValue(injector.Id, out var text))
				{
					injector.Inject(text);
				}
			}
		}
	}
}