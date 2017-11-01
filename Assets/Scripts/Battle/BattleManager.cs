using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {


    public GameObject winButton;
    public GameObject background;
    public GameObject musicPlayer;
    public GameObject sprite;
    public Sprite darkToasto;

    private AudioSource[] musicTracks;
    private AudioSource testChaChing;

    void Start ()
    {
        winButton.SetActive(false);
        musicTracks = musicPlayer.GetComponents<AudioSource>();
        testChaChing = GetComponent<AudioSource>();

        if (EncounterSaveObject.data.battleType == "Epic")
        {
            background.GetComponent<Excitement>().speed = 20;
            sprite.GetComponent<SpriteRenderer>().sprite = darkToasto;
            musicTracks[1].Play();
        }
        else
            musicTracks[0].Play();
	}

    public void PurchaseWinButton()
    {
        testChaChing.Play();
        winButton.SetActive(true);
    }
}
