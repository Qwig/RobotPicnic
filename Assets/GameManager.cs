using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public int awesomeTurkeys;

    private MapGenerator _MapGenerator;

    void Start ()
    {
        _MapGenerator = GetComponent<MapGenerator>();

        _MapGenerator.CreateMap();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown ("space"))
        {
            awesomeTurkeys++;
            Debug.Log("The number of awesome turkeys = " + awesomeTurkeys);
        }
	}
}
