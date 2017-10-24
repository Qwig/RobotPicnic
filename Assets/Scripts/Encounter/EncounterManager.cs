using UnityEngine;

public class EncounterManager : MonoBehaviour
{
    public int size;
    public GameObject[,] map;
    public GameObject[] Squares;
    private Transform encounterMap;
    public GameObject PicnicSupplies;
    public  GameObject enemy;

    private Enemy darkToasto;
    // Use this for initialization
    void Start()
    {
        if(EncounterSaveObject.data.battleType == "Epic")
        {
            EncounterSaveObject.data.battleType = "";
            Destroy(enemy);
        }
        map = new GameObject[size, size];
        encounterMap = new GameObject("EncounterMap").transform;
        if (EncounterSaveObject.data.map == null)
        {
            CreateMap();
        }
        else
        {
            if (EncounterSaveObject.data.BattleVictory)
            {
                EncounterSaveObject.data.map[EncounterSaveObject.data.PlayerX, EncounterSaveObject.data.PlayerY] = Squares[0];
            }
            map = EncounterSaveObject.data.map;
        }
        RenderMap();

        darkToasto = enemy.GetComponent<Enemy>();
    }

    public void EnemyTurn()
    {
        if (enemy != null)
        darkToasto.Move();
    }

    private void RenderMap()
    {
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                GameObject instance = Instantiate(map[x, y], new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(encounterMap);
                var square = instance.GetComponent<Square>();
                square.X = x;
                square.Y = y;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateMap()
    {
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                map[x, y] = Squares[UnityEngine.Random.Range(0, Squares.Length)];
            }
        }

        map[UnityEngine.Random.Range(0, size), UnityEngine.Random.Range(0, size)] = PicnicSupplies;
        map[0, 0] = Squares[0];
        EncounterSaveObject.data.map = map;

    }
}
