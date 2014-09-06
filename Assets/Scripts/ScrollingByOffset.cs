using UnityEngine;
using System.Collections;

public class ScrollingByOffset : MonoBehaviour {
    public float Speed = 2f;
    private Material ScrollMaterial;
	// Use this for initialization
	void Start () {
        ScrollMaterial = renderer.material;
	}
	
	// Update is called once per frame
	void Update () {
        ScrollMaterial.mainTextureOffset = new Vector2(Speed * Time.time, 0);
	}
}
