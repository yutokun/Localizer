using UnityEngine;

namespace yutoVR.Localizer
{
	public abstract class LocalizerBase : MonoBehaviour
	{
		protected IInjector injector;

		protected virtual void Awake()
		{
			this.AddLocalizer();
			Prepare();
		}

		/// <summary>
		/// Prepare reference to target component.
		/// </summary>
		protected abstract void Prepare();

		protected virtual void Start()
		{
			Localize();
		}

		/// <summary>
		/// Localize target component.
		/// </summary>
		internal abstract void Localize();

		protected virtual void OnDestroy()
		{
			this.RemoveLocalizer();
		}
	}
}
