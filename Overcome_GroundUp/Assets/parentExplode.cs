using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parentExplode : MonoBehaviour {
    bool justOnce;
    public bool isExplode;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isExplode)
        {
            StartCoroutine(isExploding());
        }
	}

    public IEnumerator isExploding()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
