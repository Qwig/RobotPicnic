using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public float X;
    public float Y;
    public Player Player;

    public bool beenHere;

    void OnMouseDown()
    {
            Player.Move(X, Y);
    }


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
}
