using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class LoadAsset : MonoBehaviour {
    
    public static Dictionary<string, SpriteAtlas> map = new Dictionary<string, SpriteAtlas>();

    public static SpriteAtlas GetSA(string tag)
    {
        SpriteAtlas sa;
        map.TryGetValue(tag, out sa);

        if (sa == null)
            sa = LoadSpriteAtlas(tag);
        return sa;
    }

    private void Awake()
    {

    }

    public float delay;
	// Use this for initialization
	void Start () {
        StartCoroutine(DoLoadAsset(delay));
	}

    private static SpriteAtlas LoadSpriteAtlas(string tag)
    {
        var saab = AssetBundle.LoadFromFile(PlatformPath.StreamingPath(tag.ToLower()));
        var sa = saab.LoadAsset<SpriteAtlas>(tag);
        print("loaded " + tag + ":" + sa + " " + Time.frameCount);
        map.Add(tag, sa);
        return sa;
    }

    private IEnumerator DoLoadAsset(float delay)
    {
        yield return new WaitForSeconds(delay);
        
        var ab = AssetBundle.LoadFromFile(PlatformPath.StreamingPath("canvas"));
        var go = ab.LoadAsset<GameObject>("canvas");
        print("loaded canvas " + Time.frameCount);
        GameObject.Instantiate<GameObject>(go);
        print("instance canvas " + Time.frameCount);
    }
    
}
