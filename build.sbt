name := "sbt-unity-package"

organization := "com.mindwaves-studio"

version := "1.0-SNAPSHOT"

unityPackageSettings

mappings in (Compile, packageBin) := Seq((file(""), s"Assets/${normalizedName.value}"))