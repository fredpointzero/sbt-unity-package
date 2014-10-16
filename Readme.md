# Unity Package

## Overview

This package is designed to work with the SBT Unity Plugin.

It provides utilities to package Unity3D assets like the _ProjectSettings_ from the command line. (Which is not available from the native Unity3D command line).

## How to install

### If you are not using the SBT Unity3D plugin

Simply copy the assets in your Unity3D folder

### If your are using the SBT Unity3D Plugin

The dependency is already added by the plugin, so you have nothing to add in your project !
But make sure that the unitypackage is available to your dependency resolver:

1. Make it available to your SBT dependency resolver (choose the most appropriate solution)
    - Publish locally the plugin: `sbt publish-local`
    - Publish the artifact in you preferred ivy2 or maven repository and add the  corresponding resolver [(see SBT Reference)](http://www.scala-sbt.org/0.13/docs/Resolvers.html)

## How to use it

Use the Unity3D command line:
```sh
Unity3D.exe -batchMode -quit -projectPath YOUR_PROJECT_DIR -executeMethod MW.BuildPipelineTools.ExportPackageCL +sourceAsset SOURCE_DIRECTORIES [...] +output OUTPUT_FILE
```

The `SOURCE_DIRECTORIES` are a set of path to include in the packages, relative to the _project directory_.
eg:
* _Assets/MyFolder_
* _ProjectSettings_
* ...

## How to contribute

Feel free to fork it and create a pull request !

# License

MIT (see license.txt)
