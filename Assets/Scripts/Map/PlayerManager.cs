using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MovingObject
{

    public void Move(float x, float y)
    {
        ActuallyMove(x, y);
    }





    // Use this for initialization
    public override void Start ()
    {
        base.Start();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
