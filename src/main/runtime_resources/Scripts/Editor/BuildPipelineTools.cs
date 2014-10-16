/*
 * Copyright (c) 2014 Frédéric Vauchelles
 *
 * See the file license.txt for copying permission.
 */
 using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

namespace MW
{
	public static class BuildPipelineTools
	{
		public static void ExportPackageCL()
		{
			Dictionary<string, List<string>> parsed = Parse(
				System.Environment.GetCommandLineArgs(),
				"+sourceAsset", "+output"
				);

			if (!parsed.ContainsKey("+sourceAsset") || parsed["+sourceAsset"].Count == 0) 
			{
				throw new UnityException("+sourceAsset requires at least one path");
			}
			string[] sourceAssets = parsed["+sourceAsset"].ToArray();

			if (!parsed.ContainsKey("+output") || parsed["+output"].Count != 1) 
			{
				throw new UnityException("+output path must have exactly one path");
			}
			string output = parsed["+output"][0];

			ExportPackage(sourceAssets, output, ExportPackageOptions.Recurse);
		}

		public static void ExportPackage(string[] sourceAssets, string output, ExportPackageOptions flags)
		{
			ProcessExportPackageArgs(ref sourceAssets, ref output, ref flags);
			
			Debug.Log("Generating package at: " + output);
			Debug.Log("Options: " + flags);
			foreach (string path in sourceAssets)
			{
				Debug.Log("Source Asset: " + path);
			}

			AssetDatabase.ExportPackage(sourceAssets, output, flags);
		}

		public static void ProcessExportPackageArgs(ref string[] sourceAssets, ref string output, ref ExportPackageOptions flags)
		{
			flags |= ExportPackageOptions.Recurse;
			if (sourceAssets.Any(s => s.Contains("ProjectSettings")))
			{
				sourceAssets = sourceAssets.Where(s => !s.Contains("ProjectSettings")).ToArray();
				flags |= ExportPackageOptions.IncludeLibraryAssets;
			}
		}

		private static Dictionary<string, List<string>> Parse(IEnumerable<string> tokens, params string[] fields)
		{
			Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();
			IEnumerator<string> e = tokens.GetEnumerator();
			bool doLoop = e.MoveNext();
			while(doLoop)
			{
				if (fields.Contains(e.Current))
				{
					string key = e.Current;
					if (!result.ContainsKey(key))
					{
						result.Add(key, new List<string>());
					}
					while ((doLoop = e.MoveNext()) && !fields.Contains(e.Current))
					{
						result[key].Add(e.Current);
					}
				}
				else
				{
					doLoop = e.MoveNext();
				}
	       	}
			return result;
		}
	}
}