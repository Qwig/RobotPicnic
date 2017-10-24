using UnityEngine;

public class EncounterSaveObject : MonoBehaviour
{
    public static EncounterSaveData data = new EncounterSaveData();

    public EncounterSaveObject Instance;


    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            data = new EncounterSaveData();
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void SaveGame()
    {

    }

    public void LoadGame()
    {

    }
}
