using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Test : MonoBehaviour {

    SpriteAtlas sa;
    Image image;

    // Use this for initialization
    void Start () {
        image = GetComponent<Image>();

        //SpriteAtlasManager.atlasRequested += OnAtlasRequested;

        var saab = AssetBundle.LoadFromFile(PlatformPath.StreamingPath("StreamingAssets"));
        //foreach (var ss in saab.LoadAllAssets())
        //    print("sss " + ss);
        var manifest = saab.LoadAsset<AssetBundleManifest>("assetbundlemanifest");
        foreach(var abname in manifest.GetAllAssetBundles())
        {
            print("abname:" + abname);
        }
        foreach (var depname in manifest.GetAllDependencies("res/newspriteatlas"))
            print("depname:" + depname);

        

		//AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/aaaa");
        var ab = AssetBundle.LoadFromFile(PlatformPath.StreamingPath("newspriteatlas2"));

        var names = ab.GetAllAssetNames();
        foreach (var name in names)
        {
            print("assetname:" + name);
        }
        sa = ab.LoadAsset<SpriteAtlas>("newspriteatlas");
        //print("sa:" + sa);
        //foreach (var asset in ab.LoadAllAssets())
        //{
        //    print("asset " + asset.name + " " + asset + " " + asset.GetType());
        //}
        print("sa=" + sa + " " + sa.spriteCount + " " + sa.tag);
        //var sp = ab.LoadAsset<Sprite>("assets/icon/06.png");
        //print("xxx " + xxx + " " + xxx.GetType());
        var sp = sa.GetSprite("02");
        //image.sprite = sp;
        //print(sp.texture);
        //ab.Unload(false);
    }

    private void OnAtlasRequested(string tag, Action<SpriteAtlas> action)
    {
        print("OnAtlasRequested " + tag);
        
    }

    // Update is called once per frame
    void Update () {
		
	}
}
