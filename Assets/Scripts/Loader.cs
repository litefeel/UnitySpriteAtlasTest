using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

	public static Object LoadAsset(string abpath, string assetName, System.Type type = null)
    {
        var ab = LoadAB(abpath);
        if (ab == null)
            return null;

        return ab.LoadAsset(assetName, type != null ? type : typeof(Object));
    }

    public static T LoadAsset<T>(string abpath, string assetName) where T : Object
    {
        return LoadAsset(abpath, assetName, typeof(T)) as T;
    }

    public static Object LoadPrefab(string abpath, string assetName, Transform parent = null, bool worldspace = false, System.Type type = null)
    {
        var ab = LoadAB(abpath);
        if (ab == null)
            return null;
        GameObject prefab = ab.LoadAsset<GameObject>(assetName);
        if (type == null)
            type = typeof(GameObject);

        if (type == typeof(GameObject))
            return GameObject.Instantiate<GameObject>(prefab, parent, worldspace);

        Object prefabType = prefab.GetComponent(type);
        if (prefabType == null)
            return null;

        return GameObject.Instantiate(prefabType, parent, worldspace);
    }

    public static T LoadPrefab<T>(string abpath, string assetName, Transform parent = null, bool worldspace = false) where T : Object
    {
        return LoadPrefab(abpath, assetName, parent, worldspace, typeof(T)) as T;
    }

    private static AssetBundle LoadAB(string abpath)
    {
        string path = PlatformPath.StreamingPath(abpath);
        return AssetBundle.LoadFromFile(path);
    }
}
