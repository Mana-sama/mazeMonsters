using TMPro;
using UnityEngine;

public class ReadInput : MonoBehaviour
{
    public GameObject code;
    public GameObject door;

    // НОВЕ: Публічне поле для самого поля вводу
    public TMP_InputField inputField;

    private string input;

    public void ReadStringInput(string pin)
    {
        input = pin;
        Debug.Log(input);
    }

    public void OnEditColor()
    {
         if (inputField != null) 
            inputField.textComponent.color = Color.white;
    }

    public void CodeCheck(string pin)
    {
        if (pin == "9513")
        {
            Debug.Log("Correct");
            // Повертаємо нормальний колір, якщо правильно (зміни Color.white на Color.black якщо текст має бути чорним)
            if (inputField != null) inputField.textComponent.color = Color.white;

            code.SetActive(false);
            door.SetActive(true);
        }
        else
        {
            Debug.Log("Incorrect");
            // Фарбуємо в червоний
            if (inputField != null) inputField.textComponent.color = Color.red;
        }
    }

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