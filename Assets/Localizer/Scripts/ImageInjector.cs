using System;
using UnityEngine;
using UnityEngine.UI;

namespace yutoVR.Localizer
{
	public enum ImageType
	{
		Texture2D,
		Sprite
	}

	public class ImageInjector : MonoBehaviour, IInjector
	{
		// TODO Renderer の material か sharedMaterial にアクセスするのが良いな…
		// TODO UI もいくならどうすればいいのか。それは後にするか。

		public ImageType imageType;
		public string propertyName = "_MainTex";
		public Texture2D[] texture2Ds;
		public Sprite[] sprites;

		void Reset()
		{
			if (GetComponent<Image>() is Image image)
			{
				imageType = ImageType.Sprite;
			}
		}

		void Awake()
		{
			this.AddInjector();
		}

		void Start()
		{
			Inject();
		}

		public void Inject()
		{
			var index = Localizer.CurrentLanguageIndex;

			switch (imageType)
			{
				case ImageType.Texture2D:
					if (GetComponent<Renderer>() is Renderer renderer)
					{
						renderer.material.SetTexture(propertyName, texture2Ds[index]);
					}

					break;

				case ImageType.Sprite:
					if (GetComponent<Image>() is Image image)
					{
						image.sprite = sprites[index];
					}

					break;
			}
		}

		void OnDestroy()
		{
			this.RemoveInjector();
		}
	}
}