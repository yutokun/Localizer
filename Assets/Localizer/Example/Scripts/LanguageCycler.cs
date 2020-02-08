using UnityEngine;

namespace yutoVR.Localizer.Demo
{
	public class LanguageCycler : MonoBehaviour
	{
		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Return))
			{
				Localizer.ActivateNextLanguage();
			}
		}
	}
}
