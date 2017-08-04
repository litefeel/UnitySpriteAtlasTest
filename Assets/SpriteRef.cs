using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
[RequireComponent(typeof(Image))]
public class SpriteRef : MonoBehaviour {

    public string textureName;

    private Image image;
	// Use this for initialization
	void Awake () {
        image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        textureName = image.sprite.texture.name;
	}
}
