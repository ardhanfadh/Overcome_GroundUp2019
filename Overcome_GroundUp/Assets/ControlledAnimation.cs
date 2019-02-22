using UnityEngine;
using System.Collections;
using Spine.Unity;
public class ControlledAnimation : MonoBehaviour
{
    #region Inspector
    // [SpineAnimation] attribute allows an Inspector dropdown of Spine animation names coming form SkeletonAnimation.

    [SpineAnimation]
    public static string idleAnimationName = "Idle";

    [SpineAnimation]
    public static string kiriAnimationName = "flying L";

    [SpineAnimation]
    public static string mulaiKiriAnimationName = "startjump L";

    [SpineAnimation]
    public static string kananAnimationName = "flying R";

    [SpineAnimation]
    public static string mulaiKananAnimationName = "startjump R";

    [SpineAnimation]
    public static string atasAnimationName = "flying U";

    [SpineAnimation]
    public static string mulaiAtasAnimationName = "startjump U";

    [SpineAnimation]
    public static string bawahAnimationName = "flying D";

    [SpineAnimation]
    public static string mulaiBawahAnimationName = "Flying to D";


    [SpineAnimation]
    public static string kenaTembokAtasAnimationName = "wall A";

    [SpineAnimation]
    public static string mulaiBerdiriTembokAtasAnimationName = "wall A to idle";

    [SpineAnimation]
    public static string kenaTembokBawahAnimationName = "wall B";

    [SpineAnimation]
    public static string mulaiBerdiriTembokBawahAnimationName = "wall B to idle";

    [SpineAnimation]
    public static string kenaTembokKiriAnimationName = "wall A";

    [SpineAnimation]
    public static string mulaiBerdiriTembokKiriName = "wall A to idle";

    [SpineAnimation]
    public static string kenaTembokKananAnimationName = "wall B";

    [SpineAnimation]
    public static string mulaiBerdiriTembokKananName = "wall B to idle";

    [SpineAnimation]
    public static string EndLevelLastAtas = "flying U Merge";

    [SpineAnimation]
    public static string EndLevelLastBawah = "flying D Merge";

    [SpineAnimation]
    public static string EndLevelLastKiri = "flying L Merge";

    [SpineAnimation]
    public static string EndLevelLastKanan = "flying R Merge";

    #endregion

    SkeletonAnimation skeletonAnimation;
    public static Spine.AnimationState spineAnimationState;
    public Spine.Skeleton skeleton;
    // Use this for initialization
    void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        spineAnimationState = skeletonAnimation.state;
        skeleton = skeletonAnimation.skeleton;
        Animate_gerakBawah();
        spineAnimationState.TimeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void Animate_gerakKiri()
    {
        spineAnimationState.SetAnimation(0, mulaiKiriAnimationName, false);
        spineAnimationState.AddAnimation(0, kiriAnimationName, true, 0.25f);
    }
    public static void Animate_gerakKanan()
    {
        spineAnimationState.SetAnimation(0, mulaiKananAnimationName, false);
        spineAnimationState.AddAnimation(0, kananAnimationName, true, 0.25f);
    }
    public static void Animate_gerakBawah()
    {
        spineAnimationState.SetAnimation(0, mulaiBawahAnimationName, false);
        spineAnimationState.AddAnimation(0, bawahAnimationName, true, 0.25f);
    }
    public static void Animate_gerakAtas()
    {
        spineAnimationState.SetAnimation(0, mulaiAtasAnimationName, false);
        spineAnimationState.AddAnimation(0, atasAnimationName, true, 0.25f);
    }
    public static void Animate_kenaTembokAtas()
    {
        //spineAnimationState.SetAnimation (0, kenaTembokAtasAnimationName, false);
        spineAnimationState.SetAnimation(0, kenaTembokAtasAnimationName, false);
        spineAnimationState.AddAnimation(0, mulaiBerdiriTembokAtasAnimationName, false, 0.5f);
        spineAnimationState.AddAnimation(0, idleAnimationName, true, 1);
    }
    public static void Animate_kenaTembokBawah()
    {
        spineAnimationState.SetAnimation(0, kenaTembokBawahAnimationName, false);
        spineAnimationState.AddAnimation(0, mulaiBerdiriTembokBawahAnimationName, false, 0.5f);
        spineAnimationState.AddAnimation(0, idleAnimationName, true, 1);

    }
    public static void Animate_kenaTembokKiri()
    {
        spineAnimationState.SetAnimation(0, kenaTembokKiriAnimationName, false);
        spineAnimationState.AddAnimation(0, mulaiBerdiriTembokKiriName, false, 0.5f);
        spineAnimationState.AddAnimation(0, idleAnimationName, true, 1);
    }
    public static void Animate_kenaTembokKanan()
    {
        //spineAnimationState.SetAnimation (0, kenaTembokKananAnimationName, false);
        spineAnimationState.SetAnimation(0, kenaTembokKananAnimationName, false);
        spineAnimationState.AddAnimation(0, mulaiBerdiriTembokKananName, false, 0.5f);
        spineAnimationState.AddAnimation(0, idleAnimationName, true, 1);
    }
    public static void Animate_EndLevelKiri()
    {
        spineAnimationState.TimeScale = 0.5f;
        spineAnimationState.SetAnimation(0, EndLevelLastKiri, false);
        Debug.Log("Masuk Animasi EndLevelLastKiri");
    }
    public static void Animate_EndLevelKanan()
    {
        spineAnimationState.TimeScale = 0.5f;
        spineAnimationState.SetAnimation(0, EndLevelLastKanan, false);
        Debug.Log("Masuk Animasi EndLevelLastKanan");
    }
    public static void Animate_EndLevelAtas()
    {
        spineAnimationState.TimeScale = 0.5f;
        spineAnimationState.SetAnimation(0, EndLevelLastAtas, false);
        Debug.Log("Masuk Animasi EndLevelLastAtas");
    }
    public static void Animate_EndLevelBawah()
    {
        spineAnimationState.TimeScale = 0.5f;
        spineAnimationState.SetAnimation(0, EndLevelLastBawah, false);
        Debug.Log("Masuk Animasi EndLevelLastBawah");
    }
}
