using UnityEngine;

namespace yutoVR.Localizer.Demo
{
	public class FireController : MonoBehaviour
	{
		[SerializeField] ParticleSystem particle;
		[SerializeField] ScaleRandomizer light;

		public void Play()
		{
			particle.Play();
		}

		public void Stop()
		{
			particle.Stop();
		}
	}
}
