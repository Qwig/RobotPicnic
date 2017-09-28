using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public float X;
    public float Y;
    public PlayerManager Player;
    public EventManager eventUI;
   
    public bool beenHere;

    void OnMouseDown()
    {
        if (!eventUI.eventResolving) 
        {
            eventUI.eventResolving = true;
            eventUI.NewEvent(beenHere);
            beenHere = true;
            Player.Move(X, Y);
        }
    }


    void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        eventUI = GameObject.FindGameObjectWithTag("EventUI").GetComponent<EventManager>();
	}

}
