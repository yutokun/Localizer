﻿using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace yutoVR.Localizer
{
	public class StringInjector : MonoBehaviour, IInjector
	{
		[SerializeField] string stringId;
		public string Id => stringId;

		void Awake()
		{
			this.AddInjector();
		}

		public void Inject(string text)
		{
			if (GetComponent<TextMesh>() is TextMesh textMesh)
			{
				textMesh.text = text;
			}
			else if (GetComponent<TMP_Text>() is TMP_Text textMeshPro)
			{
				textMeshPro.text = text;
			}
			else if (GetComponent<Text>() is Text uiText)
			{
				uiText.text = text;
			}
			else
			{
				Debug.LogError("テキストを置換できるコンポーネントがありません。");
			}
		}
	}

	[CustomEditor(typeof(StringInjector))]
	public class StringInjectorInspector : Editor
	{
		StringInjector injector;

		void OnEnable()
		{
			injector = (StringInjector) target;
		}

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			ResourceBridge.Load();
			var text = ResourceBridge.GetStringFromId(injector.Id, "English");
			if (text != null)
			{
				EditorGUILayout.HelpBox($"{text}", MessageType.Info);
			}
			else
			{
				EditorGUILayout.HelpBox($"ローカライズ ID: {injector.Id} は存在しません。", MessageType.Error);
			}
		}
	}
}