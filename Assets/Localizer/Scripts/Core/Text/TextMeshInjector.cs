using UnityEngine;

namespace yutoVR.Localizer
{
	public class TextMeshInjector : IInjector
	{
		readonly TextMesh textMesh;

		public TextMeshInjector(TextMesh textMesh)
		{
			this.textMesh = textMesh;
		}

		public void Inject<T>(T localizedData)
		{
			textMesh.text = localizedData as string;
		}
	}
}
