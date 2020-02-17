using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace yutoVR.Localizer
{
	[CustomEditor(typeof(TextLocalizer))]
	public class TextLocalizerInspector : Editor
	{
		TextLocalizer localizer;

		void OnEnable()
		{
			localizer = (TextLocalizer)target;
		}

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			GUI.skin.GetStyle("HelpBox").richText = true;
			Localizer.Load();
			var keys = Localizer.GetAllIds();

			if (keys.Count == 0)
			{
				EditorGUILayout.HelpBox("No data available.\nPlease put LocalizedStrings.tsv in the StreamingAssets folder.", MessageType.Info);
				return;
			}

			if (string.IsNullOrEmpty(localizer.textId))
			{
				EditorGUILayout.HelpBox($"Please enter a Text ID.", MessageType.Info);

				var postfix = keys.Count > 5 ? $"\n\n<i>and more (a total of {keys.Count.ToString()} IDs)</i>" : "";
				ShowSuggestion(keys.ToList(), 5, postfix);
				return;
			}

			var dict = Localizer.GetDictionaryFromId(localizer.textId);
			if (dict != null)
			{
				var helpText = dict.Aggregate("", (current, item) => current + $"{item.Key}: {item.Value}\n");
				helpText = helpText.TrimEnd('\n');
				EditorGUILayout.HelpBox($"{helpText}", MessageType.Info);
			}
			else
			{
				EditorGUILayout.HelpBox($"Text ID: {localizer.textId} is not available.", MessageType.Error);
			}

			var suggestions = keys.Where(key => key.StartsWith(localizer.textId)).ToList();
			ShowSuggestion(suggestions);
		}

		void ShowSuggestion(IReadOnlyCollection<string> suggestions, int limit = int.MaxValue, string postfix = "")
		{
			var noSuggestion = suggestions.Count == 0;
			var exactMatch = suggestions.Count == 1 && suggestions.First() == localizer.textId;
			if (noSuggestion || exactMatch) return;

			var text = suggestions.Take(limit)
			                      .Aggregate("\n<b>ID Suggest</b>\n", (current, item) => $"{current}\n- {GetMarkedIdRepresentation(item)}");
			text += string.IsNullOrEmpty(postfix) ? "" : postfix;
			EditorGUILayout.HelpBox($"{text}\n", MessageType.Info);

			string GetMarkedIdRepresentation(string id)
			{
				if (string.IsNullOrEmpty(localizer.textId))
				{
					return id;
				}
				else
				{
					return $"<color=green>{id.Insert(localizer.textId.Length, "</color>")}";
				}
			}
		}
	}
}
