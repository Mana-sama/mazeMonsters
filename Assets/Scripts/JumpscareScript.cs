using System.Collections;
using UnityEngine;

public class JumpscareScript : MonoBehaviour
{
   
    public GameObject jumpscare;
    public float waitSeconds = 2;

    void Start()
    {
        // StartCoroutine(ImageActivate());
    }

   
    IEnumerator ImageDeactivate()
    {
        yield return new WaitForSeconds(waitSeconds);
        jumpscare.SetActive(false);
    }
    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            int random = Random.Range(0, 1000);


            if (random < 1)
            {
                // StopAllCoroutines();
                jumpscare.SetActive(true);
               StartCoroutine(ImageDeactivate());
            }

        }

    }






}
