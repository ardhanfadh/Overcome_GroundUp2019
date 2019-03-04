using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.LuisPedroFonseca.ProCamera2D;
using TMPro;

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
    [Space]
    public GameObject player;
    public RotationScript rotatePlayer;
    [Space]
    public bool onGround;
    public bool isValid;
    public Direction pDirection;
    public Direction LastDirection;
    [Space]
    public Rigidbody2D rgbd2D;
    public BoxCollider2D box2D;
    public CollisionGround cG;
    [Space]
    public float GV;
    public float ForceAdded;
    public bool bodyGround;
    public bool justOnce;
    [Space]
    public detectingGround atasDetect;
    public bool atasGround;
    public detectingGround bawahDetect;
    public bool bawahGround;
    public detectingGround kiriDetect;
    public bool KiriGround;
    public detectingGround kananDetect;
    public bool KananGround;
    [Space]
    public bool firstTime;
    public bool isCompleted;
    [Space]
    public AudioSource audio;
    [Space]
    public AudioClip RagaSound;
    public AudioClip hurtTrap;
    [Space]
    public int stepTaken;
    [Space]
    public TextMeshPro textMesh_UI;
	// Use this for initialization
	void Start () {
        GameObject.Find("SwipeController").GetComponent<SwipeControl>().SetMethodToCall(SwipeDetection);
        //Debug
        GV = 3f;
        ForceAdded = 200;

        animPlayer.SetBool("isCompleted", false);
        animCollision.SetBool("isCompleted", false);
        isCompleted = false;
        animPlayer.SetInteger("X", 0);
        animPlayer.SetInteger("Y", -1);
        animCollision.SetInteger("X", 0);
        animCollision.SetInteger("Y", -1);
        firstTime = true;
        Terbang(Direction.Bawah);
        StartCoroutine(animJump());
        LastDirection = Direction.Bawah;
        justOnce = false;
        stepTaken = 0;
        textMesh_UI.text = stepTaken + "";
    }

    private void SwipeDetection(SwipeControl.SWIPE_DIRECTION iDirection)
    {
        Debug.Log(iDirection);
        switch (iDirection)
        {
            case SwipeControl.SWIPE_DIRECTION.SD_DOWN:
                if (animCollision.GetBool("isFinished"))
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
                        animPlayer.SetBool("isFinished", false);
                        animCollision.SetBool("isFinished", false);
                        addStep();
                    }
                }
                   
                //what to do buat Bawah
                //ganti gravity jadi ke bawah
                //ganti animasi jadi ke bawah pake coroutine.
                break;
            case SwipeControl.SWIPE_DIRECTION.SD_LEFT:
                if (animCollision.GetBool("isFinished"))
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
                        animPlayer.SetBool("isFinished", false);
                        animCollision.SetBool("isFinished", false);
                        addStep();
                    }
                }

                //what to do buat Kiri
                //ganti gravity jadi ke kiri
                //ganti animasi jadi ke kiri pake coroutine.
                break;
            case SwipeControl.SWIPE_DIRECTION.SD_RIGHT:
                if (animCollision.GetBool("isFinished"))
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
                        animPlayer.SetBool("isFinished", false);
                        animCollision.SetBool("isFinished", false);
                        addStep();
                    }
                }
                    
                //what to do buat Kanan
                //ganti gravity jadi ke kanan
                //ganti animasi jadi ke kanan pake coroutine
                break;
            case SwipeControl.SWIPE_DIRECTION.SD_UP:
                if (animCollision.GetBool("isFinished"))
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
                        animPlayer.SetBool("isFinished", false);
                        animCollision.SetBool("isFinished", false);
                        addStep();
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

    private void FixedUpdate()
    {
        atasGround = atasDetect.isDetected;
        bawahGround = bawahDetect.isDetected;
        KiriGround = kiriDetect.isDetected;
        KananGround = kananDetect.isDetected;
        if (isCompleted)
        {
            animPlayer.SetBool("isFinished", false);
            animCollision.SetBool("isFinished", false);
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

    public void Terbang(Direction pDirection)
    {
        justOnce = false;
        if (firstTime)
        {
            firstTime = false;
            if (pDirection == Direction.Atas)
            {
                Physics2D.gravity = Vector2.up * GV;
                rgbd2D.velocity = Vector2.zero;
                rgbd2D.AddForce(Vector2.up * ForceAdded);

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
                rgbd2D.AddForce(Vector2.down * ForceAdded);

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
                rgbd2D.AddForce(Vector2.right * ForceAdded);

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
                rgbd2D.AddForce(Vector2.left * ForceAdded);

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
        }
        else
        {
            if (animCollision.GetBool("isFinished"))
            {

                animPlayer.SetBool("isFinished", false);
                animCollision.SetBool("isFinished", false);
                if (pDirection == Direction.Atas)
                {
                    Physics2D.gravity = Vector2.up * GV;
                    rgbd2D.velocity = Vector2.zero;
                    rgbd2D.AddForce(Vector2.up * ForceAdded);

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
                    rgbd2D.AddForce(Vector2.down * ForceAdded);

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
                    rgbd2D.AddForce(Vector2.right * ForceAdded);

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
                    rgbd2D.AddForce(Vector2.left * ForceAdded);

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
            }
        }
        
       
        /*
        box2D.isTrigger = true;
        cG.box2D.isTrigger = false;*/
    }

    public void AnimTerbang(Direction animDirect)
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
        box2D.isTrigger = true;
        cG.box2D.isTrigger = false;
        animPlayer.SetBool("StartJump", true);
        animCollision.SetBool("StartJump", true);
        yield return new WaitForSeconds(0);
    }

    public void ResetAll()
    {
        animPlayer.SetBool("StartJump", false);
        animPlayer.SetBool("Terbang", false);
        animPlayer.SetBool("Mendarat", false);
        animPlayer.SetBool("Bangun", false);
        animPlayer.SetBool("isFinished", true);

        animPlayer.SetBool("isForceAtas", false);
        animPlayer.SetBool("isForceBawah", false);
        animPlayer.SetBool("isForceKanan", false);
        animPlayer.SetBool("isForceKiri", false);

        animCollision.SetBool("StartJump", false);
        animCollision.SetBool("Terbang", false);
        animCollision.SetBool("Mendarat", false);
        animCollision.SetBool("Bangun", false);
        animCollision.SetBool("isFinished", true);

        animCollision.SetBool("isForceAtas", false);
        animCollision.SetBool("isForceBawah", false);
        animCollision.SetBool("isForceKanan", false);
        animCollision.SetBool("isForceKiri", false);
    }
    public void TransitionJump()
    {
        animPlayer.SetBool("Terbang", true);
        animCollision.SetBool("Terbang", true);
    }



    IEnumerator animLanding()
    {
        if (justOnce)
        {

        }
        else
        {
            justOnce = true;
            rgbd2D.Sleep();
            rgbd2D.velocity = Vector3.zero;

            rgbd2D.constraints = RigidbodyConstraints2D.FreezeRotation;
            box2D.isTrigger = false;
            cG.box2D.isTrigger = true;

            animPlayer.SetBool("isFinished", false);
            animCollision.SetBool("isFinished", false);
            animPlayer.SetBool("Mendarat", true);
            animCollision.SetBool("Mendarat", true);

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
            yield return new WaitForSeconds(0.1f);
            animPlayer.SetBool("Bangun", true);
            animCollision.SetBool("Bangun", true);
        }
   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            StartCoroutine(animLanding());
        }

        if (collision.gameObject.tag == "Goal")
        {
            CompletedGoal();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }

    void CompletedGoal()
    {
        animPlayer.SetBool("isCompleted", true);
        animCollision.SetBool("isCompleted", true);
        isCompleted = true;
        audio.clip = RagaSound;
        audio.Play();
    }

    private void Landing()
    {
        animPlayer.SetBool("Mendarat", true);
        animCollision.SetBool("Mendarat", true);

    }

    public void anim_Bangun()
    {
        animPlayer.SetBool("StartJump", false);
        animPlayer.SetBool("Terbang", false);
        animPlayer.SetBool("Mendarat", false);
        animPlayer.SetBool("Bangun", false);

        animCollision.SetBool("StartJump", false);
        animCollision.SetBool("Terbang", false);
        animCollision.SetBool("Mendarat", false);
        animCollision.SetBool("Bangun", false);
        //yield return new WaitForSeconds(0.2f);
        animPlayer.SetBool("isFinished", true);
        animCollision.SetBool("isFinished", true);
        rgbd2D.WakeUp();
        rotatePlayer.JustOnce = false;
        justOnce = true; 
    }

    public void addStep()
    {
        stepTaken++;
        textMesh_UI.text = stepTaken + "";
    }
}
