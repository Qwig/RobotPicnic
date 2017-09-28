using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Luck
{
    public int dX, dcEasy, dcMid, dcHard;
}

[System.Serializable]
public class EventTextFiles
{
    public TextAsset oldArea, newArea, pass, fail;
}

public class EventManager : MonoBehaviour {

    public Luck luckValues;
    public EventTextFiles txtFiles;
    public GameObject textBox;
    public GameObject choiceBox;
    public GameObject confirmBox;

    public bool eventResolving;
    public int energy;
    public int skill;

    private Text[] textBoxes;
    private Button[] buttons;

    private string[] oldAreas;
    private string[] newAreas;
    private string[] eventPass;
    private string[] eventFail;

    bool Diceroll (int howmanydice, int dc)
    {
        int roll = 0;
        for (int i = 0; i < howmanydice; i++)
            roll = roll + Random.Range(1,luckValues.dX+1);
        Debug.Log("Total roll: " + roll + "\r\n> Needed " + dc);
        if (dc > roll)
            return false;
        else
            return true;
    } 

	void Awake ()
    {
        buttons = GetComponentsInChildren<Button>();
        buttons[0].onClick.AddListener(EventEnd);
        buttons[1].onClick.AddListener(() => EventChoice(1));  
        buttons[2].onClick.AddListener(() => EventChoice(2));
        buttons[3].onClick.AddListener(() => EventChoice(3));

        textBoxes = GetComponentsInChildren<Text>();
        oldAreas = txtFiles.oldArea.text.Split(';');
        newAreas = txtFiles.newArea.text.Split(';');
        eventPass = txtFiles.pass.text.Split(';');
        eventFail = txtFiles.fail.text.Split(';');

        eventResolving = false;
        textBox.SetActive(false);
        choiceBox.SetActive(false);
        confirmBox.SetActive(false);
	}

    public void NewEvent(bool beenHere)
    {   

        textBox.SetActive(true);
        if (!beenHere)
        {   
            textBoxes[0].text = newAreas[Random.Range(0,newAreas.Length)];
            choiceBox.SetActive(true);
        } else {
            textBoxes[0].text = oldAreas[Random.Range(0,oldAreas.Length)]
            + energy + "%.";
            confirmBox.SetActive(true);
        }
    }

    void EventChoice (int eventn)                   // currently this is a low-effort placeholder
    {                                               // Would events be better handled as classes?
        if (Diceroll(skill, (1+eventn)))
        {
            
            energy = energy + eventn;
            textBoxes[1].text = "> Continue...";
            textBoxes[0].text = eventPass[eventn]
            + "\r\n\r\n> Energy levels at " + energy + "%.";
        }
        else
        {
            energy = energy - eventn;
            if (energy <= 0)
            {
                energy = 0;
                textBoxes[1].text = "> RUST IN PEACE";
            }
            textBoxes[0].text = eventFail[eventn]
            + "\r\n\r\n> Energy levels at " + energy + "%.";

        }

        choiceBox.SetActive(false);
        confirmBox.SetActive(true);
    }

    void EventEnd ()
    {
        if (energy > 0)
            eventResolving = false;
        textBox.SetActive(false);
        confirmBox.SetActive(false);
    }
}
