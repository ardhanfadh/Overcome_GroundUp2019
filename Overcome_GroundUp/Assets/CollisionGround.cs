using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionGround : MonoBehaviour {
    public bool isGround;
    public BoxCollider2D box2D;
	// Use this for initialization
	void Start () {
        isGround = false;
	}
	
	// Update is called once per frame
	void Update () {
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isGround = true;
            box2D.isTrigger = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isGround = false;
        }
    }

}
