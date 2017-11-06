﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wowspin : MonoBehaviour
{
    private Rigidbody2D rb2d;
	// Use this for initialization
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        rb2d.transform.Rotate(0, 0, 100 * Time.deltaTime);
	}
}
