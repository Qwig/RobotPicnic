
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject Node;
    public int NodeCount;
    private Transform Map;

    public void CreateMap()
    {
        Map = new GameObject("Map").transform;
        for (int i = 0; i < NodeCount; i++)
        {
            var x = Random.Range(0f, 10f);
            var y = Random.Range(0f, 10f);
            GameObject instance = Instantiate(Node, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
            instance.transform.SetParent(Map);
            var node = instance.GetComponent<Node>();
            node.X = x;
            node.Y = y;
        }

    }

}
