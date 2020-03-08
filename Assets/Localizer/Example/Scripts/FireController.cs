using UnityEngine;
using UnityEngine.Timeline;

namespace yutoVR.Localizer.Demo
{
	public class FireController : MonoBehaviour, ITimeControl
	{
		[SerializeField] ParticleSystem particle;
		[SerializeField] ScaleRandomizer floorLight;

		void Play()
		{
			particle.Play();
			floorLight.Play();
		}

		void Stop()
		{
			particle.Stop();
			floorLight.Stop();
		}

		public void SetTime(double time) { }

		public void OnControlTimeStart() => Play();

		public void OnControlTimeStop() => Stop();
	}
}
