using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class Build : MonoBehaviour {

    [MenuItem("AssetBundles/BuildAndroid")]
    public static void BuildAndroid()
    {
        BuildAssetBundle(BuildTarget.Android);
    }

    [MenuItem("AssetBundles/BuildPC")]
    public static void BuildPC()
    {
        BuildAssetBundle(BuildTarget.StandaloneWindows64);
    }

    [MenuItem("AssetBundles/BuildAndroid&PC")]
    public static void BuildAndroidAndPC()
    {
        BuildAssetBundle(BuildTarget.Android);
        BuildAssetBundle(BuildTarget.StandaloneWindows64);
    }

    

    private static void BuildAssetBundle(BuildTarget buildTarget)
    {
        var path = Application.streamingAssetsPath + "/" + PlatformPath.ToString(buildTarget);
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
        BuildPipeline.BuildAssetBundles(path,
            BuildAssetBundleOptions.None,
            //BuildAssetBundleOptions.ForceRebuildAssetBundle,
            //|BuildAssetBundleOptions.IgnoreTypeTreeChanges
            //|BuildAssetBundleOptions.DeterministicAssetBundle,
            buildTarget);
        AssetDatabase.Refresh(ImportAssetOptions.Default);
    }
}
