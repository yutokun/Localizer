using UnityEngine;

namespace yutoVR.Localizer
{
	public class AudioLocalizer : LocalizerBase
	{
		public AudioClip[] clips;

		protected override void Prepare()
		{
			var component = ComponentFinder.Find<AudioSource>(this);
			if (component == null) return;

			if (component is AudioSource audio)
			{
				injector = new AudioSourceInjector(audio);
			}
		}

		internal override void Localize()
		{
			var index = Localizer.CurrentLanguageIndex;
			injector.Inject(index, this);
		}
	}
}
