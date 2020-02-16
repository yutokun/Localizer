using UnityEngine;

namespace yutoVR.Localizer
{
	public class AudioSourceInjector : IInjector
	{
		readonly AudioSource audio;

		public AudioSourceInjector(AudioSource audio)
		{
			this.audio = audio;
		}

		public void Inject<T1, T2>(T1 localizedData, T2 localizer) where T2 : LocalizerBase
		{
			audio.clip = localizedData as AudioClip;
		}
	}
}
