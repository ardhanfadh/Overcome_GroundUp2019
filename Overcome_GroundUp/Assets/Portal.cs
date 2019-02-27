using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
    public bool isPortalOut;
    public bool isPlayerOverlap;
    public Animator portalAnim;
    public GameObject target;
    public AudioSource speaker;
    public AudioClip soundPortal;
    public Direction portalDirection;
	// Use this for initialization
	void Start () {
        if (isPortalOut)
        {
            portalAnim.SetBool("isPortalOut", true);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (portalDirection == Direction.Atas)
            {
                if (collision.GetComponent<PlayerControl>().pDirection == Direction.Atas)
                {

                    isPlayerOverlap = true;
                    collision.transform.position = target.transform.position;
                    speaker.clip = soundPortal;
                    speaker.Play();
                }
            }
            if (portalDirection == Direction.Bawah)
            {
                if (collision.GetComponent<PlayerControl>().pDirection == Direction.Bawah)
                {
                    isPlayerOverlap = true;
                    collision.transform.position = target.transform.position;
                    speaker.clip = soundPortal;
                    speaker.Play();
                }
            }
            if (portalDirection == Direction.Kanan)
            {
                if (collision.GetComponent<PlayerControl>().pDirection == Direction.Kanan)
                {
                    isPlayerOverlap = true;
                    collision.transform.position = target.transform.position;
                    speaker.clip = soundPortal;
                    speaker.Play();
                }
            }
            if (portalDirection == Direction.Kiri)
            {
                if (collision.GetComponent<PlayerControl>().pDirection == Direction.Kiri)
                {
                    isPlayerOverlap = true;
                    collision.transform.position = target.transform.position;
                    speaker.clip = soundPortal;
                    speaker.Play();
                }
            }
        }
    }
}
