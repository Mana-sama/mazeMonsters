using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueScript : MonoBehaviour
{
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
                textBox.SetActive(true);
                Debug.Log("If youre kawaii and you know it clap your hands");
            }

        }

    }
 


}