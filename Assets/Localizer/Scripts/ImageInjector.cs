using UnityEngine;
using UnityEngine.UI;

namespace yutoVR.Localizer
{
	public enum ImageType
	{
		Texture2D,
		Texture,
		Sprite
	}

	public class ImageInjector : MonoBehaviour, IInjector
	{
		public ImageType imageType;
		public string propertyName = "_MainTex";
		public Texture2D[] texture2Ds;
		public Sprite[] sprites;
		public Texture[] textures;

		void Reset()
		{
			if (GetComponent<Image>())
			{
				imageType = ImageType.Sprite;
			}
			else if (GetComponent<RawImage>())
			{
				imageType = ImageType.Texture;
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

				case ImageType.Texture:
					if (GetComponent<RawImage>() is RawImage rawImage)
					{
						rawImage.texture = textures[index];
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