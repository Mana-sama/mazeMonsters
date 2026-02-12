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
            SceneManager.LoadScene("FightScene");
            timer = 0;
       }

        }

    }



}