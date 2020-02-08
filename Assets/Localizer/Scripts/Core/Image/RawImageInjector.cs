using UnityEngine;
using UnityEngine.UI;

namespace yutoVR.Localizer
{
	public class RawImageInjector : IInjector
	{
		readonly RawImage rawImage;
		readonly Texture[] textures;

		public RawImageInjector(RawImage rawImage, Texture[] textures)
		{
			this.rawImage = rawImage;
			this.textures = textures;
		}

		public void Inject<T>(T localizedData)
		{
			if (localizedData is int index)
			{
				rawImage.texture = textures[index];
			}
		}
	}
}
