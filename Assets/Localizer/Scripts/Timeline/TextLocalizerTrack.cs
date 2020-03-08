using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace yutoVR.Localizer
{
	[TrackClipType(typeof(TextLocalizerPlayableAsset))]
	[TrackBindingType(typeof(TextLocalizer))]
	public class TextLocalizerTrack : TrackAsset
	{
		public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
		{
			var clips = GetClips();
			foreach (var clip in clips)
			{
				var asset = clip.asset as TextLocalizerPlayableAsset;
				clip.displayName = asset.textId ?? "TextLocalizer";
			}

			return base.CreateTrackMixer(graph, go, inputCount);
		}
	}
}
