using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RiddleTextController : MonoBehaviour
{

    [SerializeField] private int id;
    //private TextMeshProUGUI riddleText;
    //private Color textColor;

    public GameObject[] objectsArray;

    private void OnEnable()
    {
        GameEventsManager.instance.riddleUIEvents.onRiddleProgress += RiddleProgress;
    }
    private void OnDisable()
    {
        GameEventsManager.instance.riddleUIEvents.onRiddleProgress -= RiddleProgress;
    }

    private void Start()
    {
        //riddleText = GetComponent<TextMeshProUGUI>();
        //textColor = riddleText.color;
        //HideText();

        objectsArray = new GameObject[3];
        objectsArray[0] = GameObject.Find("Riddle1");
        objectsArray[1] = GameObject.Find("Riddle2");
        objectsArray[2] = GameObject.Find("Riddle3");

    }

    private void RiddleProgress(int id,string status)
    {
         ShowText(id,status);

    }

    private void ShowText(int id, string status)
    {
        //riddleText.gameObject.SetActive(true);
        objectsArray[id-1].GetComponent<TextMeshProUGUI>().text = status;
/*      riddleText.enabled = false;
        textColor.a = 1f;
        riddleText.color = textColor;
        riddleText.text = status;
        riddleText.gameObject.SetActive(false);
        riddleText.enabled = true;*/
    }
/*    private void HideText()
    {
        textColor.a = 0f;
        riddleText.color = textColor;
    }*/
}
