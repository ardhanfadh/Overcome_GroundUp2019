using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceBox : MonoBehaviour {
    public Direction boxDirection;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.GetComponent<PlayerControl>() != null)
            {
                if (boxDirection == Direction.Atas)
                {
                    StartCoroutine(LemparAtas(collision.GetComponent<PlayerControl>()));
                }
                if (boxDirection == Direction.Bawah)
                {
                   StartCoroutine(LemparBawah(collision.GetComponent<PlayerControl>()));
                }
                if (boxDirection == Direction.Kanan)
                {
                    StartCoroutine(LemparKanan(collision.GetComponent<PlayerControl>()));
                }
                if (boxDirection == Direction.Kiri)
                {
                    StartCoroutine(LemparKiri(collision.GetComponent<PlayerControl>()));
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.GetComponent<PlayerControl>() != null)
            {
                if (boxDirection == Direction.Atas)
                {
                    //StartCoroutine(LemparAtas(collision.GetComponent<PlayerControl>()));
                    BeresLempar_Atas(collision.GetComponent<PlayerControl>());
                }
                if (boxDirection == Direction.Bawah)
                {
                    //StartCoroutine(LemparBawah(collision.GetComponent<PlayerControl>()));
                    BeresLempar_Bawah(collision.GetComponent<PlayerControl>());
                }
                if (boxDirection == Direction.Kanan)
                {
                    //StartCoroutine(LemparKanan(collision.GetComponent<PlayerControl>()));
                    BeresLempar_Kanan(collision.GetComponent<PlayerControl>());
                }
                if (boxDirection == Direction.Kiri)
                {
                    //StartCoroutine(LemparKiri(collision.GetComponent<PlayerControl>()));
                    BeresLempar_Kiri(collision.GetComponent<PlayerControl>());
                }
            }
        }
    }

    IEnumerator LemparAtas(PlayerControl player)
    {

        player.rgbd2D.bodyType = RigidbodyType2D.Kinematic;
        player.pDirection = Direction.Atas;
        player.rgbd2D.velocity = Vector2.zero;
        player.rgbd2D.constraints = RigidbodyConstraints2D.FreezePositionX;
        player.gameObject.transform.position = transform.position;
        yield return new WaitForSeconds(1f);
        player.rgbd2D.bodyType = RigidbodyType2D.Dynamic;
        Physics2D.gravity = Vector2.up * player.GV;
        player.rgbd2D.velocity = Vector2.zero;
        player.rgbd2D.AddForce(Vector2.up * player.ForceAdded);
        player.rotatePlayer.PutarAtas();
        player.animPlayer.SetBool("isForceAtas",true);
        player.animPlayer.SetBool("isForceAtas", true);
        player.animCollision.SetBool("isForceAtas", true);
        player.animCollision.SetBool("isForceAtas", true);
    }

    public void BeresLempar_Atas(PlayerControl player)
    {
        player.animPlayer.SetBool("isForceAtas", false);
        player.animPlayer.SetBool("isForceAtas", false);

        player.animCollision.SetBool("isForceAtas", false);
        player.animCollision.SetBool("isForceAtas", false);
    }

    IEnumerator LemparBawah(PlayerControl player)
    {
        player.rgbd2D.bodyType = RigidbodyType2D.Kinematic;
        player.pDirection = Direction.Bawah;
        player.rgbd2D.velocity = Vector2.zero;
        player.rgbd2D.constraints = RigidbodyConstraints2D.FreezePositionX;
        player.gameObject.transform.position = transform.position;
        yield return new WaitForSeconds(1f);
        player.rgbd2D.bodyType = RigidbodyType2D.Dynamic;
        Physics2D.gravity = Vector2.down * player.GV;
        player.rgbd2D.velocity = Vector2.zero;
        player.rgbd2D.AddForce(Vector2.down * player.ForceAdded);
        player.rotatePlayer.PutarBawah();
        player.animPlayer.SetBool("isForceBawah", true);
        player.animPlayer.SetBool("isForceBawah", true);
        player.animCollision.SetBool("isForceBawah", true);
        player.animCollision.SetBool("isForceBawah",true);
    }

    public void BeresLempar_Bawah(PlayerControl player)
    {
        player.animPlayer.SetBool("isForceBawah", false);
        player.animPlayer.SetBool("isForceBawah", false);
        player.animCollision.SetBool("isForceBawah", false);
        player.animCollision.SetBool("isForceBawah", false);
    }

    IEnumerator LemparKanan(PlayerControl player)
    {
        player.rgbd2D.bodyType = RigidbodyType2D.Kinematic;
        player.pDirection = Direction.Kanan;
        player.rgbd2D.velocity = Vector2.zero;
        player.rgbd2D.constraints = RigidbodyConstraints2D.FreezePositionY;
        player.gameObject.transform.position = transform.position;
        yield return new WaitForSeconds(1f);
        player.rgbd2D.bodyType = RigidbodyType2D.Dynamic;
        Physics2D.gravity = Vector2.right * player.GV;
        player.rgbd2D.velocity = Vector2.zero;
        player.rgbd2D.AddForce(Vector2.right * player.ForceAdded);
        player.rotatePlayer.PutarKanan();
        player.animPlayer.SetBool("isForceKanan", true);
        player.animPlayer.SetBool("isForceKanan", true);
        player.animCollision.SetBool("isForceKanan", true);
        player.animCollision.SetBool("isForceKanan", true);
    }

    public void BeresLempar_Kanan(PlayerControl player)
    {
        player.animPlayer.SetBool("isForceKanan", false);
        player.animPlayer.SetBool("isForceKanan", false);
        player.animCollision.SetBool("isForceKanan", false);
        player.animCollision.SetBool("isForceKanan", false);
    }

    IEnumerator LemparKiri(PlayerControl player)
    {
        player.rgbd2D.bodyType = RigidbodyType2D.Kinematic;
        player.pDirection = Direction.Kiri;
        player.rgbd2D.velocity = Vector2.zero;
        player.rgbd2D.constraints = RigidbodyConstraints2D.FreezePositionY;
        player.gameObject.transform.position = transform.position;
        yield return new WaitForSeconds(1f);
        player.rgbd2D.bodyType = RigidbodyType2D.Dynamic;
        Physics2D.gravity = Vector2.left * player.GV;
        player.rgbd2D.velocity = Vector2.zero;
        player.rgbd2D.AddForce(Vector2.left * player.ForceAdded);
        player.rotatePlayer.PutarKiri();
        player.animPlayer.SetBool("isForceKiri", true);
        player.animPlayer.SetBool("isForceKiri", true);
        player.animCollision.SetBool("isForceKiri", true);
        player.animCollision.SetBool("isForceKiri", true);
    }

    public void BeresLempar_Kiri(PlayerControl player)
    {
        player.animPlayer.SetBool("isForceKiri", false);
        player.animPlayer.SetBool("isForceKiri", false);
        player.animCollision.SetBool("isForceKiri", false);
        player.animCollision.SetBool("isForceKiri", false);
    }
}
