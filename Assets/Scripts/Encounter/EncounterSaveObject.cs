using UnityEngine;

public class EncounterSaveObject : MonoBehaviour
{
    public static EncounterSaveData data;

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
}
