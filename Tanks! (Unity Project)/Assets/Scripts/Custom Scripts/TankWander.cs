using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankWander : MonoBehaviour
{

    public float radius = 2f; //distance od the new point created

    //min and max offset where 
    public float minOff = 10f;
    public float maxOff = 20f;

    public float distanceToChange = 6.5f; //distance where tank changes target point

    //vector3 target points
    Vector3 localTarget;
    Vector3 worldTarget;

    private NavMeshAgent agent;
    private NavMeshHit hit;

    public float distanceToTarget; 

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        //calculate wander
        localTarget = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
        localTarget.Normalize();
        localTarget *= radius;
        localTarget += new Vector3(0, 0, Random.Range(minOff, maxOff));

        worldTarget = transform.TransformPoint(localTarget);
        worldTarget.y = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //calculate poiunt where tank is going
        distanceToTarget = Vector3.Distance(worldTarget, transform.position);
        //Debug direction
        Debug.DrawLine(transform.position, worldTarget, Color.green);

        //Optimize route through navMesh
        if (distanceToTarget <= distanceToChange || CheckIfWalkable(worldTarget))
        {
            localTarget = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
            localTarget.Normalize();
            localTarget *= radius;
            localTarget += new Vector3(0, 0, Random.Range(minOff, maxOff));

            worldTarget = transform.TransformPoint(localTarget);
            worldTarget.y = 0f;
        }

        //set agent direction
        agent.destination = worldTarget;
    }

    //Check if Nav Mesh is walkable
    bool CheckIfWalkable(Vector3 wolrd_target)
    {
        if (NavMesh.Raycast(transform.position, worldTarget, out hit, NavMesh.AllAreas))
            return true;
        else return false;
    }

}