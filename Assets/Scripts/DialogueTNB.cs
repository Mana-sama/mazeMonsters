using UnityEngine;
using TMPro;
public class DialogueTNB : MonoBehaviour
{
    public TMP_Text TNDialogueText;
    public GameObject TNFieldForText;
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
                TNFieldForText.SetActive(true);

                TNDialogueText.SetText("Congratulations! The script worked. -TENEBI");

                Time.timeScale = 1;
            }

        }

    }




}