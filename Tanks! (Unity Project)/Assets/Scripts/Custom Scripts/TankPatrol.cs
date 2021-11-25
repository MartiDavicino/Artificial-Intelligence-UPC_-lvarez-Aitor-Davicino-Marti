using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankPatrol : MonoBehaviour
{

    

    //vector3 target points
    public Transform[] destinations;
    int destinationsStep = 0;
    float distanceToDestination;

    private NavMeshAgent agent;
    private NavMeshHit hit;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.destination = destinations[destinationsStep].position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Chasing destination : " + destinationsStep);
        //Debug direction
        Debug.DrawLine(transform.position, destinations[destinationsStep].position, Color.green);

        distanceToDestination = Vector3.Distance(transform.position, destinations[destinationsStep].position);
        if (distanceToDestination < 1)
        {
            if (destinationsStep == destinations.Length)
                destinationsStep = 0;
            else
                destinationsStep++;

        }

        //set agent direction
        agent.destination = destinations[destinationsStep].position;
    }

    //Check if Nav Mesh is walkable
    bool CheckIfWalkable(Vector3 wolrd_target)
    {
        if (NavMesh.Raycast(transform.position, destinations[destinationsStep].position, out hit, NavMesh.AllAreas))
            return true;
        else return false;
    }

}