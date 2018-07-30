using UnityEngine;
using UnityEngine.UI;

public class TextureTest : MonoBehaviour
{

    public Image image;

    // Update is called once per frame
    void Update()
    {
        Debug.LogFormat("TextureTest frame: {0} sprite:{1} texture:{2}", Time.frameCount, image.sprite, image.sprite.texture);
    }
}
