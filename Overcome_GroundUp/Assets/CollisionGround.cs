using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionGround : MonoBehaviour {
    public bool isGround;
    public BoxCollider2D box2D;
    public bool isTriggerBox;
	// Use this for initialization
	void Start () {
        isGround = false;
        isTriggerBox = false;
	}
	
	// Update is called once per frame
	void Update () {
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isTriggerBox)
        {
            if (collision.gameObject.tag == "Wall")
            {
                isGround = true;
                box2D.isTrigger = true;
                isTriggerBox = true;
            }
        }
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Wall")
        {
            isGround = false;
        }
        else
        {
            isGround = true;
        }
    }

}
