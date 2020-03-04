using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;

namespace yutoVR.Localizer
{
	public class BuildPostProcess
	{
		[PostProcessBuild]
		public static void OnPostProcessBuild(BuildTarget target, string pathToBuiltProject)
		{
			var source = PathProvider.SheetPath;

			var localizerDirectory = GetLocalizerDirectoryInBuild(pathToBuiltProject);
			Directory.CreateDirectory(localizerDirectory);
			var destination = Path.Combine(localizerDirectory, PathProvider.SheetName);

			File.Copy(source, destination);
		}

		static string GetLocalizerDirectoryInBuild(string pathToBuiltProject)
		{
			var builtDir = Path.GetDirectoryName(pathToBuiltProject);
			var dataDir = Path.GetFileNameWithoutExtension(pathToBuiltProject) + "_Data";
			return Path.Combine(builtDir, dataDir, "Localizer");
		}
	}
}
