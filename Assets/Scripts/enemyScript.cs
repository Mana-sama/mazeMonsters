using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class enemyScript : MonoBehaviour
{

    private float timer;

    [SerializeField] Transform target;

    NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        agent.SetDestination(target.position);
    }

 

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {


            timer += Time.deltaTime;

            GetComponent<NavMeshAgent>().speed = 3;

            if (timer >= 2)
            {

                // «бер≥гаЇмо назву поточноњ сцени
                PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);

                // «бер≥гаЇмо позиц≥ю гравц€ (передай сюди координати об'Їкта гравц€)
                PlayerPrefs.SetFloat("PlayerX", collision.gameObject.transform.position.x);
                PlayerPrefs.SetFloat("PlayerY", collision.gameObject.transform.position.y);

                // «бер≥гаЇмо ≥м'€ ворога, з €ким б'Їмос€ (важливо, щоб ≥мена ворог≥в на сцен≥ були ун≥кальними!)
                PlayerPrefs.SetString("CurrentEnemy", gameObject.name);
                PlayerPrefs.Save();
                SceneManager.LoadScene("FightScene");
                timer = 0;
            }

        }

    }
}