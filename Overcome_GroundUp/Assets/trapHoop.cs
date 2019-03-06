using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapHoop : MonoBehaviour {
    public Direction trapDirection;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (trapDirection)
            {
                case Direction.Atas:
                    if (collision.GetComponent<PlayerControl>().pDirection == Direction.Atas ||
                        collision.GetComponent<PlayerControl>().pDirection == Direction.Bawah)
                    {
                        collision.GetComponent<PlayerControl>().trapAddStep();
                    }
                    break;
                case Direction.Bawah:
                    if (collision.GetComponent<PlayerControl>().pDirection == Direction.Atas ||
                       collision.GetComponent<PlayerControl>().pDirection == Direction.Bawah)
                    {
                        collision.GetComponent<PlayerControl>().trapAddStep();
                    }
                    break;
                case Direction.Kanan:
                    if (collision.GetComponent<PlayerControl>().pDirection == Direction.Kanan ||
                        collision.GetComponent<PlayerControl>().pDirection == Direction.Kiri)
                    {
                        collision.GetComponent<PlayerControl>().trapAddStep();
                    }
                    break;
                case Direction.Kiri:
                    if (collision.GetComponent<PlayerControl>().pDirection == Direction.Kanan ||
                        collision.GetComponent<PlayerControl>().pDirection == Direction.Kiri)
                    {
                        collision.GetComponent<PlayerControl>().trapAddStep();
                    }
                    break;
            }
        }
    }
}
