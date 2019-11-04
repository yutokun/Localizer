using UnityEngine;
using yutoVR.Localizer;

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