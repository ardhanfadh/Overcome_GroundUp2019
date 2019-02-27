using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GoalScript : MonoBehaviour {
    public DOTweenAnimation dtween;
    public BoxCollider2D goalBox;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(GoalAnim());
        dtween.DOPlay();
    }

    IEnumerator GoalAnim()
    {
        yield return new WaitForSeconds(0.3f);
        goalBox.isTrigger = true;
    }
}
