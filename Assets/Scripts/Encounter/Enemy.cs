using System;
using UnityEngine;

public class Enemy : MovingObject {

    public static int X = 7;
    public static int Y = 7;

    public override void Start()
    {
        base.Start();
        X = EncounterSaveObject.data.EnemyX;
        Y = EncounterSaveObject.data.EnemyY;
        rb2D.position = new Vector3(X, Y, 0);
    }
	
	// Update is called once per frame
	void Update() {
		
	}

    public void Move()
    {
        int dX = EncounterSaveObject.data.PlayerX - X;
        int dY = EncounterSaveObject.data.PlayerY - Y;
        int changeX=0;
        int changeY=0;


        if(Math.Abs(dX)>=Math.Abs(dY))
        {
            if (dX > 0)
            {
                changeX = 1;
            }
            else
            {
                changeX = -1;
            }
        }
        else
        {
            if (dY > 0)
            {
                changeY = 1;
            }
            else
            {
                changeY = -1;
            }
        }
        ActuallyMove(X+changeX, Y+changeY);
        X = X + changeX;
        Y = Y + changeY;
        EncounterSaveObject.data.EnemyX = X;
        EncounterSaveObject.data.EnemyY = Y;
    }
}
