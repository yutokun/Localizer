using UnityEngine;

namespace yutoVR.Localizer.Demo
{
	public class LanguageCycler : MonoBehaviour
	{
		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Return))
			{
				Cycle();
			}
		}

		public void Cycle()
		{
			Localizer.ActivateNextLanguage();
		}
	}
}
