using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonScript : MonoBehaviour
{
    public GameObject ExitLevel;
    public GameObject ReturnTOLevel;


    void Start()
    {
    
    }

    void Update()
    {
        
    }

    public void CloseWindow()
    {
        ExitLevel.SetActive(false);
        Time.timeScale = 1;

    }

    public void CloseWindowReturn()
    {
        ReturnTOLevel.SetActive(false);
        Time.timeScale = 1;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            ExitLevel.SetActive(true);
            Time.timeScale = 0;
        }

        //

        if (collision.gameObject.tag == "Stairs")
        {
            ReturnTOLevel.SetActive(true);
            Time.timeScale = 0;
        }

    }

  

    /*
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            ExitLevel.SetActive(false);
        }

    }
    */
}