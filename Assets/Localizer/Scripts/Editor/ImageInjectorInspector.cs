using UnityEditor;
using UnityEngine;

namespace yutoVR.Localizer
{
	[CustomEditor(typeof(ImageInjector))]
	public class ImageInjectorInspector : Editor
	{
		ImageInjector injector;

		void OnEnable()
		{
			injector = (ImageInjector) target;
		}

		public override void OnInspectorGUI()
		{
//			base.OnInspectorGUI();

			Localizer.Load();

			EditorGUILayout.TextField("Property Name", injector.propertyName);

			var langCount = Localizer.LanguageList.Count;

			if (injector.texture2Ds == null)
			{
				injector.texture2Ds = new Texture2D[langCount];
			}
			else if (injector.texture2Ds.Length != langCount)
			{
				var oldTexture2Ds = injector.texture2Ds;
				injector.texture2Ds = new Texture2D[langCount];
				for (var i = 0; i < langCount; i++)
				{
					injector.texture2Ds[i] = oldTexture2Ds[i];
				}
			}

			for (var i = 0; i < langCount; i++)
			{
				var tex = EditorGUILayout.ObjectField(Localizer.LanguageList[i], injector.texture2Ds[i], typeof(Texture2D), false) as Texture2D;
				injector.texture2Ds[i] = tex;
			}
		}
	}
}