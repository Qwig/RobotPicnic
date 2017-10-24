using UnityEngine;

public class Player : MovingObject
{
    public static int X = 7;
    public static int Y = 7;
    public GameObject encounterManager;

    private EncounterManager encounterManagerScript;
    // Use this for initialization
    public override void Start()
    {
        base.Start();
        
        if(EncounterSaveObject.data.BattleVictory)
        {
            X = EncounterSaveObject.data.PlayerX;
            Y = EncounterSaveObject.data.PlayerY;
        }
        else
        {
            X = EncounterSaveObject.data.PlayerOldX;
            Y = EncounterSaveObject.data.PlayerOldY;
        }

        rb2D.position = new Vector3(X, Y, 0);

        encounterManagerScript = encounterManager.GetComponent<EncounterManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //WASD Movement
        if (YourTurnEncounter)
        {
            WASDMovement();
        }
    }

    void WASDMovement ()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            PrepMove(X, Y+1);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            PrepMove(X - 1, Y);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            PrepMove(X, Y - 1);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            PrepMove(X + 1, Y);
        }
    }

    private void PrepMove(int x, int y)
    {
        EncounterSaveObject.data.PlayerOldX = X;
        EncounterSaveObject.data.PlayerOldY = Y;
        ActuallyMove(x, y);
        X = x;
        Y = y;
        EncounterSaveObject.data.PlayerX = X;
        EncounterSaveObject.data.PlayerY = Y;

        encounterManagerScript.EnemyTurn();
    }

    private void OnTriggerEnter2D(Collider2D fight)
    {
        if (fight.gameObject.tag == "Fight")
        {
            Application.LoadLevel("BattleView");
        }
        if (fight.gameObject.tag == "PicnicSupplies")
        {
            Application.LoadLevel("MapView");
        }
        if (fight.gameObject.tag == "Wall")
        {
            YourTurnEncounter = true;
            PrepMove(EncounterSaveObject.data.PlayerOldX, EncounterSaveObject.data.PlayerOldY);
        }
        if (fight.gameObject.tag == "DarkToasto")
        {
            EncounterSaveObject.data.battleType = "Epic";
            Application.LoadLevel("BattleView");
        }
    }
}
