﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowTentacle : MonoBehaviour {


    private bool isActive = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(isActive)
        {
        }
		
	}
    public void Go()
    {
        isActive = true;
    }
}
