using UnityEngine;
using UnityEditor;

namespace MW
{
	public static class BuildPipelineTools
	{
		public static void ExportPackage()
		{
			Debug.Log(string.Join(", ", System.Environment.GetCommandLineArgs()));
			EditorApplication.Exit(-1);
		}
	}
}