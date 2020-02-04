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
		[HideInInspector] public ImageType imageType;
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
					GetComponent<Renderer>().material.SetTexture(propertyName, texture2Ds[index]);
					break;

				case ImageType.Texture:
					GetComponent<RawImage>().texture = textures[index];
					break;

				case ImageType.Sprite:
					GetComponent<Image>().sprite = sprites[index];
					break;
			}
		}

		void OnDestroy()
		{
			this.RemoveInjector();
		}
	}
}
