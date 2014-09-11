name := "sbt-unity-package"

organization := "com.mindwaves-studio"

version := "1.0-SNAPSHOT"

unitySettings

UnityKeys.unityPackageSourceDirectories in Compile := Seq(s"Assets/${normalizedName.value}_main")