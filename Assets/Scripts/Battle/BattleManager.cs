using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {


    public GameObject winButton;
    public GameObject background;
    public GameObject soundManager;
    public GameObject epicSoundManager;
    public GameObject sprite;
    public Sprite darkToasto;

    // Use this for initialization
    void Start ()
    {
		if(EncounterSaveObject.data.battleType == "Epic")
        {
            Destroy(winButton);
            background.GetComponent<Excitement>().speed = 20;
            sprite.GetComponent<SpriteRenderer>().sprite = darkToasto;
            soundManager.GetComponent<AudioSource>().mute = true;
            epicSoundManager.GetComponent<AudioSource>().Play() ;
        }

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
