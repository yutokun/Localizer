using UnityEngine;

namespace yutoVR.Localizer
{
	public class TextureInjector : IInjector
	{
		readonly Renderer renderer;
		readonly string propertyName;
		readonly Texture2D[] texture2Ds;

		public TextureInjector(Renderer renderer, string propertyName, Texture2D[] texture2Ds)
		{
			this.renderer = renderer;
			this.propertyName = propertyName;
			this.texture2Ds = texture2Ds;
		}

		public void Inject<T>(T localizedData)
		{
			if (localizedData is int index)
			{
				renderer.material.SetTexture(propertyName, texture2Ds[index]);
			}
		}
	}
}
