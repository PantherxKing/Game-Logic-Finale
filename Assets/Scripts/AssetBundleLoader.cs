using System.Collections;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class AssetBundleLoader : MonoBehaviour
{
    public string bundleName;
    public string assetName;
    public Renderer rend;


    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        LoadSprite(bundleName, assetName);
    }
    public void LoadSprite(string bundleName, string assetName)
    {
        StartCoroutine(LoadAsset(bundleName, assetName));
    }

    private IEnumerator LoadAsset(string bundleName, string assetName)
    {
        string findPath = Path.Combine(Application.streamingAssetsPath, bundleName);
        Debug.Log(findPath);
        var assetBundleCreateRequest = AssetBundle.LoadFromFileAsync(findPath);
        yield return assetBundleCreateRequest;
        AssetBundle bundle = assetBundleCreateRequest.assetBundle;
        AssetBundleRequest assetBundleRequest = bundle.LoadAssetAsync<Material>(assetName);
        yield return assetBundleRequest;
        Material LoadedAsset = assetBundleRequest.asset as Material;
        rend.sharedMaterial = LoadedAsset;
    }

}
