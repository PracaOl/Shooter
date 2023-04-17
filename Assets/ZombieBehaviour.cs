using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieBehaviour : MonoBehaviour
{
    public float sightRange = 15f;
    int hp = 10;

    GameObject player;
    NavMeshAgent agent;

    private bool playerVisible = false;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 raySource = transform.position + Vector3.up * 1.8f;
        Vector3 rayDirection = player.transform.position - transform.position;
        //Debug.DrawLine(raySource, rayDest);

        RaycastHit hit;
        if (Physics.Raycast(raySource, rayDirection, out hit, 15f))
        {

            Debug.Log(hit.transform.gameObject.ToString());
            if (hit.transform.CompareTag("Player"))
                //Debug.Log("I see you.");
                playerVisible= true;
            else
                playerVisible= false;
        }

        agent.isStopped = !playerVisible;
        if(hp> 0)
        {
            //transform.LookAt(player.transform.position);
            //Vector3 playerDirection = transform.position - player.transform.position;

            //transform.Translate(Vector3.forward * Time.deltaTime);

            agent.destination = player.transform.position;
        }
        

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            hp--;
            if(hp <= 0)
            {
                transform.Translate(Vector3.up);
                transform.Rotate(Vector3.right * -90);
                GetComponent<BoxCollider>().enabled = false;
                Destroy(transform.gameObject, 5);
            }
        }
    }
}

