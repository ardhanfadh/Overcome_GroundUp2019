using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChanging : MonoBehaviour {
    public BoxCollider2D flyingCollider;
    public BoxCollider2D landedCollider;

	// Use this for initialization
	void Start () {
        flyingCollider.isTrigger = false;
        landedCollider.isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
