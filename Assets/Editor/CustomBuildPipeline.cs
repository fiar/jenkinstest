using UnityEngine;
using UnityEditor;
using UnityEditor.Build.Reporting;

namespace BuildSystem
{
	public static class CustomBuildPipeline
	{
		[MenuItem("Build/Build Android")]
		public static void BuildAndroid()
		{
			Debug.Log("Building Android...");

			BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();

			buildPlayerOptions.scenes = new[] { "Assets/Scenes/SampleScene.unity" };
			buildPlayerOptions.locationPathName = "Builds/Android.apk";
			buildPlayerOptions.target = BuildTarget.Android;
			buildPlayerOptions.options = BuildOptions.None;

			BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
			BuildSummary summary = report.summary;

			if (summary.result == BuildResult.Succeeded)
			{
				Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
			}

			if (summary.result == BuildResult.Failed)
			{
				Debug.Log("Build failed");
			}
		}
	}
}