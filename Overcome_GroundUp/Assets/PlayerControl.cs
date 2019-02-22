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
    public Animator animCollision;

    public GameObject player;

    public RotationScript rotatePlayer;

    public bool onGround;
    public bool isValid;
    public Direction pDirection;
    public Direction LastDirection;
    public Rigidbody2D rgbd2D;
    public BoxCollider2D box2D;
    public CollisionGround cG;
    public float GV;
    public bool bodyGround;
    public bool justOnce;

    public detectingGround atasDetect;
    public detectingGround bawahDetect;
    public detectingGround kiriDetect;
    public detectingGround kananDetect;

	// Use this for initialization
	void Start () {
        GameObject.Find("SwipeController").GetComponent<SwipeControl>().SetMethodToCall(SwipeDetection);
        //Debug
        GV = 1f;

        animPlayer.SetInteger("X", 0);
        animPlayer.SetInteger("Y", -1);
        animCollision.SetInteger("X", 0);
        animCollision.SetInteger("Y", -1);
        Terbang(Direction.Bawah);
        StartCoroutine(animJump());
        LastDirection = Direction.Bawah;

    }

    private void SwipeDetection(SwipeControl.SWIPE_DIRECTION iDirection)
    {
        Debug.Log(iDirection);
        switch (iDirection)
        {
            case SwipeControl.SWIPE_DIRECTION.SD_DOWN:
                if (animPlayer.GetBool("isFinished"))
                {
                    if (LastDirection == Direction.Bawah)
                    {
                        break;
                    }
                    else
                    {
                        pDirection = Direction.Bawah;

                        rgbd2D.constraints = RigidbodyConstraints2D.FreezePositionX;
                        Terbang(pDirection);
                    }
                }
                //what to do buat Bawah
                //ganti gravity jadi ke bawah
                //ganti animasi jadi ke bawah pake coroutine.
                break;
            case SwipeControl.SWIPE_DIRECTION.SD_LEFT:
                if (animPlayer.GetBool("isFinished"))
                {
                    if (LastDirection == Direction.Kiri)
                    {
                        break;
                    }
                    else
                    {
                        pDirection = Direction.Kiri;

                        rgbd2D.constraints = RigidbodyConstraints2D.FreezePositionY;
                        Terbang(pDirection);
                    }
                }
               
                //what to do buat Kiri
                //ganti gravity jadi ke kiri
                //ganti animasi jadi ke kiri pake coroutine.
                break;
            case SwipeControl.SWIPE_DIRECTION.SD_RIGHT:
                if (animPlayer.GetBool("isFinished"))
                {
                    if (LastDirection == Direction.Kanan)
                    {
                        break;
                    }
                    else
                    {
                        pDirection = Direction.Kanan;

                        rgbd2D.constraints = RigidbodyConstraints2D.FreezePositionY;

                        Terbang(pDirection);
                    }
                }
                //what to do buat Kanan
                //ganti gravity jadi ke kanan
                //ganti animasi jadi ke kanan pake coroutine
                break;
            case SwipeControl.SWIPE_DIRECTION.SD_UP:
                if (animPlayer.GetBool("isFinished"))
                {
                    if (LastDirection == Direction.Atas)
                    {
                        break;
                    }
                    else
                    {
                        pDirection = Direction.Atas;
                        rgbd2D.constraints = RigidbodyConstraints2D.FreezePositionX;

                        Terbang(pDirection);
                    }
                }
                /*
                if (animPlayer.GetBool("isFinished") == true)
                {
                    Terbang(pDirection);
                }*/
                //Animation
                
                //what to do buat Atas
                //ganti gravity jadi ke atas
                //ganti animasi jadi ke atas pake coroutine.
                break;
        }
    }
	// Update is called once per frame
	void Update () {
        /*
        bodyGround = cG.isGround;

        if (bodyGround)
        {
                animPlayer.SetBool("Mendarat", true);
                animCollision.SetBool("Mendarat", true);
                box2D.isTrigger = false;
                cG.box2D.isTrigger = true;
            if (pDirection == Direction.Atas)
            {
                rotatePlayer.PutarAtas();
            }
        }
        */
	}

    private void Terbang(Direction pDirection)
    {
        if (pDirection == Direction.Atas)
        {
            Physics2D.gravity = Vector2.up * GV;
            rgbd2D.velocity = Vector2.zero;
            rgbd2D.AddForce(Vector2.up * 10);

            if (LastDirection == Direction.Kanan)
            {
                AnimTerbang(Direction.Kanan);
            }

            if (LastDirection == Direction.Kiri)
            {
                AnimTerbang(Direction.Kiri);
            }

            if (LastDirection == Direction.Bawah)
            {
                AnimTerbang(Direction.Atas);
            }

            //Animation
            /*
            animPlayer.SetInteger("X", 0);
            animPlayer.SetInteger("Y", 1);

            StartCoroutine(animJump());
            */
        }

        if (pDirection == Direction.Bawah)
        {
            Physics2D.gravity = Vector2.down * GV;
            rgbd2D.velocity = Vector2.zero;
            rgbd2D.AddForce(Vector2.down * 10);

            if (LastDirection == Direction.Atas)
            {
                AnimTerbang(Direction.Atas);
            }
            if (LastDirection == Direction.Kanan)
            {
                AnimTerbang(Direction.Kiri);
            }
            if (LastDirection == Direction.Kiri)
            {
                AnimTerbang(Direction.Kanan);
            }

            /*
            */
        }

        if (pDirection == Direction.Kanan)
        {
            Physics2D.gravity = Vector2.right * GV;
            rgbd2D.velocity = Vector2.zero;
            rgbd2D.AddForce(Vector2.right * 10);

            if (LastDirection == Direction.Kiri)
            {
                AnimTerbang(Direction.Atas);
            }

            if (LastDirection == Direction.Bawah)
            {
                AnimTerbang(Direction.Kanan);
            }

            if (LastDirection == Direction.Atas)
            {
                AnimTerbang(Direction.Kiri);
            }
            
            /*
            */
        }

        if (pDirection == Direction.Kiri)
        {
            Physics2D.gravity = Vector2.left * GV;
            rgbd2D.velocity = Vector2.zero;
            rgbd2D.AddForce(Vector2.left * 10);

            if (LastDirection == Direction.Kanan)
            {
                AnimTerbang(Direction.Atas);
            }

            if (LastDirection == Direction.Atas)
            {
                AnimTerbang(Direction.Kanan);
            }

            if (LastDirection == Direction.Bawah)
            {
                AnimTerbang(Direction.Kiri);
            }

            /*
            */
        }
        /*
        box2D.isTrigger = true;
        cG.box2D.isTrigger = false;*/
    }

    private void AnimTerbang(Direction animDirect)
    {
        if (animDirect == Direction.Atas)
        {
            animPlayer.SetInteger("X", 0);
            animPlayer.SetInteger("Y", 1);
            animCollision.SetInteger("X", 0);
            animCollision.SetInteger("Y", 1);

            StartCoroutine(animJump());
        }
        if(animDirect == Direction.Bawah)
        {
            animPlayer.SetInteger("X", 0);
            animPlayer.SetInteger("Y", -1);
            animCollision.SetInteger("X", 0);
            animCollision.SetInteger("Y", -1);
            StartCoroutine(animJump());
        }
        if (animDirect == Direction.Kanan)
        {
            animPlayer.SetInteger("X", 1);
            animPlayer.SetInteger("Y", 0);
            animCollision.SetInteger("X", 1);
            animCollision.SetInteger("Y", 0);
            StartCoroutine(animJump());
        }
        if (animDirect == Direction.Kiri)
        {

            animPlayer.SetInteger("X", -1);
            animPlayer.SetInteger("Y", 0);
            animCollision.SetInteger("X", -1);
            animCollision.SetInteger("Y", 0);
            StartCoroutine(animJump());
        }
    }

    IEnumerator animJump()
    {
        animPlayer.SetBool("isFinished", false);
        animCollision.SetBool("isFinished", false);
        box2D.isTrigger = true;
        cG.box2D.isTrigger = false;
        animPlayer.SetBool("StartJump", true);
        animCollision.SetBool("StartJump", true);
        yield return new WaitForSeconds(0.45f);
        animPlayer.SetBool("Terbang", true);
        animCollision.SetBool("Terbang", true);
    }

    IEnumerator animLanding()
    {
        rgbd2D.Sleep();
        rgbd2D.velocity = Vector3.zero;

        rgbd2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        box2D.isTrigger = false;
        cG.box2D.isTrigger = true;

        if (pDirection == Direction.Atas)
        {
            rotatePlayer.playerDirection = pDirection;
            transform.localEulerAngles = new Vector3(0, 0, 180);
            LastDirection = Direction.Atas;
        }
        if (pDirection == Direction.Bawah)
        {
            rotatePlayer.playerDirection = pDirection;
            transform.localEulerAngles = new Vector3(0, 0, 0);
            //transform.localEulerAngles = new Vector3(0, 0, 0);
            LastDirection = Direction.Bawah;
        }
        if (pDirection == Direction.Kanan)
        {
            rotatePlayer.playerDirection = pDirection;
            transform.localEulerAngles = new Vector3(0, 0, 90);
            //transform.localEulerAngles = new Vector3(0, 0, 90);
            LastDirection = Direction.Kanan;
        }
        if (pDirection == Direction.Kiri)
        {
            rotatePlayer.playerDirection = pDirection;
            transform.localEulerAngles = new Vector3(0, 0, -90);
            //transform.localEulerAngles = new Vector3(0, 0, -90);
            LastDirection = Direction.Kiri;
        }

        animPlayer.SetBool("Mendarat", true);
        animCollision.SetBool("Mendarat", true);
        yield return new WaitForSeconds(1);
        animPlayer.SetBool("Bangun", true);
        animCollision.SetBool("Bangun", true);
        yield return new WaitForSeconds(2f);
        animPlayer.SetBool("StartJump", false);
        animPlayer.SetBool("Terbang", false);
        animPlayer.SetBool("Mendarat", false);
        animPlayer.SetBool("Bangun", false);

        animCollision.SetBool("StartJump", false);
        animCollision.SetBool("Terbang", false);
        animCollision.SetBool("Mendarat", false);
        animCollision.SetBool("Bangun", false);
        yield return new WaitForSeconds(1);
        animPlayer.SetBool("isFinished", true);
        animCollision.SetBool("isFinished", true);
        rgbd2D.WakeUp();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(animLanding());
    }

    void Landing()
    {
        animPlayer.SetBool("Mendarat", true);
    }

    public void anim_Bangun()
    {
        animPlayer.SetBool("isFinished", true);
        animCollision.SetBool("isFinished", true);
    }

    public void anim_Finished()
    {
        animPlayer.SetBool("isFinished", false);
        animPlayer.SetBool("Mendarat", false);
        animPlayer.SetBool("Terbang", false);

        animCollision.SetBool("isFinished", false);
        animCollision.SetBool("Mendarat", false);
        animCollision.SetBool("Terbang", false);
        rgbd2D.constraints = RigidbodyConstraints2D.None;
        onGround = true;
        cG.isGround = false;
        Debug.Log(bodyGround);
    }
}
