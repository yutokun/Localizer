using UnityEngine;
using UnityEngine.UI;

namespace yutoVR.Localizer
{
	public class UIImageInjector : IInjector
	{
		readonly Image image;
		readonly Sprite[] sprites;

		public UIImageInjector(Image image, Sprite[] sprites)
		{
			this.image = image;
			this.sprites = sprites;
		}

		public void Inject<T>(T localizedData)
		{
			if (localizedData is int index)
			{
				image.sprite = sprites[index];
			}
		}
	}
}
