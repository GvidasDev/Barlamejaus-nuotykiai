using UnityEngine;
using TMPro;

public class Keypad : MonoBehaviour
{
    public string correctCode = "67210";
    private string enteredCode = "";
    public TextMeshProUGUI displayText;
    public Door doorScript;

    public void ButtonPressed(string number)
    {
        enteredCode += number;
        displayText.text = enteredCode;
    }

    public void EnterCode()
    {
        if (enteredCode == correctCode)
        {
            doorScript.UnlockDoor();
            displayText.text = "Correct!";
        }
        else
        {
            displayText.text = "Wrong Code!";
            enteredCode = "";
        }
    }

    public void ClearCode()
    {
        enteredCode = "";
        displayText.text = "";
    }
}
