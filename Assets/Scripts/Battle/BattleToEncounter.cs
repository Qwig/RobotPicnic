using UnityEngine;
using UnityEngine.UI;

public class BattleToEncounter : MonoBehaviour {

    private Button button;
    public bool victory;
    // Use this for initialization
    void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(SceneTransition);
    }

    private void SceneTransition()
    {
        EncounterSaveObject.data.BattleVictory = victory;
        Application.LoadLevel("EncounterView");
    }
}
