using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public float X;
    public float Y;
    public PlayerManager Player;
   


    void OnMouseDown()
    {
        //string test = "turkeys are amazing";
        //Debug.Log("X:" + X.ToString() + "\nY:" + Y.ToString() + "\n");
        Player.Move(X, Y);

    }


    // Use this for initialization
    void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
