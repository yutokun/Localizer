using UnityEditor;
using UnityEngine;

namespace yutoVR.Localizer
{
	[CustomEditor(typeof(AudioLocalizer))]
	public class AudioLocalizerInspector : Editor
	{
		AudioLocalizer localizer;
		SerializedProperty playFromSamePositionWhenInject;

		void OnEnable()
		{
			localizer = (AudioLocalizer)target;
			playFromSamePositionWhenInject = serializedObject.FindProperty("playFromSamePositionWhenInject");
		}

		public override void OnInspectorGUI()
		{
			// base.OnInspectorGUI();

			Localizer.Load();
			serializedObject.Update();

			EditorGUILayout.PropertyField(playFromSamePositionWhenInject, new GUIContent("Play From Same Position"));

			var langCount = Localizer.LanguageList.Count;

			if (localizer.clips == null)
			{
				localizer.clips = new AudioClip[langCount];
			}
			else if (localizer.clips.Length != langCount)
			{
				var oldClips = localizer.clips;
				localizer.clips = new AudioClip[langCount];
				for (var i = 0; i < langCount; i++)
				{
					localizer.clips[i] = oldClips[i];
				}
			}

			for (var i = 0; i < langCount; i++)
			{
				var clip = EditorGUILayout.ObjectField(Localizer.LanguageList[i], localizer.clips[i], typeof(AudioClip), false) as AudioClip;
				localizer.clips[i] = clip;
			}

			serializedObject.ApplyModifiedProperties();
		}
	}
}
