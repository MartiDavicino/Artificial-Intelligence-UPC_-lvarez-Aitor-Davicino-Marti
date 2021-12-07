using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankPatrol : MonoBehaviour
{

    

    //vector3 target points
    public Transform[] destinations;
    public int destinationsStep = 0;
    public float distanceToDestination;

    public TankReload rel;

    private NavMeshAgent agent;
    private NavMeshHit hit;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rel = GetComponent<TankReload>();
        agent.destination = destinations[destinationsStep].position;
    }

    // Update is called once per frame
    public void Patrol()
    {
        Debug.Log("Chasing destination : " + destinationsStep);
        //Debug direction
        Debug.DrawLine(transform.position, destinations[destinationsStep].position, Color.black);

        distanceToDestination = Vector3.Distance(transform.position, destinations[destinationsStep].position);

        if (distanceToDestination < 1)
        {
            destinationsStep++;

            if (destinationsStep == destinations.Length)
                destinationsStep = 0;

            agent.destination = destinations[destinationsStep].position;

        }
        if (rel.reloaded==true)
        {
            agent.destination = destinations[destinationsStep].position;
        }

        //set agent direction
    }

    //Check if Nav Mesh is walkable
    bool CheckIfWalkable(Vector3 wolrd_target)
    {
        if (NavMesh.Raycast(transform.position, destinations[destinationsStep].position, out hit, NavMesh.AllAreas))
            return true;
        else return false;
    }

}