using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterManager : MonoBehaviour
{
    public int size;
    public GameObject[,] map;
    public GameObject[] Squares;
    private Transform encounterMap;
    public GameObject PicnicSupplies;



    // Use this for initialization
    void Start ()
    {
        map = new GameObject[size, size];
        encounterMap = new GameObject("EncounterMap").transform;
        CreateMap();
        RenderMap();


	}

    private void RenderMap()
    {
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                GameObject instance = Instantiate(map[x,y], new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(encounterMap);
                var square = instance.GetComponent<Square>();
                square.X = x;
                square.Y = y;
            }
        }
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    void CreateMap()
    {
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                map[x, y] = Squares[UnityEngine.Random.Range(0,Squares.Length)];
            }
        }

        map[UnityEngine.Random.Range(0, size), UnityEngine.Random.Range(0, size)] = PicnicSupplies;


    }
}
