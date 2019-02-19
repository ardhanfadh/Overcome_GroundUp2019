using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Atas,
    Bawah,
    Kiri,
    Kanan
}

public class PlayerControl : MonoBehaviour {
    public Animator animPlayer;
    public bool onGround;
    public bool isValid;
    public Direction pDirection;
    public Rigidbody2D rgbd2D;
    public BoxCollider2D box2D;
    public CollisionGround cG;
    public bool bodyGround;
	// Use this for initialization
	void Start () {
        GameObject.Find("SwipeController").GetComponent<SwipeControl>().SetMethodToCall(SwipeDetection);
        //Debug
        box2D.isTrigger = true;
	}

    private void SwipeDetection(SwipeControl.SWIPE_DIRECTION iDirection)
    {
        Debug.Log(iDirection);
        switch (iDirection)
        {
            case SwipeControl.SWIPE_DIRECTION.SD_DOWN:
                Physics.gravity = new Vector3(0, -1.0F, 0);
                pDirection = Direction.Bawah;
                if (isValid)
                {
                    rgbd2D.constraints = RigidbodyConstraints2D.FreezePositionX;
                    Terbang(pDirection);
                }
                //what to do buat Bawah
                //ganti gravity jadi ke bawah
                //ganti animasi jadi ke bawah pake coroutine.
                break;
            case SwipeControl.SWIPE_DIRECTION.SD_LEFT:
                Physics.gravity = new Vector3(-1.0F, 0, 0);
                pDirection = Direction.Kiri;
                if (isValid)
                {
                    rgbd2D.constraints = RigidbodyConstraints2D.FreezePositionY;
                    Terbang(pDirection);
                }
                //what to do buat Kiri
                //ganti gravity jadi ke kiri
                //ganti animasi jadi ke kiri pake coroutine.
                break;
            case SwipeControl.SWIPE_DIRECTION.SD_RIGHT:
                Physics.gravity = new Vector3(1,0, 0);
                pDirection = Direction.Kanan;
                if (isValid)
                {
                    rgbd2D.constraints = RigidbodyConstraints2D.FreezePositionY;
                    Terbang(pDirection);
                }
                //what to do buat Kanan
                //ganti gravity jadi ke kanan
                //ganti animasi jadi ke kanan pake coroutine
                break;
            case SwipeControl.SWIPE_DIRECTION.SD_UP:
                Physics.gravity = new Vector3(0, 1, 0);
                pDirection = Direction.Atas;
                if (isValid)
                {
                    rgbd2D.constraints = RigidbodyConstraints2D.FreezePositionX;
                    Terbang(pDirection);
                }
                //what to do buat Atas
                //ganti gravity jadi ke atas
                //ganti animasi jadi ke atas pake coroutine.
                break;
        }
    }
	// Update is called once per frame
	void Update () {
        bodyGround = cG.isGround;
        if (bodyGround)
        {
            animPlayer.SetBool("Mendarat", true);
            box2D.isTrigger = false;
            cG.box2D.isTrigger = true;
        }
	}

    private void Terbang(Direction pDirection)
    {

        if (pDirection == Direction.Atas)
        {
            animPlayer.SetInteger("X", 0);
            animPlayer.SetInteger("Y", 1);
            animPlayer.SetBool("Terbang", true);
        }
        else if (pDirection == Direction.Bawah)
        {
            animPlayer.SetInteger("X", 0);
            animPlayer.SetInteger("Y", -1);
            animPlayer.SetBool("Terbang", true);
        }
        else if (pDirection == Direction.Kanan)
        {
            animPlayer.SetInteger("X", 1);
            animPlayer.SetInteger("Y", 0);
            animPlayer.SetBool("Terbang", true);
        }
        else if (pDirection == Direction.Kiri)
        {
            animPlayer.SetInteger("X", -1);
            animPlayer.SetInteger("Y", 0);
            animPlayer.SetBool("Terbang", true);
        }
        box2D.isTrigger = true;
        cG.box2D.isTrigger = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            animPlayer.SetBool("Mendarat", true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            onGround = false;
        }
    }

    void Landing()
    {
        animPlayer.SetBool("Mendarat", true);
    }

    public void anim_Bangun()
    {
        animPlayer.SetBool("isFinished", true);
    }

    public void anim_Finished()
    {
        animPlayer.SetBool("isFinished", false);
        animPlayer.SetBool("Mendarat", false);
        animPlayer.SetBool("Terbang", false);
        onGround = true;
    }
}
