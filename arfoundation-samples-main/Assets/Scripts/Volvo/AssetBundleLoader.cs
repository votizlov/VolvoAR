using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using UnityEngine.XR.ARFoundation.Samples;

public class AssetBundleLoader : MonoBehaviour
{
    public static AssetBundleLoader Instance;
    [SerializeField]string assetBundleName = "XC40_Recharge_Prefab";
    [SerializeField]AnchorCreator anchorCreator;
    void Start(){
        Instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(GetAssetBundleWWW(assetBundleName));
    }
    IEnumerator GetAssetBundleWWW(string assetName){
        float t = Time.time;        
        
        UnityEngine.XR.ARFoundation.Samples.Logger.Log("Loading asset " + assetName);
            //http://95.32.43.247:5554/api/v1/asset?assetName=1.1
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle("http://95.32.43.247:5554/api/v1/asset?assetName="+assetName);
        www.certificateHandler = new MyCertHandler();
        yield return www.SendWebRequest();
 
        if (www.result != UnityWebRequest.Result.Success) {
            UnityEngine.XR.ARFoundation.Samples.Logger.Log(www.error);
        }
        else {        
            UnityEngine.XR.ARFoundation.Samples.Logger.Log("Load sucsessful");
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
            GameObject cube = bundle.LoadAsset<GameObject>(assetName);
            anchorCreator.Prefab = cube;
            //Instantiate(cube);
            UnityEngine.XR.ARFoundation.Samples.Logger.Log("Asset assigned in " + (Time.time - t).ToString());
        }
    }

   void AssetBundleTest()
{
    AssetBundle bundle = //UnityEngine.Networking.DownloadHandlerAssetBundle.GetContent(request);
    AssetBundle.LoadFromFile("C:\\Users\\vlad.sobolev\\Downloads\\arfoundation-samples-main\\arfoundation-samples-main\\Assets\\AssetBundles\\"+ assetBundleName);
        if (bundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }
    GameObject cube = bundle.LoadAsset<GameObject>("XC40_Recharge_Prefab");
    //GameObject sprite = bundle.LoadAsset<GameObject>("Sprite");
    Instantiate(cube);
    //Instantiate(sprite);
}
}

class MyCertHandler:CertificateHandler
{
    protected override bool ValidateCertificate(byte[] certificateData)
    {
        return true;
    }
}