﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectingGround : MonoBehaviour {
    public string name;
    public bool isDetected;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isDetected = true;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isDetected = false;
    }
}
