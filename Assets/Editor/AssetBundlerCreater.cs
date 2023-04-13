using System.IO;
using UnityEditor;
public class AssetBundlerCreater : Editor
{

    [MenuItem("Assets/Build All Assets Bundles")]
    static void BuildAllAssetsBundles()
    {
        string assetBundleDirectory = "Assets/AssetsBundles";
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
        AssetDatabase.Refresh();

    }


}
