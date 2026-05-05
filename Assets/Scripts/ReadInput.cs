using TMPro;
using UnityEngine;


public class ReadInput : MonoBehaviour
{
    public GameObject code;
    public GameObject door;
    private string input;

   // public TMP_InputField inputField;

    public void ReadStringInput(string pin)
    {
        input = pin;
        Debug.Log(input);

    }
    /////////////////
    
    public void CodeCheck(string pin/* , TMP_InputField inputField */ )
    {
        if (pin == "9513")
        {
            Debug.Log("Correct");
            code.SetActive(false);
            door.SetActive(true);

        }


        else
        {
            Debug.Log("Incorrect");
           // inputField.textComponent.color = Color.red;
        }
    }

    /////////////////////////

    public void PopUpStability(GameObject code, GameObject door)
    {
        if (code.activeSelf == true)
        {
            door.SetActive(false);
        }


        if (door.activeSelf == true)
        {
            code.SetActive(false);
        }

    }


}