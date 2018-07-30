using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPath {

#if UNITY_EDITOR
    public static string ToString(UnityEditor.BuildTarget target)
    {
        switch (target)
        {
            case UnityEditor.BuildTarget.StandaloneWindows:
            case UnityEditor.BuildTarget.StandaloneWindows64:
                return "Windows";
            case UnityEditor.BuildTarget.Android:
                return "Android";
            case UnityEditor.BuildTarget.iOS:
                return "iOS";
            case UnityEditor.BuildTarget.StandaloneOSX:
                return "Mac";
            default:
                return "Unknow";
        }
    }
#endif

    public static string ToString(RuntimePlatform target)
    {
        switch (target)
        {
            case RuntimePlatform.WindowsEditor:
            case RuntimePlatform.WindowsPlayer:
                return "Windows";
            case RuntimePlatform.Android:
                return "Android";
            case RuntimePlatform.IPhonePlayer:
                return "iOS";
            case RuntimePlatform.OSXEditor:
            case RuntimePlatform.OSXPlayer:
                return "Mac";
            default:
                return "Unknow";
        }
    }

    public static string StreamingPath(string relPath)
    {
        var path = ToString(Application.platform);
        path = string.Format("{0}/{1}/{2}", Application.streamingAssetsPath, path, relPath);
        Debug.LogError("streamingpath:" + path);
        return path;
    }
}
