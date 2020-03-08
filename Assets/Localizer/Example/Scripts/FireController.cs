using UnityEngine;
using UnityEngine.Timeline;

namespace yutoVR.Localizer.Demo
{
	public class FireController : MonoBehaviour, ITimeControl
	{
		[SerializeField] ParticleSystem particle;
		[SerializeField] ScaleRandomizer light;

		void Play()
		{
			particle.Play();
			light.Play();
		}

		void Stop()
		{
			particle.Stop();
			light.Stop();
		}

		public void SetTime(double time) { }

		public void OnControlTimeStart() => Play();

		public void OnControlTimeStop() => Stop();
	}
}
