using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankReload : MonoBehaviour
{
    //vector3 target points
    public Transform destination;
    
    float distanceToDestination;

    private NavMeshAgent agent;
    private NavMeshHit hit;
    public bool reloaded = true;


    // Start is called before the first frame update
    public void GoTOBase()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = destination.position;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    Debug.DrawLine(transform.position, destination.position, Color.black);
    //}

}