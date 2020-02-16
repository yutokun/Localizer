using UnityEngine;
using UnityEngine.UI;

namespace yutoVR.Localizer
{
	public class ImageLocalizer : LocalizerBase
	{
		public string propertyName = "_MainTex";
		public Texture2D[] texture2Ds;
		public Sprite[] sprites;
		public Texture[] textures;

		protected override void Prepare()
		{
			var component = ComponentFinder.Find<Renderer, RawImage, Image>(this);
			if (component == null) return;

			if (component is Renderer renderer)
			{
				injector = new TextureInjector(renderer, propertyName, texture2Ds);
			}
			else if (component is Image image)
			{
				injector = new UIImageInjector(image, sprites);
			}
			else if (component is RawImage rawImage)
			{
				injector = new RawImageInjector(rawImage, textures);
			}
		}

		internal override void Localize()
		{
			var index = Localizer.CurrentLanguageIndex;
			injector.Inject(index, this);
		}
	}
}
