using System;
using System.Threading;
using NUnit.Framework;
using System.IO;
using UnityEditor;

namespace MW.BuildPipelineTest
{
	[TestFixture]
	[Category ("Packaging Tests")]
	internal class PackagingTest
	{
		[Test]
		public void ProcessExportPackageArgsSimpleTest ()
		{
			string[] sourceAssets = new string[] { "Assets/sbt-unity-package" };
			string output = "../package-test.unitypackage";
			ExportPackageOptions flags = ExportPackageOptions.Recurse;
			
			BuildPipelineTools.ProcessExportPackageArgs(ref sourceAssets, ref output, ref flags);
			
			Assert.AreEqual(1, sourceAssets.Length);
			Assert.AreEqual("Assets/sbt-unity-package", sourceAssets[0]);
			Assert.AreEqual(flags, ExportPackageOptions.Recurse);
		}
		
		[Test]
		public void ProcessExportPackageArgsSettingsTest ()
		{
			string[] sourceAssets = new string[] { "ProjectSettings", "Assets/sbt-unity-package" };
			string output = "../package-settings-test.unitypackage";
			ExportPackageOptions flags = ExportPackageOptions.Recurse;
			
			BuildPipelineTools.ProcessExportPackageArgs(ref sourceAssets, ref output, ref flags);
			
			Assert.AreEqual(1, sourceAssets.Length);
			Assert.AreEqual("Assets/sbt-unity-package", sourceAssets[0]);
			Assert.AreEqual(flags, ExportPackageOptions.Recurse | ExportPackageOptions.IncludeLibraryAssets);
		}

		[Test]
		public void PackageSimpleTest ()
		{
			string[] sourceAssets = new string[] { "Assets/sbt-unity-package" };
			string output = "../package-simple-test.unitypackage";
			ExportPackageOptions flags = ExportPackageOptions.Recurse;
			
			BuildPipelineTools.ExportPackage(sourceAssets, output, flags);
			
			Assert.True(File.Exists(output));
		}
		
		[Test]
		public void PackageSettingsTest ()
		{
			string[] sourceAssets = new string[] { "ProjectSettings", "Assets/sbt-unity-package" };
			string output = "../package-settings-test.unitypackage";
			ExportPackageOptions flags = ExportPackageOptions.Recurse;
			
			BuildPipelineTools.ExportPackage(sourceAssets, output, flags);
			
			Assert.True(File.Exists(output));
		}
	}
}
