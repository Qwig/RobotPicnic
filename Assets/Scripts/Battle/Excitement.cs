﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Excitement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public int speed = 100;
	// Use this for initialization
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        rb2d.transform.Rotate(0, 0, speed * Time.deltaTime);
	}
}
