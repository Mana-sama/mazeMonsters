using TMPro;
using UnityEngine;

public class DialogueZCH : MonoBehaviour
{
    public TMP_Text ZCDialogueText;
    public GameObject ZCFieldForText;
    public GameObject textBox;

    private void Start()
    {
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                Time.timeScale = 0;

                textBox.SetActive(true);
                ZCFieldForText.SetActive(true);

                ZCDialogueText.SetText("Congratulations! The script worked. -ZACHARIE");

                Time.timeScale = 1;
            }

        }

    }



}
