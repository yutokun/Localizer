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

		public void Inject<T>(T localizedData)
		{
			audio.clip = localizedData as AudioClip;
		}
	}
}
