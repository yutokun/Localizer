using System;
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

			var imageType = (ImageType) EditorGUILayout.EnumPopup("Image Type", injector.imageType);
			injector.imageType = imageType;

			var langCount = Localizer.LanguageList.Count;

			switch (imageType)
			{
				case ImageType.Texture2D:
					UpdateTexture2DInspector(langCount);
					break;

				case ImageType.Sprite:
					UpdateSpriteInspector(langCount);
					break;
			}
		}

		void UpdateTexture2DInspector(int langCount)
		{
			EditorGUILayout.TextField("Property Name", injector.propertyName);

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

		void UpdateSpriteInspector(int langCount)
		{
			if (injector.sprites == null)
			{
				injector.sprites = new Sprite[langCount];
			}
			else if (injector.sprites.Length != langCount)
			{
				var oldSprites = injector.sprites;
				injector.sprites = new Sprite[langCount];
				for (var i = 0; i < langCount; i++)
				{
					injector.sprites[i] = oldSprites[i];
				}
			}

			for (var i = 0; i < langCount; i++)
			{
				var sprite = EditorGUILayout.ObjectField(Localizer.LanguageList[i], injector.sprites[i], typeof(Sprite), false) as Sprite;
				injector.sprites[i] = sprite;
			}
		}
	}
}