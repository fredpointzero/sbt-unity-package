/*
 * Copyright (c) 2014 Frédéric Vauchelles
 *
 * See the file license.txt for copying permission.
 */
name := "sbt-unity-package"

organization := "org.fredericvauchelles"

version := "1.1"

unityPackageSettings

mappings in (Compile, packageBin) := Seq((file(""), s"Assets/${normalizedName.value}"))