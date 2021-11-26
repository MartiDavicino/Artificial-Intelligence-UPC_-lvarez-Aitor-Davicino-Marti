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

    private float deacceleration = 1 / 100f;
    //vector3 target points
    Vector3 localTarget;
    Vector3 worldTarget;

    private NavMeshAgent agent;
    private NavMeshHit hit;

    public float distanceToTarget;

    private GameObject enemyTank;
    private Shooting shootingComponent;

    // Start is called before the first frame update
    void Start()
    {
        shootingComponent = gameObject.GetComponent<Shooting>();
        agent = GetComponent<NavMeshAgent>();
        enemyTank = GameObject.Find("Enemy Tank");

        //calculate wander
        if (!shootingComponent.hasNoBullets)
        {
            localTarget = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
            localTarget.Normalize();
            localTarget *= radius;
            localTarget += new Vector3(0, 0, Random.Range(minOff, maxOff));

            worldTarget = transform.TransformPoint(localTarget);
            worldTarget.y = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!shootingComponent.hasNoBullets)
        {
            Debug.Log("Wandering");
            //calculate poiunt where tank is going
            distanceToTarget = Vector3.Distance(worldTarget, transform.position);
            //Debug direction
            Debug.DrawLine(transform.position, worldTarget, Color.green);

            if (!enemyTank.activeSelf && agent.speed > 0)
                agent.speed -= deacceleration;
            //Optimize route through navMesh
            if (distanceToTarget <= distanceToChange || CheckIfWalkable(worldTarget) && agent.speed > 0)
            {
                localTarget = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
                localTarget.Normalize();
                localTarget *= radius;
                localTarget += new Vector3(0, 0, Random.Range(minOff, maxOff));

                worldTarget = transform.TransformPoint(localTarget);
                worldTarget.y = 0f;
            }
        }
        else
        {
            Debug.DrawLine(transform.position, worldTarget, Color.blue);
            Debug.Log("Going to reloading place : "+shootingComponent.reloadPlace.position);

            localTarget = shootingComponent.reloadPlace.transform.position;
            localTarget.Normalize();
            localTarget *= radius;
            worldTarget = transform.TransformPoint(localTarget);
            worldTarget.y = 0;
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