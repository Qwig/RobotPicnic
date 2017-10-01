
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject Node;
    public int NodeCount;
    private Transform Map;

   
			public void CreateMap()
			{
				List<Vector3> coordinates = new List<Vector3>();

				for (int j = -5; j <= 5;j++)
				{
					for (int k = -5; k <= 5;k++)
					{
						Vector3 coordinate = new Vector3 (j, k, 0f); 
						coordinates.Add(coordinate);

					}
				}


				Map = new GameObject("Map").transform;
				for (int i = 0; i < NodeCount; i++)
				{


					Vector3 target = coordinates [Random.Range (0, coordinates.Count)];
					GameObject instance = Instantiate (Node, target, Quaternion.identity) as GameObject;
					instance.transform.SetParent (Map);
					var node = instance.GetComponent<Node> ();
					node.X = target.x;
					node.Y = target.y;
					coordinates.Remove (target);



				}

			}
        }
