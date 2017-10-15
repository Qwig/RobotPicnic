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
    public TextAsset oldArea, newArea, testall01;
}

public class Event
{
    public int ob, gain, loss;
    public string actiontxt, passtxt, failtxt;
    public bool isEncounter;

    public Event(int o, int add, int sub, 
        string act, string pass, string fail,
        bool encounter)
        {
            ob = o; gain = add; loss = sub;
            actiontxt = act; passtxt = pass; failtxt = fail;
            isEncounter = encounter;
        }
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

    private List<Event> allEvents = new List<Event>();
    private List<Event> currentEvents = new List<Event>();

    private Text[] textBoxes;
    private Button[] buttons;

    private string[] oldAreas;
    private string[] newAreas;
    private string[] eventTxts;

    bool Diceroll (int howmanydice, int dc)
    {
        int roll = 0;
        for (int i = 0; i < howmanydice; i++)
            roll = roll + Random.Range(1,luckValues.dX+1);
        //Debug.Log("Total roll: " + roll + "\r\n> Needed " + dc);
        if (dc > roll)
            return false;
        else
            return true;
    } 

    void SetupEvents ()
    {
        
        for (int i = 0; i < eventTxts.Length; i++)
        {
            string[] apf = eventTxts[i].Split(';');
            bool excitement = true;
            if (1 == Random.Range(0, 2))
                excitement = false;
            allEvents.Add(new Event(
                Random.Range(2,7), Random.Range(1,4), Random.Range(1,4),
                apf[0], apf[1], apf[2], excitement));
        }
    }

	void Awake ()
    {
        buttons = GetComponentsInChildren<Button>();
        buttons[0].onClick.AddListener(EventEnd);
        buttons[1].onClick.AddListener(() => EventChoice(0));  
        buttons[2].onClick.AddListener(() => EventChoice(1));
        buttons[3].onClick.AddListener(() => EventChoice(2));

        textBoxes = GetComponentsInChildren<Text>();
        oldAreas = txtFiles.oldArea.text.Split(';');
        newAreas = txtFiles.newArea.text.Split(';');
        eventTxts = txtFiles.testall01.text.Split('|');
        
        SetupEvents();

        eventResolving = false;
        textBox.SetActive(false);
        choiceBox.SetActive(false);
        confirmBox.SetActive(false);
	}

    
    void PickEvents (int howmany)
    {   
        for (int i = 0; i < howmany; i++)
        {
            int e = Random.Range(0,allEvents.Count);
            currentEvents.Add(allEvents[e]);
            allEvents.RemoveAt(e);
        }

    }

    public void NewEvent(bool beenHere)
    {   

        textBox.SetActive(true);
        if (!beenHere)
        {   
            textBoxes[0].text = newAreas[Random.Range(0,newAreas.Length)];
            PickEvents(3);
            textBoxes[2].text = currentEvents[0].actiontxt;
            textBoxes[3].text = currentEvents[1].actiontxt;
            textBoxes[4].text = currentEvents[2].actiontxt;
            choiceBox.SetActive(true);
        } else {
            textBoxes[0].text = oldAreas[Random.Range(0,oldAreas.Length)]
            + energy + "%.";
            confirmBox.SetActive(true);
        }
    }

    void EventChoice (int eventn)
    {
        if (currentEvents[eventn].isEncounter)
            Application.LoadLevel("EncounterView");
        else
        {
            if (Diceroll(skill, (currentEvents[eventn].ob)))
            {

                energy = energy + (currentEvents[eventn].gain);
                textBoxes[1].text = "> Continue...";
                textBoxes[0].text = currentEvents[eventn].passtxt
                + "\r\n\r\n> Energy levels at " + energy + "%.";
            }
            else
            {
                energy = energy - (currentEvents[eventn].loss);
                if (energy <= 0)
                {
                    energy = 0;
                    textBoxes[1].text = "> RUST IN PEACE";
                }
                textBoxes[0].text = currentEvents[eventn].failtxt
                + "\r\n\r\n> Energy levels at " + energy + "%.";

            }

            allEvents.AddRange(currentEvents);
            currentEvents.RemoveRange(0, currentEvents.Count);

            choiceBox.SetActive(false);
            confirmBox.SetActive(true);
        }
    }

    void EventEnd ()
    {
        if (energy > 0)
            eventResolving = false;
        textBox.SetActive(false);
        confirmBox.SetActive(false);
    }
}
