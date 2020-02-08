using UnityEngine;

namespace yutoVR.Localizer
{
	public abstract class InjectorBase : MonoBehaviour
	{
		protected virtual void Awake()
		{
			this.AddInjector();
		}

		protected virtual void Start()
		{
			Inject();
		}

		public abstract void Inject();

		protected virtual void OnDestroy()
		{
			this.RemoveInjector();
		}
	}
}
