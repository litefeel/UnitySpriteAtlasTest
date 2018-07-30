using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class TestSpriteAtlas : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        SpriteAtlasManager.atlasRequested += OnAtlasRequested;
        print("awake frame:" + Time.frameCount);
        //AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/newspriteatlas");
        //AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/newspriteatlas2");
        //LoadAsset.LoadSpriteAtlas("NewSpriteAtlas2");
    }

    private void Start()
    {
    }

    private void OnAtlasRequested(string tag, Action<SpriteAtlas> action)
    {
        print("frame:" + Time.frameCount);
        print("OnAtlasRequested " + tag);

        //var ab = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + tag.ToLower());
        //var spriteAtlass = ab.LoadAsset<SpriteAtlas>(tag);
        //print("loaded spriteAtlass: " + spriteAtlass);
        //Sprite[] sps = new Sprite[1];
        //int len = spriteAtlass.GetSprites(sps);
        //print("len:" + len);
        //print("sprit:" + sps[0].texture);
        //action(spriteAtlass);
        //print("action " + LoadAsset.GetSA(tag));
        //action(LoadAsset.GetSA(tag));


        StartCoroutine(DoLoadAsset(action, tag));
    }

    private IEnumerator DoLoadAsset(Action<SpriteAtlas> action, string tag)
    {
        yield return new WaitForSeconds(3);
        var ab = AssetBundle.LoadFromFileAsync(PlatformPath.StreamingPath(tag.ToLower()));
        yield return ab;

        print("DoloadAsset frame:" + Time.frameCount);
        var sa = ab.assetBundle.LoadAsset<SpriteAtlas>(tag);
        print("sa: " + sa);
        action(sa);
    }
}
