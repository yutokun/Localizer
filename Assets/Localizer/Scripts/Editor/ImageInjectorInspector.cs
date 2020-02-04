using UnityEditor;
using UnityEngine;

namespace yutoVR.Localizer
{
	[CustomEditor(typeof(ImageInjector))]
	public class ImageInjectorInspector : Editor
	{
		SerializedProperty imageType;
		ImageInjector injector;
		SerializedProperty propertyName;

		void OnEnable()
		{
			injector = (ImageInjector)target;
			imageType = serializedObject.FindProperty("imageType");
			propertyName = serializedObject.FindProperty("propertyName");
		}

		public override void OnInspectorGUI()
		{
//			base.OnInspectorGUI();

			Localizer.Load();
			serializedObject.Update();

			var langCount = Localizer.LanguageList.Count;

			switch ((ImageType)imageType.enumValueIndex)
			{
				case ImageType.Texture2D:
					UpdateTexture2DInspector(langCount);
					break;

				case ImageType.Texture:
					UpdateTextureInspector(langCount);
					break;

				case ImageType.Sprite:
					UpdateSpriteInspector(langCount);
					break;
			}

			serializedObject.ApplyModifiedProperties();
		}

		void UpdateTexture2DInspector(int langCount)
		{
			EditorGUILayout.PropertyField(propertyName);

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

		void UpdateTextureInspector(int langCount)
		{
			if (injector.textures == null)
			{
				injector.textures = new Texture[langCount];
			}
			else if (injector.textures.Length != langCount)
			{
				var oldTextures = injector.textures;
				injector.textures = new Texture[langCount];
				for (var i = 0; i < langCount; i++)
				{
					injector.textures[i] = oldTextures[i];
				}
			}

			for (var i = 0; i < langCount; i++)
			{
				var tex = EditorGUILayout.ObjectField(Localizer.LanguageList[i], injector.textures[i], typeof(Texture), false) as Texture;
				injector.textures[i] = tex;
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
