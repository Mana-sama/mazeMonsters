using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class DialogueScript : MonoBehaviour
{
    public TMP_Text dialogueText;
    // public GameObject TNfieldForText;
    // public GameObject ZCfieldForText;
    public GameObject textBox;

    private void Start()
    {   
    //textBox.SetActive(false);
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                // Time.timeScale = 0;
                textBox.SetActive(true);
                dialogueText.SetText("Congratulations! The script worked.");
               // fieldForText.SetActive(true);
                Debug.Log("If youre kawaii and you know it clap your hands");
            }

        }

    }
 


}