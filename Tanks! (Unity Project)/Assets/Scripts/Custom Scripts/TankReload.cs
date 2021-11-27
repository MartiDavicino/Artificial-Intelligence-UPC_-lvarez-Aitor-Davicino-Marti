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


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.destination = destination.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, destination.position, Color.green);
    }

    //Check if Nav Mesh is walkable
    bool CheckIfWalkable(Vector3 wolrd_target)
    {
        if (NavMesh.Raycast(transform.position, destination.position, out hit, NavMesh.AllAreas))
            return true;
        else return false;
    }

}