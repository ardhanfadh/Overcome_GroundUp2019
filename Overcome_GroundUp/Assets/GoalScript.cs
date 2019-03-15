using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GoalScript : MonoBehaviour {
    public DOTweenAnimation dtween;
    public BoxCollider2D goalBox;
    public Explodable GoalExplode;
    public GameObject StartGoal_Sprite;
    public GameObject EndGoal_Sprite;
	// Use this for initialization
	void Start () {
        StartGoal_Sprite.SetActive(true);
        EndGoal_Sprite.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(GoalAnim());
        }
    }

    IEnumerator GoalAnim()
    {
        StartGoal_Sprite.SetActive(false);
        EndGoal_Sprite.SetActive(true);
        goalBox.isTrigger = true;
        yield return null;
    }
}
