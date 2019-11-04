using UnityEngine;

namespace yutoVR.Localizer
{
	public class ImageInjector : MonoBehaviour, IInjector
	{
		// TODO Renderer の material か sharedMaterial にアクセスするのが良いな…
		// TODO UI もいくならどうすればいいのか。それは後にするか。

		public string propertyName = "_MainTex";
		public Texture2D[] texture2Ds;

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
			if (GetComponent<Renderer>() is Renderer renderer)
			{
				var index = Localizer.CurrentLanguageIndex;
				renderer.material.SetTexture(propertyName, texture2Ds[index]);
			}
		}

		void OnDestroy()
		{
			this.RemoveInjector();
		}
	}
}