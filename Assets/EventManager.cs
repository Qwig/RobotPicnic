using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour {

    public GameObject choiceBox;
    public GameObject confirmBox;

    private Text[] eventTextBoxes;
    private Text eventText;
    private Text choice1;
    private Text choice2;
    private Text choice3;

    private Button[] buttons;

	void Awake ()
    {
        buttons = GetComponentsInChildren<Button>();
        buttons[1].onClick.AddListener(Outcome1);
        buttons[2].onClick.AddListener(Outcome2);
        buttons[3].onClick.AddListener(Outcome3);

        eventTextBoxes = GetComponentsInChildren<Text>();
        eventText = eventTextBoxes[0];
        choice1 = eventTextBoxes[1];
        choice2 = eventTextBoxes[2];
        choice3 = eventTextBoxes[3];

        choiceBox.SetActive(true);
        confirmBox.SetActive(false);
	}


    void Outcome1()
    {
        eventText.text = "You have chosen the first button";

        choiceBox.SetActive(false);
        confirmBox.SetActive(true);
    }

    void Outcome2()
    { 
        eventText.text = "You have chosen the second button";

        choiceBox.SetActive(false);
        confirmBox.SetActive(true);
    }

    void Outcome3()
    { 
        eventText.text = "You have chosen the third button";

        choiceBox.SetActive(false);
        confirmBox.SetActive(true);
    }

}
