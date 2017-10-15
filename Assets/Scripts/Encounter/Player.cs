using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovingObject
{

	// Use this for initialization
	void Start ()
    {
        base.Start();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Move(float x, float y)
    {
        ActuallyMove(x, y);
    }

    private void OnTriggerEnter2D(Collider2D fight)
    {
        if (fight.gameObject.tag == "Fight")
        {
            Application.LoadLevel("BattleView");
        }
        if (fight.gameObject.tag == "PicnicSupplies")
        {
            Application.LoadLevel("MapView");
        }

    }
}
