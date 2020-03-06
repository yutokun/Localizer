using UnityEngine;
using Random = UnityEngine.Random;

public class ScaleRandomizer : MonoBehaviour
{
	[SerializeField] float minScale, maxScale, interval;
	float elapsedTime;
	Vector3 targetScale;

	void Update()
	{
		elapsedTime += Time.deltaTime;

		if (elapsedTime > interval)
		{
			elapsedTime = 0f;
			targetScale = Random.Range(minScale, maxScale) * Vector3.one;
		}

		transform.localScale = Vector3.Lerp(transform.localScale, targetScale, 0.5f);
	}
}
