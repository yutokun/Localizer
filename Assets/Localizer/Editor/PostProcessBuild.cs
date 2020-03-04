using System;
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;

namespace yutoVR.Localizer
{
	public class PostProcessBuild
	{
		[PostProcessBuild]
		public static void OnPostProcessBuild(BuildTarget target, string pathToBuiltProject)
		{
			var source = PathProvider.SheetPath;

			var localizerDirectory = GetLocalizerDirectoryInBuild(target, pathToBuiltProject);
			Directory.CreateDirectory(localizerDirectory);
			var destination = Path.Combine(localizerDirectory, PathProvider.SheetName);

			File.Copy(source, destination);
		}

		static string GetLocalizerDirectoryInBuild(BuildTarget target, string pathToBuiltProject)
		{
			if (target == BuildTarget.StandaloneWindows || target == BuildTarget.StandaloneWindows64)
			{
				var builtDir = Path.GetDirectoryName(pathToBuiltProject);
				var dataDir = Path.GetFileNameWithoutExtension(pathToBuiltProject) + "_Data";
				return Path.Combine(builtDir, dataDir, "Localizer");
			}

			if (target == BuildTarget.StandaloneOSX)
			{
				return Path.Combine(pathToBuiltProject, "Contents", "Localizer");
			}

			throw new PlatformNotSupportedException($"Localizer: BuildTarget {target} is not supported.");
		}
	}
}
